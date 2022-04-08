import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Service
import { ServiceSettingService } from '../../service-setting.service';
import { environment } from '.../../environments/environment';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-dialog-gobal-cell',
  templateUrl: './dialog-gobal-cell.component.html'
})
export class DialogGobalCellComponent implements OnInit {
  items: any;
  headers: any;
  button: any;
  getData: any;

  @ViewChild('gb_cell_code') gb_cell_code: any;
  @ViewChild('gb_cell_detail') gb_cell_detail: any;

  constructor(
    private serviceSettingService: ServiceSettingService
  ) {

  }

  submit(button: any, datas: any) {
    if (this.gb_cell_code.nativeElement.value != "" && this.gb_cell_detail.nativeElement.value != "") {
      if (button == "Add") {
        const a = {
          gb_cell_code: this.gb_cell_code.nativeElement.value,
          gb_cell_detail: this.gb_cell_detail.nativeElement.value,
          update_by: this.userid
        };

        addData(a);
      } else {
        const d = {
          gb_cell_code: datas.gb_cell_code,
          gb_cell_detail: datas.gb_cell_detail,
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
    const response = await instance.post('/AddMaster/AddGbCellCode', datas)

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
    const response = await instance.put('/EditMaster/UpdateGbCellCode/' + datas.gb_cell_code, datas)

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
