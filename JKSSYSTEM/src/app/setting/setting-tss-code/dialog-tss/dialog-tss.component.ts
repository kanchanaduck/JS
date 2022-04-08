import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Service
import { ServiceSettingService } from '../../service-setting.service';
import { environment } from '.../../environments/environment';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-dialog-tss',
  templateUrl: './dialog-tss.component.html'
})
export class DialogTssComponent implements OnInit {
  items: any;
  headers: any;
  button: any;
  getData: any;

  @ViewChild('tss_code') tss_code: any;
  @ViewChild('tss_detail') tss_detail: any;

  constructor(
    private serviceSettingService: ServiceSettingService
  ) {

  }

  submit(button: any, datas: any) {
    if (this.tss_code.nativeElement.value != "" && this.tss_detail.nativeElement.value != "") {
      if (button == "Add") {
        const a = {
          tss_code: this.tss_code.nativeElement.value,
          tss_detail: this.tss_detail.nativeElement.value,
          cal_qty: this.isCheckQty,
          cal_extrawork: this.isCheckExtrawork,
          cal_jobspecial:this.isCheckJobspecial,
          update_by: this.userid
        };
        // console.log(a);
        addData(a);
      } else {
        const d = {
          tss_code: datas.tss_code,
          tss_detail: datas.tss_detail,
          cal_qty: this.isCheckQty,
          cal_extrawork: this.isCheckExtrawork,
          cal_jobspecial:this.isCheckJobspecial,
          update_by: this.userid
        };
        // console.log(d);
        editData(d);
      }
    }
  }
  userid: any;
  ngOnInit(): void {
    this.items = this.serviceSettingService.getItems();
    this.userid = localStorage.getItem('userid');
    if (this.items == "Add") {
      this.headers = "Add Data";
      this.button = "Add";
    } else {
      this.headers = "Edit Data";
      this.button = "Edit";

      this.isCheckQty = this.items[0].cal_qty;
      this.isCheckExtrawork = this.items[0].cal_extrawork;
      this.isCheckJobspecial = this.items[0].cal_jobspecial;
      console.log(this.items[0].cal_qty);
      console.log(this.isCheckQty);
    }

  }
  ngOnDestroy() {
    this.items = this.serviceSettingService.clearItems();
  }

  isCheckQty: boolean = false;
  onToggleQty(e: any) {
    this.isCheckQty = e.checked
  }
  isCheckExtrawork: boolean = false;
  onToggleExtrawork(e: any) {
    this.isCheckExtrawork = e.checked
  }
  isCheckJobspecial: boolean = false;
  onToggleJobspecial(e: any) {
    this.isCheckJobspecial = e.checked;
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
    const response = await instance.post('/AddMaster/AddTss', datas)

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
    const response = await instance.put('/EditMaster/UpdateTss/' + datas.tss_code, datas)

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
