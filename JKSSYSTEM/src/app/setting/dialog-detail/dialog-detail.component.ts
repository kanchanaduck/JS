import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Service
import { ServiceSettingService } from '../service-setting.service';
import { environment } from '.../../environments/environment';
import { FormControl, Validators } from '@angular/forms';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-dialog-detail',
  templateUrl: './dialog-detail.component.html'
})
export class DialogDetailComponent implements OnInit {
  items: any;
  headers: any;
  button: any;
  page: any;

  @ViewChild('txtidwc') txtidwc: any;
  @ViewChild('txtidmodel') txtidmodel: any;
  @ViewChild('txtidpro') txtidpro: any;
  @ViewChild('txtidcell') txtidcell: any;

  constructor(
    private serviceSettingService: ServiceSettingService
  ) {
  }

  wcControl = new FormControl('', Validators.required);
  wc: any = [];
  async getWC() {
    try {
      const response = await axios.get(environment.apijks + '/Master/WorkCenter');
      this.wc = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }

  modelControl = new FormControl('', Validators.required);
  model: any = [];
  async getModel() {
    try {
      const response = await axios.get(environment.apijks + '/Master/ProductModel');
      this.model = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }

  processControl = new FormControl('', Validators.required);
  process: any = [];
  async getprocess() {
    try {
      const response = await axios.get(environment.apijks + '/Master/ProcessName');
      this.process = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }

  cellControl = new FormControl('', Validators.required);
  cell: any = [];
  async getcell() {
    try {
      const response = await axios.get(environment.apijks + '/Master/CellName');
      this.cell = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }

  blockshiftControl = new FormControl('', Validators.required);
  blockshift: any = [];
  async getblockshift() {
    try {
      const response = await axios.get(environment.apijks + '/Master/BlockShift');
      this.blockshift = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }

  sh_wc: any;
  selectChang_wc(event: any) {
    this.sh_wc = {
      value: event.value,
      text: event.source.triggerValue
    };
  }

  sh_model: any;
  selectChang_model(event: any) {
    this.sh_model = {
      value: event.value,
      text: event.source.triggerValue
    };
  }

  sh_process: any;
  selectChang_process(event: any) {
    this.sh_process = {
      value: event.value,
      text: event.source.triggerValue
    };
  }

  sh_cell: any;
  selectChang_cell(event: any) {
    this.sh_cell = {
      value: event.value,
      text: event.source.triggerValue
    };
  }

  sh_blockshift: any;
  selectChang_blockshift(event: any) {
    this.sh_blockshift = {
      value: event.value,
      text: event.source.triggerValue
    };
  }

  submitWC(button: any, page: any) {
    if (button == "Add") {
      const a = {
        wC_CODE: this.sh_wc.value,
        modeL_CODE: this.sh_model.value,
        update_by: this.userid
      };
      addData(a, page);
    } else {
      if (this.sh_wc === undefined || this.sh_wc.value === undefined) {
        this.sh_wc = this.items[0].wc_code;
      } else {
        this.sh_wc = this.sh_wc.value;
      }

      if (this.sh_model === undefined || this.sh_model.value === undefined) {
        this.sh_model = this.items[0].model_code;
      } else {
        this.sh_model = this.sh_model.value;
      }

      const d = {
        wC_CODE: this.sh_wc,
        modeL_CODE: this.sh_model,
        update_by: this.userid
      };
      editData(d, page, this.txtidwc.nativeElement.value);
    }
  }

  submitModel(button: any, page: any) { 
    if (button == "Add") {
      const a = {
        modeL_CODE: this.sh_model.value,
        procesS_CODE: this.sh_process.value,
        update_by: this.userid
      };
      addData(a, page);
    } else {
      
      if (this.sh_model === undefined || this.sh_model.value === undefined) {
        this.sh_model = this.items[0].model_code;
      } else {
        this.sh_model = this.sh_model.value;
      }

      if (this.sh_process === undefined || this.sh_process.value === undefined) {
        this.sh_process = this.items[0].process_code;
      } else {
        this.sh_process = this.sh_process.value;
      }

      const d = {
        modeL_CODE: this.sh_model,
        procesS_CODE: this.sh_process,
        update_by: this.userid
      };
      editData(d, page, this.txtidmodel.nativeElement.value);
    }
  }
  submitProcess(button: any, page: any) { 
    if (button == "Add") {
      const a = {
        procesS_CODE: this.sh_process.value,
        celL_CODE: this.sh_cell.value,
        update_by: this.userid
      };
      addData(a, page);
    } else {
      
      if (this.sh_process === undefined || this.sh_process.value === undefined) {
        this.sh_process = this.items[0].process_code;
      } else {
        this.sh_process = this.sh_process.value;
      }

      if (this.sh_cell === undefined || this.sh_cell.value === undefined) {
        this.sh_cell = this.items[0].cell_code;
      } else {
        this.sh_cell = this.sh_cell.value;
      }

      const d = {
        procesS_CODE: this.sh_process,
        celL_CODE: this.sh_cell,
        update_by: this.userid
      };
      editData(d, page, this.txtidpro.nativeElement.value);
    }
  }
  submitCell(button: any, page: any) { 
    if (button == "Add") {
      const a = {
        celL_CODE: this.sh_cell.value,
        shifT_CODE: this.sh_blockshift.value,
        update_by: this.userid
      };
      addData(a, page);
    } else {
      
      if (this.sh_cell === undefined || this.sh_cell.value === undefined) {
        this.sh_cell = this.items[0].cell_code;
      } else {
        this.sh_cell = this.sh_cell.value;
      }

      if (this.sh_blockshift === undefined || this.sh_blockshift.value === undefined) {
        this.sh_blockshift = this.items[0].shift_code;
      } else {
        this.sh_blockshift = this.sh_blockshift.value;
      }

      const d = {
        celL_CODE: this.sh_cell,
        shifT_CODE: this.sh_blockshift,
        update_by: this.userid
      };
      editData(d, page, this.txtidcell.nativeElement.value);
    }
  }
  userid:any;
  ngOnInit(): void {
    this.getWC();
    this.getModel();
    this.getprocess();
    this.getcell();
    this.getblockshift();

    this.items = this.serviceSettingService.getItems();
    this.page = this.serviceSettingService.getdialog_detail();
    this.userid = localStorage.getItem('userid');

    if (this.items == "Add") {
      this.headers = "Add Data";
      this.button = "Add";
    } else {
      this.headers = "Edit Data";
      this.button = "Edit";

      this.wcControl.setValue(this.items[0].wc_code);
      this.modelControl.setValue(this.items[0].model_code);
      this.processControl.setValue(this.items[0].process_code);
      this.cellControl.setValue(this.items[0].cell_code);
      this.blockshiftControl.setValue(this.items[0].shift_code);
    }
  }

  ngOnDestroy() {
    this.items = this.serviceSettingService.clearItems();
    this.page = this.serviceSettingService.cleardialog_detail();
  }

}

async function addData(datas: any, page: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json'
      }
    });
    let data;

    if (page == "WC") {
      data = await instance.post('/AddDetail/AddWorkcenterModel', datas)
    }else if(page == "Model"){
      data = await instance.post('/AddDetail/AddModelProcess', datas)
    }else if(page == "Process"){
      data = await instance.post('/AddDetail/AddProcessCell', datas)
    }else if(page == "Cell"){
      data = await instance.post('/AddDetail/AddCellShift', datas)
    }
    
    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'บันทึกข้อมูลเสร็จเรียบร้อยแล้ว.',
      showConfirmButton: false,
      timer: 1500
    })

    return data;
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

async function editData(datas: any, page: any, id: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json'
      }
    });
    let data;
    if (page == "WC") {
      data = await instance.put('/EditDetail/UpdateWorkcenterModel/' + id, datas)
    }else if(page== "Model"){
      data = await instance.put('/EditDetail/UpdateModelProcess/' + id, datas)
    }else if(page== "Process"){
      data = await instance.put('/EditDetail/UpdateProcessCell/' + id, datas)
    }else if(page== "Cell"){
      data = await instance.put('/EditDetail/UpdateCellShift/' + id, datas)
    }

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'แก้ไขข้อมูลเสร็จเรียบร้อย.',
      showConfirmButton: false,
      timer: 1500
    })
    
    return data;
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
