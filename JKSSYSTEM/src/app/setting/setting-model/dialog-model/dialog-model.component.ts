import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Service
import { ServiceSettingService } from '../../service-setting.service';
import { environment } from '.../../environments/environment';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-dialog-model',
  templateUrl: './dialog-model.component.html'
})
export class DialogModelComponent implements OnInit {
  items: any;
  headers: any;
  button: any;
  getData: any;

  @ViewChild('model_code') model_code: any;
  @ViewChild('model_detail') model_detail: any;
  @ViewChild('model_child') model_child: any;

  constructor(
    private serviceSettingService: ServiceSettingService
  ) {

  }

  submit(button: any, datas: any) {
    if (this.model_detail.nativeElement.value != "") {
      if (button == "Add") {
        console.log('data: ', datas)
        const a = {
          model_detail: this.model_detail.nativeElement.value,
          model_child: this.model_child.nativeElement.value,
          update_by: this.userid
        };
        addData(a);
      } else {
        const d = {
          model_code: datas.model_code,
          model_detail: datas.model_detail,
          model_child: datas.model_child,
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
    const response = await instance.post('/AddMaster/AddProductModel', datas)
    
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
    const response = await instance.put('/EditMaster/UpdateProductModel/' + datas.model_code, datas)

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