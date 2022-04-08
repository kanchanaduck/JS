import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Table
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
// Dialog
import { MatDialog } from '@angular/material/dialog';
import { DialogDetailComponent } from '../dialog-detail/dialog-detail.component';
// Service
import { ServiceSettingService } from '../service-setting.service';
import { ExportService } from '../../export.service';
import Swal from 'sweetalert2'
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-detail-cell-process',
  templateUrl: './detail-cell-process.component.html',
  styleUrls: ['../../table/table.component.css']
})
export class DetailCellProcessComponent implements OnInit {

  displayedColumns: string[] = ['action', 'process_detail', 'cell_detail'];
  dataSource: any;
  getData: any = [];
  getDataCSV: any = [];
  loading: boolean = false;

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

  openDialog(data: any, page: any) {
    this.serviceSettingService.addToData(data); // ส่งค่า row ไปที่ fn addToData
    this.serviceSettingService.dialog_detail(page);

    const dialogRef = this.dialog.open
      (DialogDetailComponent, {
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
      // text: 'delete: ' + data.id,
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

  async ngOnInit() {
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
      const response = await instance.post('/Upload/UploadProcessCell', formData)

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
    this.exportService.exportToCsv(element, 'FormatDetail - Process', this.columns);
  }
  // end upload data //

  async deleteData(datas: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks
      });
      const response = await instance.delete('/DeleteDetail/DeleteProcessCell/' + datas)
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
    const response = await axios.get(environment.apijks + '/Detail/ProcessCell', { headers: { Pragma: 'no-cache' } });
    return response.data;
  } catch (error) {
    console.error(error.stack);
  }
}

async function getDataCSV() {
  try {
    const response = await axios.get(environment.apijks + '/Upload/ProcessCell', { headers: { Pragma: 'no-cache' } });

    return response.data;
  } catch (error) {
    console.error(error.stack);
  }
}