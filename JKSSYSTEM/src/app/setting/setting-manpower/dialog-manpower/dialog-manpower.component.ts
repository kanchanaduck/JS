import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { environment } from '../../../../environments/environment';
import axios from 'axios';
// Service
import { ServiceSettingService } from '../../../setting/service-setting.service';

import Swal from 'sweetalert2'

@Component({
  selector: 'app-dialog-manpower',
  templateUrl: './dialog-manpower.component.html',
  styleUrls: ['../../../home/home.component.css']
})
export class DialogManpowerComponent implements OnInit {
  userid: any;
  items: any;
  headers: any;
  button: any;
  getData: any;

  constructor(
    private serviceSettingService: ServiceSettingService
  ) { }

  wcControl = new FormControl('', Validators.required);
  wc: any = [];
  async getWC() {
    try {
      const response = await axios.get(environment.apijks + '/Master/WorkCenter', { headers: { Pragma: 'no-cache' } });
      this.wc = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_wc: any;
  fn_wc(event: any) {
    this.sh_wc = {
      value: event.value,
      text: event.source.triggerValue
    };
    this.getMODEL(this.sh_wc.text);
  }

  modelControl = new FormControl('', Validators.required);
  models: any = [];
  async getMODEL(id: any) {
    try {
      const response = await axios.get(environment.apijks + '/Detail/WorkcenterModel/' + id, { headers: { Pragma: 'no-cache' } });
      this.models = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_model: any;
  fn_model(event: any) {
    this.sh_model = {
      value: event.value,
      text: event.source.triggerValue
    };
    this.getPROCESS(this.sh_model.text);
  }

  processControl = new FormControl('', Validators.required);
  process: any = [];
  async getPROCESS(id: any) {
    try {
      const response = await axios.get(environment.apijks + '/Detail/ModelProcess/' + id, { headers: { Pragma: 'no-cache' } });
      this.process = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_process: any;
  fn_process(event: any) {
    this.sh_process = {
      value: event.value,
      text: event.source.triggerValue
    };
    this.getCell(this.sh_process.text);
  }

  cellControl = new FormControl('', Validators.required);
  cell: any = [];
  async getCell(id: any) {
    try {
      const response = await axios.get(environment.apijks + '/Detail/ProcessCell/' + id, { headers: { Pragma: 'no-cache' } });
      this.cell = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_cell: any;
  fn_cell(event: any) {
    this.sh_cell = {
      value: event.value,
      text: event.source.triggerValue
    };
    this.getblockshift(this.sh_cell.text);
  }

  blockshiftControl = new FormControl('', Validators.required);
  blockshift: any = [];
  async getblockshift(id: any) {
    try {
      const response = await axios.get(environment.apijks + '/Detail/CellShift/' + id, { headers: { Pragma: 'no-cache' } });
      this.blockshift = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_shift: any;
  fn_shift(event: any) {
    this.sh_shift = {
      value: event.value,
      text: event.source.triggerValue
    };
  }

  block_GControl = new FormControl('', Validators.required);
  block_G: any = [];
  async getBlock_G() {
    try {
      const response = await axios.get(environment.apijks + '/Master/BlockGroup', { headers: { Pragma: 'no-cache' } });
      this.block_G = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_block_G: any;
  fn_block_G(event: any) {
    this.sh_block_G = {
      value: event.value,
      text: event.source.triggerValue
    };
    console.log(this.sh_block_G);
  }

  gobal_cellControl = new FormControl('', Validators.required);
  gobal_cell: any = [];
  async getGobal_cell() {
    try {
      const response = await axios.get(environment.apijks + '/Master/GbCellCode', { headers: { Pragma: 'no-cache' } });
      this.gobal_cell = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_gobal_cell: any;
  fn_gobal_cell(event: any) {
    this.sh_gobal_cell = {
      value: event.value,
      text: event.source.triggerValue
    };
    console.log(this.sh_gobal_cell);
  }

  @ViewChild('txtid') txtid: any;
  @ViewChild('txtcategory') txtcategory: any;
  @ViewChild('txtmanpower') txtmanpower: any;
  @ViewChild('txtone') txtone: any;
  @ViewChild('txtfive') txtfive: any;

  submit(button: any, datas: any) {
    if (button == "Add") {
      const a = {
        "wc_code": this.sh_wc.value,
        "model_code": this.sh_model.value,
        "process_code": this.sh_process.value,
        "cell_code": this.sh_cell.value,
        // "category": parseInt(this.txtcategory.nativeElement.value),
        "shift_code": this.sh_shift.value,
        "manpower": parseInt(this.txtmanpower.nativeElement.value),
        "op_meister": parseInt(this.txtone.nativeElement.value),
        "sp_meister": parseInt(this.txtfive.nativeElement.value),
        "update_by": this.userid,
        "block_group_code": this.sh_block_G.value,
        "gb_cell_code": this.sh_gobal_cell.value
      };
      console.log(a);
      addData(a);
    } else {
      this.getWC();
      this.getMODEL(this.items[0].wc_detail);
      this.getPROCESS(this.items[0].model_detail);
      this.getCell(this.items[0].process_detail);
      this.getblockshift(this.items[0].cell_detail);

      if (this.sh_wc === undefined || this.sh_wc.text === undefined) {
        this.sh_wc = this.items[0].wc_code;
      } else {
        this.sh_wc = this.sh_wc.value;
      }

      if (this.sh_model === undefined || this.sh_model.text === undefined) {
        this.sh_model = this.items[0].model_code;
      } else {
        this.sh_model = this.sh_model.value;
      }

      if (this.sh_process === undefined || this.sh_process.text === undefined) {
        this.sh_process = this.items[0].process_code;
      } else {
        this.sh_process = this.sh_process.value;
      }

      if (this.sh_cell === undefined || this.sh_cell.text === undefined) {
        this.sh_cell = this.items[0].cell_code;
      } else {
        this.sh_cell = this.sh_cell.value;
      }

      if (this.sh_shift === undefined || this.sh_shift.text === undefined) {
        this.sh_shift = this.items[0].shift_code;
      } else {
        this.sh_shift = this.sh_shift.value;
      }

      if (this.sh_block_G === undefined || this.sh_block_G.text === undefined) {
        this.sh_block_G = this.items[0].block_group_code;
      } else {
        this.sh_block_G = this.sh_block_G.value;
      }

      if (this.sh_gobal_cell === undefined || this.sh_gobal_cell.text === undefined) {
        this.sh_gobal_cell = this.items[0].gb_cell_code;
      } else {
        this.sh_gobal_cell = this.sh_gobal_cell.value;
      }

      const d = {
        "wc_code": this.sh_wc,
        "model_code": this.sh_model,
        "process_code": this.sh_process,
        "cell_code": this.sh_cell,
        // "category": parseInt(this.txtcategory.nativeElement.value),
        "shift_code": this.sh_shift,
        "manpower": parseInt(this.txtmanpower.nativeElement.value),
        "op_meister": parseInt(this.txtone.nativeElement.value),
        "sp_meister": parseInt(this.txtfive.nativeElement.value),
        "update_by": this.userid,
        "block_group_code": this.sh_block_G,
        "gb_cell_code": this.sh_gobal_cell
      };
      editData(d, this.txtid.nativeElement.value);
    }
  }

  async ngOnInit() {
    this.userid = localStorage.getItem('userid');
    this.items = this.serviceSettingService.getItems();

    if (this.items == "Add") {
      this.headers = "Add Data";
      this.button = "Add";
    } else {
      this.headers = "Edit Data";
      this.button = "Edit";
    }

    this.getWC();
    this.getMODEL(this.items[0].wc_detail);
    this.getPROCESS(this.items[0].model_detail);
    this.getCell(this.items[0].process_detail);
    this.getblockshift(this.items[0].cell_detail);
    this.getBlock_G();
    this.getGobal_cell();

    this.wcControl.setValue(this.items[0].wc_code);
    this.modelControl.setValue(this.items[0].model_code);
    this.processControl.setValue(this.items[0].process_code);
    this.cellControl.setValue(this.items[0].cell_code);
    this.blockshiftControl.setValue(this.items[0].shift_code);

    this.block_GControl.setValue(this.items[0].block_group_code);
    this.gobal_cellControl.setValue(this.items[0].gb_cell_code);
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
    const response = await instance.post('/AddDetail/AddManpower', datas);
    console.log('response: ', response);

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
    console.log('RES ERROR: ', error.response);

    Swal.fire({
      icon: 'error',
      title: error.response.status,
      text: error.response.data
    })
  }
}

async function editData(datas: any, id: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json'
      }
    });
    const response = await instance.put('/EditDetail/UpdateManpower/' + id, datas)

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