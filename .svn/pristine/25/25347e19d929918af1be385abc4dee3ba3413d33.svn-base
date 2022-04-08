import { Component, OnInit, ViewChild } from '@angular/core';
import { environment } from '../../../environments/environment';
import axios from 'axios';
// Table
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
// Dialog
import { MatDialog } from '@angular/material/dialog';
import { DialogManpowerComponent } from '../../setting/setting-manpower/dialog-manpower/dialog-manpower.component';
// Service
import { ServiceSettingService } from '../service-setting.service';

import Swal from 'sweetalert2'
import { ExportService } from '../../export.service';

@Component({
  selector: 'app-setting-manpower',
  templateUrl: './setting-manpower.component.html',
  styleUrls: ['../../home/home.component.css']
})
export class SettingManpowerComponent implements OnInit {

  displayedColumns: string[] = ['action', 'wc_detail', 'model_detail', 'process_detail', 'cell_detail', 'shift_detail', 'manpower', 'op_meister', 'sp_meister','block_group_detail','gb_cell_code'];
  dataSource: any;
  getData: any = [];
  getManpower: any = [];
  loading: boolean = false;
  userid:any;

  constructor(
    private serviceSettingService: ServiceSettingService,
    public dialog: MatDialog,
    private exportService: ExportService) {
    const users = Array.from({ length: 100 }, (_, k) => this.getData);
    this.dataSource = new MatTableDataSource(users);
  }

  @ViewChild(MatPaginator) set paginator(paginator: MatPaginator) {
    this.dataSource.paginator = paginator;
  }
  @ViewChild(MatSort) set sort(sort: MatSort) {
    this.dataSource.sort = sort;
  }
  applyFilter(event: Event) { //ค้นหา
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  file: any;
  fileName: any;
  @ViewChild('fileinput') fileinput: any;
  saveFile(e: any) {
    this.file = e.target.files[0];
    this.fileName = e.target.files[0].name;
    console.log(this.file)
    console.log(this.fileName)
    // console.log(e.target.files[0].size)
    // console.log(e.target.files[0].type)
    // console.log(e.target.value);
  }
  uploadFile() {
    if (this.file !== undefined) {
      let formData = new FormData();
      formData.append('file_form', this.file)
      formData.append('file_name', this.fileName)
      formData.append('update_by', this.userid)
      // console.log('formData', formData)

      this.Upload(formData);
    }
  }
  async Upload(formData: FormData) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'multipart/form-data',
          accept: '*/*'
        }
      });
      this.loading = true;
      const response = await instance.post('/Upload/UploadManpower', formData)
      console.log('response: ', response.data)

      this.getData = await getData();
      this.dataSource.data = this.getData;
      this.getManpower = await getMan();
      this.loading = false;

      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: 'อัปโหลดไฟล์เสร็จเรียบร้อย.',
        showConfirmButton: false,
        timer: 1500
      })
      console.log(this.fileinput.nativeElement.files);
      this.fileinput.nativeElement.value = "";
      this.file = undefined;
      this.fileName = undefined;
      console.log(this.fileinput.nativeElement.files);

      return response.data;
    } catch (error) {
      console.log(error.response.status)
      console.log('RES ERROR: ', error.response)

      Swal.fire({
        icon: 'error',
        title: error.response.status,
        html: error.response.data
      })
      this.loading = false;
      console.log(this.fileinput.nativeElement.files);
      this.fileinput.nativeElement.value = "";
      this.file = undefined;
      this.fileName = undefined;
      console.log(this.fileinput.nativeElement.files);
    }
  }

  // exportElmToExcel(): void {
  //   let element = this.getManpower;
  //   this.exportService.exportJSONToExcel(element, 'FormatManpower');
  // }

  columns: any = [];
  exportFile(): void {
    let element = this.getManpower;
    console.log(element);
    // this.columns = ['wc_detail', 'model_detail', 'process_detail', 'cell_detail', 'shift_detail', 'manpower', 'op_meister', 'sp_meister','block_group_detail','gb_cell_code'];
    // this.exportService.exportToCsv(element, 'FormatManpower', this.columns);   //.csv

    this.exportService.exportJSONToExcel(element, 'FormatManpower');  //.xlsx
  }

  async ngOnInit() {
    this.userid = localStorage.getItem('userid');
    this.getData = await getData();
    this.dataSource.data = this.getData;

    this.getManpower = await getMan();
  }

  openDialog(data: any) {
    this.serviceSettingService.addToData(data);  // ส่งค่า row ไปที่ fn addToData

    const dialogRef = this.dialog.open
      (DialogManpowerComponent, {
        width: '80%',
        data: { data: data }
      });

    dialogRef.afterClosed().subscribe(async result => {
      this.getData = await getData();
      this.dataSource.data = await this.getData;
    });
  }
  openDialogDelete(data: any) {
    Swal.fire({
      title: 'คุณต้องการลบข้อมูลใช่หรือไม่',
      text: 'ลบ : ' + data.id,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'ใช่',
      cancelButtonText: 'ไม่'
    }).then(async (result) => {
      if (result.value) {
        await this.deleteData(data.id);
        this.getData = await getData();
        this.dataSource.data = await this.getData;
      }
    })
  }

  async deleteData(datas: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks
      });
      const response = await instance.delete('/DeleteDetail/DeleteManpower/' + datas)
      this.getManpower = await getMan();
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: 'Deleted data success.',
        showConfirmButton: false,
        timer: 1500
      })

      return response.data;
    } catch (error) {
      console.log(error.response.status)
      console.log('RES ERROR: ', error.response)

      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    }
  }
}

async function getData() {
  try {
    const response = await axios.get(environment.apijks + '/Detail/Manpower', { headers: { Pragma: 'no-cache' } });
    console.log(response.data);
    
    return response.data;
  } catch (error) {
    console.error(error.stack);
  }
}

async function getMan() {
  try {
    const response = await axios.get(environment.apijks + '/Upload/ManpowerFormat', { headers: { Pragma: 'no-cache' } });
        
    return response.data;
  } catch (error) {
    console.error(error.stack);
  }
}