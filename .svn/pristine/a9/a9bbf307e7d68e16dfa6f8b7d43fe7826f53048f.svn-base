import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
import { environment } from '../../../environments/environment';
import { ExportService } from '../../export.service';
import Swal from 'sweetalert2'
import { MatDatepickerInputEvent } from '@angular/material';
import { formatDate } from '@angular/common';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-setting-st-db',
  templateUrl: './setting-st-db.component.html',
  styleUrls: ['../../table/table.component.css']
})
export class SettingStDbComponent implements OnInit {
  userid: any;
  getDataNadams: any = [];
  getDataStandard: any = [];
  loading: boolean = false;
  loadingStandard: boolean = false;
  loadingEUC: boolean = false;

  getData: any = [];

  constructor(private exportService: ExportService) { }

  async ngOnInit() {
    this.userid = localStorage.getItem('userid');
    this.getDataNadams = await getDataNadams();
    this.getDataStandard = await getDataStandard();
  }

  fileNadams: any;
  fileNameNadams: any;
  @ViewChild('fileinput') fileinput: any;
  saveFileNadams(e: any) {
    this.fileNadams = e.target.files[0];
    this.fileNameNadams = e.target.files[0].name;
    console.log(this.fileNadams)
    console.log(this.fileNameNadams)
    // console.log(e.target.files[0].size)
    // console.log(e.target.files[0].type)
    // console.log(e.target.value);
  }
  uploadFileNadams() {
    if (this.fileNadams !== undefined) {
      let formData = new FormData();
      formData.append('file_form', this.fileNadams)
      formData.append('file_name', this.fileNameNadams)
      formData.append('update_by', this.userid)
      // console.log('formData', formData)

      this.UploadNadams(formData);
    }
  }
  async UploadNadams(formData: FormData) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'multipart/form-data',
          accept: '*/*'
        }
      });
      this.loading = true;
      const response = await instance.post('/Upload/UploadNadams', formData)
      console.log("UploadNadams: ", response);
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
      this.fileNadams = undefined;
      this.fileNameNadams = undefined;
      console.log(this.fileinput.nativeElement.files);

      const datas = { update_by: this.userid };
      calc_actual_output(datas)

      return response.data;
    } catch (error) {
      // console.log(error.response.status)
      // console.log('RES ERROR: ', error.response)
      this.loading = false;
      console.log(this.fileinput.nativeElement.files);
      this.fileinput.nativeElement.value = "";
      this.fileNadams = undefined;
      this.fileNameNadams = undefined;
      console.log(this.fileinput.nativeElement.files);

      console.log('RES ERROR: ', error.response);
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data + " : กรุณาตรวจสอบข้อมูลของไฟล์"
      })
    }
  }

  fileStandard: any;
  fileNameStandard: any;
  @ViewChild('fileinputST') fileinputST: any;
  saveFileStandard(e: any) {
    this.fileStandard = e.target.files[0];
    this.fileNameStandard = e.target.files[0].name;
    console.log(this.fileStandard)
    console.log(this.fileNameStandard)
  }
  uploadFileStandard() {
    if (this.fileStandard !== undefined) {
      let formData = new FormData();
      formData.append('file_form', this.fileStandard)
      formData.append('file_name', this.fileNameStandard)
      formData.append('update_by', this.userid)
      this.UploadStandard(formData);
    }
  }
  async UploadStandard(formData: FormData) {

    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'multipart/form-data',
          accept: '*/*'
        }
      });
      this.loadingStandard = true;
      const response = await instance.post('/Upload/UploadStandard', formData)
      console.log("UploadStandard: ", response);
      this.loadingStandard = false;

      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: 'อัปโหลดไฟล์เสร็จเรียบร้อย.',
        showConfirmButton: false,
        timer: 1500
      })
      console.log(this.fileinputST.nativeElement.files);
      this.fileinputST.nativeElement.value = "";
      this.fileStandard = undefined;
      this.fileNameStandard = undefined;
      console.log(this.fileinputST.nativeElement.files);

      return response.data;
    } catch (error) {
      console.log(error.response.status)
      console.log('RES ERROR: ', error.response)
      this.loadingStandard = false;

      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data + ' : กรุณาตรวจสอบข้อมูลของไฟล์'
      })
    }

  }

  columns: any = [];
  exportNadams(): void {
    let element = this.getDataNadams;
    this.columns = ['date_time', 'body_no', 'model', 'mercury', 'shift', 'cell', 'qt_num', 'qt_in_pallet', 'status', 'pallet_no', 'carton_no'];
    this.exportService.exportToCsv(element, 'FormatNadams', this.columns);
  }

  exportStandard(): void {
    let element = this.getDataStandard;
    this.columns = ['model', 'mercury', 'type', 'reader', 'process_name', 'process_qty', 'cell'];
    this.exportService.exportToCsv(element, 'FormatStandard', this.columns);
  }

  apiDatestart: any;
  events: string = "";
  date = new FormControl(new Date());
  startEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.events = `${event.value}`;
    this.apiDatestart = formatDate(this.events, 'yyyy-MM-dd', 'en-US');
    console.log(this.apiDatestart);
  }

  async search() {
    const today = new Date();
    const dd = ("0" + today.getDate()).slice(-2);
    const mm = ("0" + (today.getMonth() + 1)).slice(-2);
    const yyyy = today.getFullYear();
    if (this.apiDatestart === undefined) {
      this.apiDatestart = yyyy + "-" + mm + "-" + dd;
    }
    const datas = {
      "update_by": this.userid,
      "submit": "no",
      "date_start": this.apiDatestart
    }
    this.getData = await calc_actual_manual(datas);
  }

  async submitcalc() {
    const today = new Date();
    const dd = ("0" + today.getDate()).slice(-2);
    const mm = ("0" + (today.getMonth() + 1)).slice(-2);
    const yyyy = today.getFullYear();
    if (this.apiDatestart === undefined) {
      this.apiDatestart = yyyy + "-" + mm + "-" + dd;
    }
    const datas = {
      "update_by": this.userid,
      "submit": "yes",
      "date_start": this.apiDatestart
    }
    this.getData = await calc_actual_manual(datas);
  }

  async connectEUC() {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json-patch+json', accept: '*/*'
        }
      });
  
      this.loadingEUC = true;
      const response = await instance.post('/Upload/UploadEUC')
      console.log("UploadEUC: ", response);
      this.loadingEUC = false;
  
      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: 'อัปเดตข้อมูล EUC เรียบร้อย.',
        showConfirmButton: false,
        timer: 1500
      })
  
      return response;
    } catch (error) {
      console.log('RES ERROR: ', error);
      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data + " : กรุณาติดต่อ Admin ICD"
      })
    }
  }
}

async function getDataNadams() {
  try {
    const response = await axios.get(environment.apijks + '/Upload/NadamsFormat', { headers: { Pragma: 'no-cache' } });
    return response.data;
  } catch (error) {
    console.error(error.stack);
  }
}

async function getDataStandard() {
  try {
    const response = await axios.get(environment.apijks + '/Upload/StandardFormat', { headers: { Pragma: 'no-cache' } });
    return response.data;
  } catch (error) {
    console.error(error.stack);
  }
}

async function calc_actual_output(datas: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json-patch+json', accept: '*/*'
      }
    });

    console.log(datas);

    const response = await instance.post('/Calc/calc_actual_output', datas)
    console.log("calc_actual_output: ", response);

    return response.data;
  } catch (error) {
    console.log('RES ERROR: ', error.response);
    Swal.fire({
      icon: 'error',
      title: error.response.status,
      text: error.response.data + " : กรุณาติดต่อ Admin ICD"
    })
  }
}

async function calc_actual_manual(datas: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json-patch+json', accept: '*/*'
      }
    });

    console.log(datas);

    const response = await instance.post('/Calc/calc_actual_manual', datas)
    console.log("calc_actual_manual: ", response);
    console.log(": ", response.data);

    return response.data;
  } catch (error) {
    console.log('RES ERROR: ', error.response);
    Swal.fire({
      icon: 'error',
      title: error.response.status,
      text: error.response.data + " : กรุณาติดต่อ Admin ICD"
    })
  }
}
