import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Service
import { ServiceSettingService } from '../../service-setting.service';
import { environment } from '.../../environments/environment';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-dialog-cell',
  templateUrl: './dialog-cell.component.html'
})
export class DialogCellComponent implements OnInit {
  items: any;
  headers: any;
  button: any;
  getData: any;

  @ViewChild('cell_code') cell_code: any;
  @ViewChild('cell_detail') cell_detail: any;

  constructor(
    private serviceSettingService: ServiceSettingService
  ) {

  }

  submit(button: any, datas: any) {
    if (this.cell_detail.nativeElement.value != "") {
      if (button == "Add") {
        const a = {
          cell_detail: this.cell_detail.nativeElement.value,
          update_by: this.userid
        };
        addData(a);
      } else {
        const d = {
          cell_code: datas.cell_code,
          cell_detail: datas.cell_detail,
          update_by: this.userid
        };
        editData(d);
      }
    }
  }
  userid:any;
  ngOnInit(): void {
    this.items = this.serviceSettingService.getItems();
    this.userid = localStorage.getItem('userid');
    if (this.items == "Add") {
      this.headers = "Add Data";
      this.button = "Add";
    } else {
      this.headers = "Edit Data";
      this.button = "Edit";
    }
  }
  ngOnDestroy() {
    this.items = this.serviceSettingService.clearItems();
  }

}

async function addData(datas: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json'
      }
    });
    const response = await instance.post('/AddMaster/AddCellName', datas)

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'บันทึกข้อมูลเสร็จเรียบร้อยแล้ว.',
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

async function editData(datas: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json'
      }
    });
    const response = await instance.put('/EditMaster/UpdateCellName/' + datas.cell_code, datas)

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'แก้ไขข้อมูลเสร็จเรียบร้อย.',
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
