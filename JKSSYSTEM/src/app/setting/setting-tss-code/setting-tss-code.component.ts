import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Table
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
// Dialog
import { MatDialog } from '@angular/material/dialog';
import { DialogTssComponent } from '../../setting/setting-tss-code/dialog-tss/dialog-tss.component';
// Service
import { ServiceSettingService } from '../service-setting.service';
import { ExportService } from '../../export.service';
import Swal from 'sweetalert2'
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-setting-tss-code',
  templateUrl: './setting-tss-code.component.html',
  styleUrls: ['../../table/table.component.css']
})
export class SettingTssCodeComponent implements OnInit {

  displayedColumns: string[] = ['action', 'tss_code', 'tss_detail', 'cal_qty', 'cal_extrawork', 'cal_jobspecial'];
  dataSource: any;
  getData: any = [];
  getDataCSV: any = [];
  loading: boolean = false;
  userid:any;

  constructor(
    private serviceSettingService: ServiceSettingService,
    public dialog: MatDialog,
    private exportService: ExportService
  ) {
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

  openDialog(data: any) {
    this.serviceSettingService.addToData(data);  // ส่งค่า row ไปที่ fn addToData

    const dialogRef = this.dialog.open
      (DialogTssComponent, {
        width: '50%',
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
      text: 'ลบ : ' + data.tss_detail,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'ใช่',
      cancelButtonText: 'ไม่'
    }).then(async (result) => {
      if (result.value) {
        await this.deleteData(data.tss_code);
        this.getData = await getData();
        this.dataSource.data = await this.getData;
      }
    })
  }

  async ngOnInit() {
    this.userid = localStorage.getItem('userid');
    this.getData = await getData();
    this.dataSource.data = this.getData;

    this.getDataCSV = await getDataCSV();
  }
  // upload data //
  file: any;
  fileName: any;
  @ViewChild('fileinput') fileinput: any;
  saveFile(e: any) {
    this.file = e.target.files[0];
    this.fileName = e.target.files[0].name;
    console.log(this.file)
    console.log(this.fileName)
  }
  uploadFile() {
    if (this.file !== undefined) {
      let formData = new FormData();
      formData.append('file_form', this.file)
      formData.append('file_name', this.fileName)
      formData.append('update_by', this.userid)

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
      const response = await instance.post('/Upload/UploadTSS', formData)

      this.getData = await getData();
      this.dataSource.data = this.getData;
      this.getDataCSV = await getDataCSV();
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

  columns: any = [];
  exportFile(): void {
    let element = this.getDataCSV;
    this.columns = [];
    this.exportService.exportToCsv(element, 'FormatTSS', this.columns);
  }
  // end upload data //

  async deleteData(datas: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks
      });
      const response = await instance.delete('/DeleteMaster/DeleteTss/' + datas)
      this.getDataCSV = await getDataCSV();
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: 'ลบข้อมูลเสร็จเรียบร้อย.',
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
    const response = await axios.get(environment.apijks + '/Master/Tss', { headers: { Pragma: 'no-cache' } });

    return response.data;
  } catch (error) {
    console.log(error.stack);
  }
}

async function getDataCSV() {
  try {
    const response = await axios.get(environment.apijks + '/Upload/TSSFormat', { headers: { Pragma: 'no-cache' } });

    return response.data;
  } catch (error) {
    console.log(error.stack);
  }
}