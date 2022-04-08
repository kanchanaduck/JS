import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Service
import { ServiceSettingService } from '../service-setting.service';
import { environment } from '.../../environments/environment';
@Component({
  selector: 'app-dialog-setting',
  templateUrl: './dialog-setting.component.html'
})
export class DialogSettingComponent implements OnInit {
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
    if (this.cell_code.nativeElement.value != "" && this.cell_detail.nativeElement.value != "") {
      if (button == "Add") {
        const a = {
          cell_code: this.cell_code.nativeElement.value,
          cell_detail: this.cell_detail.nativeElement.value
        };
        addData(a);
      } else {
        const d = {
          cell_code: datas.cell_code,
          cell_detail: datas.cell_detail
        };
        editData(d);
      }
    }
  }

  ngOnInit(): void {
    this.items = this.serviceSettingService.getItems();

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
    const response = await instance.post('/AddMaster/AddWorkCenter', datas)
    return response.data;
  } catch (error) {
    console.error(error);
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
    const response = await instance.put('/EditMaster/UpdateWorkCenter/' + datas.cell_code, datas)
    return response.data;
  } catch (error) {
    console.error(error);
  }
}