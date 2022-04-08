import { Component, Input, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Table
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
// Dialog
import { MatDialog } from '@angular/material/dialog';
import { DialogUserprofileComponent } from '../user-profile/dialog-userprofile/dialog-userprofile.component';
// Service
import { ServiceJksService } from '../service-jks.service';
import Swal from 'sweetalert2'
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['../table/table.component.css']
})
export class UserProfileComponent implements OnInit {

  displayedColumns: string[] = ['action', 'fname', 'lname', 'userid', 'password', 'userright', 'statusactive'];
  dataSource: any;
  getData: any = [];
  getDataCSV: any = [];
  loading: boolean = false;

  constructor(
    private serviceJksService: ServiceJksService,
    public dialog: MatDialog
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
    this.serviceJksService.user_profile(data);  // ส่งค่า row ไปที่ fn addToData

    const dialogRef = this.dialog.open
      (DialogUserprofileComponent, {
        width: '80%',
        data: { data: data }
      });

    dialogRef.afterClosed().subscribe(async result => {
      console.log("getData");
      this.getData = await getData();
      this.dataSource.data = await this.getData;
    });
  }
  openDialogDelete(data: any) {
    Swal.fire({
      title: 'คุณต้องการลบข้อมูลใช่หรือไม่',
      text: 'delete : ' + data.fname,
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
  }

  async deleteData(datas: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks
      });
      const response = await instance.delete('Account/DeleteData/' + datas)

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
    const response = await axios.get(environment.apijks + '/Account/Getdata', { headers: { Pragma: 'no-cache' } });

    return response.data;
  } catch (error) {
    console.error(error.stack);
  }
}

