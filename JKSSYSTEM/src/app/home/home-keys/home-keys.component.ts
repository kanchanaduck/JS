import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import axios from 'axios';
import { ServiceJksService } from '../../service-jks.service';
import Swal from 'sweetalert2'
import { MatDatepickerInputEvent } from '@angular/material';
import { formatDate } from '@angular/common';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { connectableObservableDescriptor } from 'rxjs/internal/observable/ConnectableObservable';

interface controls {
  name: string;
  value: string;
}

@Component({
  selector: 'app-home-keys',
  templateUrl: './home-keys.component.html',
  styleUrls: ['../home.component.css']
})
export class HomeKeysComponent implements OnInit {
  get_service: any = [];
  get_service_search: any = [];
  serv: any = [];
  v_extrawork: number = 0; v_jobspecial: number = 0; v_total_extrajob: number = 0;
  class_danger: any;
  manpower_op: string = ""; manpower_sp: string = "";
  manpower_base: string = "";
  attendance: number = 0; attendance_sp: number = 0; //PLE
  absent: number = 0; absent_sp: number = 0; //PLE
  working_time_total: number = 0; working_time_total_op_sp: number = 0;   //PLE
  @ViewChild('txtAbsent') txtAbsent: any; @ViewChild('txtAbsent_sp') txtAbsent_sp: any; //PLE
  @ViewChild('txtactual_output') txtactual_output: any;
  v_actual_output: number = 0;
  @ViewChild('txtreject_off') txtreject_off: any;
  @ViewChild('txtworking_time') txtworking_time: any;
  @ViewChild('txtcomment') txtcomment: any;
  overtime_01: number = 0; overtime_01_op: number = 0; overtime_01_sp: number = 0;  // overtime_01 คือ OP + SP
  overtime_02: number = 0; overtime_02_op: number = 0; overtime_02_sp: number = 0;  // overtime_02 คือ OP + SP
  overtime_03: number = 0; overtime_03_op: number = 0; overtime_03_sp: number = 0;  // overtime_03 คือ OP + SP
  overtime_04: number = 0; overtime_04_op: number = 0; overtime_04_sp: number = 0;  // overtime_04 คือ OP + SP
  v_getovertime: any = [];
  v_actual: number = 0; v_actual_op_sp: number = 0;
  v_totallosstime: number = 0;
  v_standardtime: any = 0; v_standardtime_op_sp: any = 0;
  v_totaltime: number = 0; v_totaltime_op_sp: number = 0;
  v_detail: number = 0; v_detail_op_sp: number = 0;
  v_unknown: number = 0; v_unknown_op_sp: number = 0;
  v_worker_performance: any = 0; v_worker_performance_op_sp: any = 0;
  v_operation_rate: any = 0; v_operation_rate_op_sp: any = 0;
  v_total_performance: any = 0; v_total_performance_op_sp: any = 0;
  dp_ps: any;
  dp_bg: any;
  dp_gc: any;
  manpower_absent: any; manpower_absent_sp: any; //PLE

  constructor(
    private httpService: HttpClient,
    private ServiceJksService: ServiceJksService) {
  }

  date = new FormControl(new Date());
  events: string = "";
  apiDate: any;
  addEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.events = `${event.value}`;
    this.apiDate = formatDate(this.events, 'yyyy-MM-dd', 'en-US');
    //console.log(this.apiDate);
    this.datamanpower();
  }

  wcControl = new FormControl('', Validators.required);
  wc: any = [];
  getWC() {
    try {
      this.httpService.get(environment.apijks + '/Master/WorkCenter', { headers: { Pragma: 'no-cache' } }).subscribe(
        data => {
          this.wc = data as string[];
        }
      );
    } catch (err) {
      console.log('ERROR WC: ', err.stack)
    }
  }
  sh_wc: any;
  fn_wc(event: any) {
    this.sh_wc = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_wc);
    this.getMODEL(this.sh_wc.text);
    this.datamanpower();
  }

  modelControl = new FormControl('', Validators.required);
  models: any = [];
  getMODEL(id: any) {
    this.httpService.get(environment.apijks + '/Detail/WorkcenterModel/' + id, { headers: { Pragma: 'no-cache' } }).subscribe(
      data => {
        this.models = data as string[];
      }
    );
  }
  sh_model: any;
  fn_model(event: any) {
    this.sh_model = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_model);
    this.getPROCESS(this.sh_model.text);
    this.datamanpower();
  }

  processControl = new FormControl('', Validators.required);
  process: any = [];
  getPROCESS(id: any) {
    this.httpService.get(environment.apijks + '/Detail/ModelProcess/' + id, { headers: { Pragma: 'no-cache' } }).subscribe(
      data => {
        this.process = data as string[];
      }
    );
  }
  sh_process: any;
  fn_process(event: any) {
    this.sh_process = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_process);
    this.getCell(this.sh_process.text);
    this.datamanpower();
  }

  cellControl = new FormControl('', Validators.required);
  cell: any = [];
  async getCell(id: any) {
    try {
      const response = await axios.get(environment.apijks + '/Detail/ProcessCell/' + id, { headers: { Pragma: 'no-cache' } });
      this.cell = response.data;
    } catch (error) {
      // console.error(error.stack);
    }
  }
  sh_cell: any;
  fn_cell(event: any) {
    this.sh_cell = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_cell);
    this.getblockshift(this.sh_cell.text);
    this.datamanpower();
  }

  blockshiftControl = new FormControl('', Validators.required);
  blockshift: any = [];
  async getblockshift(id: any) {
    try {
      const response = await axios.get(environment.apijks + '/Detail/CellShift/' + id, { headers: { Pragma: 'no-cache' } });
      this.blockshift = response.data;
    } catch (error) {
      // console.error(error.stack);
    }
  }
  sh_shift: any;
  fn_shift(event: any) {
    this.sh_shift = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_shift);
    this.datamanpower();
  }
  async getManpower(datas: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      const response = await instance.post('/Detail/Manpower/Search', datas)
      // console.log("getManpower: ", response);
      if (response.data.length > 0) {
        this.manpower_op = response.data[0].op_meister;
        this.manpower_sp = response.data[0].sp_meister;
        this.manpower_base = response.data[0].manpower;
        this.class_danger = ""
        // console.log('manpower: ', response.data[0].manpower);
        // console.log('absent: ', this.absent);

        // this.working_time_total = ((parseInt(this.manpower_base) * 480) - (this.absent * 480));  // old

        this.block_GControl.setValue(response.data[0].block_group_code);
        this.gobal_cellControl.setValue(response.data[0].gb_cell_code);
        // console.log(this.block_GControl.value);
        // console.log(this.gobal_cellControl.value);

        await this.datasNadams();
      } else {
        this.manpower_op = "Please check data";
        this.manpower_sp = "Please check data";
        this.manpower_base = "Please check data";
        this.class_danger = "text-danger";
        this.working_time_total = 0;
        this.working_time_total_op_sp = 0;   //PLE
      }

      return response.data;
    } catch (error) {
      // console.log(error.stack)
      // console.log('RES ERROR: ', error.response)

      // Swal.fire({
      //   icon: 'error',
      //   title: error.response.status,
      //   text: error.response.data
      // })
    }
  }

  onKeyAbsent(event: any) {
    if (!isNaN(parseInt(event.target.value))) {
      this.absent = parseInt(event.target.value)
      this.manpower_base = ((parseInt(this.manpower_op) + parseInt(this.manpower_sp)) - eval(eval(event.target.value) + this.absent_sp)).toString();
      this.attendance = parseInt(this.manpower_op) - parseInt(event.target.value);  // this.attendance = parseInt(this.manpower_base) - parseInt(event.target.value);   //cal old
      // this.working_time_total = ((parseInt(this.manpower_base) * 480) - (parseInt(this.txtAbsent.nativeElement.value) * 480));   //cal old
      let cal_op = this.fnCalOP();
      console.log(this.attendance);
      console.log(cal_op);
      this.working_time_total = ((this.attendance + cal_op) * 480);
      //this.working_time_total = ((this.attendance * 480) - (cal_op * 480));
    } else {
      this.absent = 0;
      this.manpower_base = ((parseInt(this.manpower_op) + parseInt(this.manpower_sp)) - eval(eval("0") + this.absent_sp)).toString();
      // console.log("onKeyAbsent: ",event.target.value);
      this.attendance = parseInt(this.manpower_op) - 0;   // this.attendance = parseInt(this.manpower_base) - 0;  //cal old
      this.txtAbsent.nativeElement.value = "";
      this.working_time_total = 0;
    }
  }
  fnCalOP() {
    let cal_op = 0;
    if ((this.attendance_sp - this.absent) <= 0) {
      //cal_op = this.attendance_sp;
      cal_op = this.absent_sp;
    } else if ((this.attendance_sp - this.absent) == this.attendance_sp) {
      cal_op = 0;
    } else if ((this.attendance_sp - this.absent) <= this.attendance_sp) {
      cal_op = this.absent;
    } else {
      cal_op = 0;
    }
    return cal_op;
  }

  onKeyAbsentSP(event: any) { //PLE
    if (!isNaN(parseInt(event.target.value))) {
      this.absent_sp = parseInt(event.target.value)
      this.manpower_base = ((parseInt(this.manpower_op) + parseInt(this.manpower_sp)) - eval(this.absent + eval(event.target.value))).toString();
      this.attendance_sp = parseInt(this.manpower_sp) - parseInt(event.target.value); // this.attendance_sp = parseInt(this.manpower_base) - parseInt(event.target.value);  // cal old
      let cal_op = this.fnCalOP();
      this.working_time_total = ((this.attendance + cal_op) * 480);
      let support_after = (this.attendance_sp - cal_op);
      this.working_time_total_op_sp = (support_after * 480);
    } else {
      this.absent_sp = 0;
      this.manpower_base = ((parseInt(this.manpower_op) + parseInt(this.manpower_sp)) - eval(this.absent + eval("0"))).toString();
      // console.log("onKeyAbsentSP: ",event.target.value);
      this.attendance_sp = parseInt(this.manpower_sp) - 0;  // this.attendance_sp = parseInt(this.manpower_base) - 0; // cal old
      this.txtAbsent_sp.nativeElement.value = "";
      this.working_time_total_op_sp = 0;
    }
  }

  psControl = new FormControl('', Validators.required);
  ps: controls[] = [
    { name: '1', value: '1' },
    { name: '2', value: '2' },
  ];
  sh_ps: any;
  fn_ps(event: any) {
    this.sh_ps = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_ps);
    this.datasNadams();
  }

  block_GControl = new FormControl('', Validators.required);
  block_G: any = [];
  async getBlock_G() {
    try {
      const response = await axios.get(environment.apijks + '/Master/BlockGroup', { headers: { Pragma: 'no-cache' } });
      this.block_G = response.data;
    } catch (error) {
      // console.error(error.stack);
    }
  }
  sh_block_G: any;
  fn_block_G(event: any) {
    this.sh_block_G = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_block_G);
  }

  gobal_cellControl = new FormControl('', Validators.required);
  gobal_cell: any = [];
  async getGobal_cell() {
    try {
      const response = await axios.get(environment.apijks + '/Master/GbCellCode', { headers: { Pragma: 'no-cache' } });
      this.gobal_cell = response.data;
    } catch (error) {
      // console.error(error.stack);
    }
  }
  sh_gobal_cell: any;
  fn_gobal_cell(event: any) {
    this.sh_gobal_cell = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log(this.sh_gobal_cell);
  }

  shift_work: any;
  async ngOnInit() {
    await this.getWC();
    await this.getBlock_G();
    await this.getGobal_cell();

    if (this.manpower_op == "" || this.manpower_sp == "" || this.manpower_base == "") {
      this.manpower_op = "Please check data";
      this.manpower_sp = "Please check data";
      this.manpower_base = "Please check data";
      this.class_danger = "text-danger";
      this.working_time_total = 0;
      this.working_time_total_op_sp = 0;   //PLE
    }

    this.shift_work = await this.ServiceJksService.s_get('/Home/getdaynight');
    // console.log("shift_work: ", this.shift_work); this.shift_work = "night";
    if (this.shift_work == "day") {
      this.psControl.setValue("1");
    } else {
      this.psControl.setValue("2");
    }
  }

  datasNadams() {
    if (this.sh_wc === undefined) {
      this.sh_wc = { value: "", text: "" };
    }
    if (this.sh_model === undefined) {
      this.sh_model = { value: "", text: "" };
    }
    if (this.sh_process === undefined) {
      this.sh_process = { value: "", text: "" };
    }
    if (this.sh_cell === undefined) {
      this.sh_cell = { value: "", text: "" };
    }
    if (this.sh_shift === undefined) {
      this.sh_shift = { value: "", text: "" };
    }

    if (this.sh_ps === undefined || this.sh_ps.value === "") {
      this.sh_ps = { value: this.psControl.value, text: this.psControl.value };
    }

    this.sh_block_G = { value: this.block_GControl.value, text: this.block_GControl.value };
    this.sh_gobal_cell = { value: this.gobal_cellControl.value, text: this.gobal_cellControl.value };

    // console.log(this.sh_ps);
    // console.log(this.sh_block_G);
    // console.log(this.sh_gobal_cell);

    if (this.sh_ps.value !== "") {
      const a = {
        "date_input": this.apiDate,
        "wc_code": this.sh_wc.value,
        "model_code": this.sh_model.value,
        "process_code": this.sh_process.value,
        "cell_code": this.sh_cell.value,
        "shift_code": this.sh_shift.value,
        "production_shift": this.sh_ps.value,
        "block_group_code": this.sh_block_G.value,
        "gb_cell_code": this.sh_gobal_cell.value
      };
      console.log('datasNadams: ', a);
      this.searchST(a);
    }
  }
  async datamanpower() {
    if (this.sh_wc === undefined) {
      this.sh_wc = { value: "", text: "" };
    }
    if (this.sh_model === undefined) {
      this.sh_model = { value: "", text: "" };
    }
    if (this.sh_process === undefined) {
      this.sh_process = { value: "", text: "" };
    }
    if (this.sh_cell === undefined) {
      this.sh_cell = { value: "", text: "" };
    }
    if (this.sh_shift === undefined) {
      this.sh_shift = { value: "", text: "" };
    }
    const a = {
      "date_input": this.apiDate,
      "wc_code": this.sh_wc.value,
      "model_code": this.sh_model.value,
      "process_code": this.sh_process.value,
      "cell_code": this.sh_cell.value,
      "shift_code": this.sh_shift.value
    };
    //console.log('datamanpower: ', a);

    await this.getManpower(a);
  }
  cal_actual_output() {
    const a = {
      "date_input": this.apiDate,
      "wc_code": this.sh_wc.value,
      "model_code": this.sh_model.value,
      "process_code": this.sh_process.value,
      "cell_code": this.sh_cell.value,
      "shift_code": this.sh_shift.value,
      "production_shift": this.sh_ps.value,
      "block_group_code": this.sh_block_G.value,
      "gb_cell_code": this.sh_gobal_cell.value
    };
    this.searchST(a);
    this.getST = this.ServiceJksService.getservice_prodouction();
    if (this.getST.length > 0) {
      this.v_actual_output = this.getST[0].count_1;
    }
  }
  itemsST: any
  getST: any;
  async searchST(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      // console.log("params SearchST: ", params);
      const response = await instance.post('/Summary/SummaryAll/SearchST', params)
      console.log("SearchST  service_prodouction: ", response);

      this.itemsST = this.ServiceJksService.clearservice_prodouction();
      this.itemsST = this.ServiceJksService.service_prodouction(response.data)

      return response.data;
    } catch (error) {
      // console.log('RES ERROR: ', error.response)

      this.itemsST = this.ServiceJksService.clearservice_prodouction();
      this.itemsST = this.ServiceJksService.service_prodouction(0)
    }
  }

  worker_performance: any = 0;  worker_performance_op_sp: any = 0;
  operation_rate: any = 0;  operation_rate_op_sp: any = 0;
  total_performance: any = 0; total_performance_op_sp: any = 0;
  ngDoCheck() {
    this.getST = this.ServiceJksService.getservice_prodouction();
    if (this.getST.length > 0) {
      this.v_actual_output = this.getST[0].count_1;
    }

    this.sv_search();
    this.sv_getData();
    this.sv_getovertime();
    this.sv_json();

    // console.log('working_time_total: ', this.working_time_total)
    // working_time_total_op_sp: any;   //PLE
    this.overtime_01_op = isEmpty(this.overtime_01_op); // OP
    this.overtime_01 = isEmpty(this.overtime_01); // OP + SP
    this.overtime_02_op = isEmpty(this.overtime_02_op); // OP
    this.overtime_02 = isEmpty(this.overtime_02); // OP + SP
    this.overtime_03_op = isEmpty(this.overtime_03_op);   // OP
    this.overtime_03 = isEmpty(this.overtime_03);   // OP + SP
    this.overtime_04_op = isEmpty(this.overtime_04_op);  // OP
    this.overtime_04 = isEmpty(this.overtime_04);   // OP +SP
    
    //  console.log('overtime_01: ', this.overtime_01)
    //  console.log('overtime_02: ', this.overtime_02)
    //  console.log('overtime_03: ', this.overtime_03)
    //  console.log('overtime_04: ', this.overtime_04)

    this.v_total_extrajob = this.v_extrawork + this.v_jobspecial;
    this.v_actual = (this.working_time_total + this.overtime_01_op - (this.overtime_02_op + this.overtime_03_op) + this.overtime_04_op);  // OP
    this.v_actual_op_sp = (this.working_time_total_op_sp + this.overtime_01 - (this.overtime_02 + this.overtime_03) + this.overtime_04);  // OP + SP
    
    this.v_actual =isEmpty(this.v_actual);  //console.log('v_actual: ', this.v_actual)
    this.v_actual_op_sp = isEmpty(this.v_actual_op_sp);
    
    this.serv = isEmpty(this.v_actual);   // console.log('serv: ', this.serv)
    this.ServiceJksService.addActual(this.serv);
    this.ServiceJksService.addActualOPSP(isEmpty(this.v_actual_op_sp));

    // console.log('v_actual: ', this.v_actual)
    // console.log('v_standardtime: ', this.v_standardtime)
    // console.log('v_totaltime: ', this.v_totaltime)
    // console.log('v_totallosstime: ', this.v_totallosstime)

    this.v_detail = (this.v_totaltime + this.v_totallosstime);  // OP
    this.v_detail_op_sp = (this.v_totaltime_op_sp + this.v_totallosstime);  // OP +SP
    
    this.v_unknown = this.v_actual - this.v_detail;  // OP
    this.v_unknown_op_sp = this.v_actual_op_sp - this.v_detail_op_sp;  // OP +SP
    // console.log('v_detail: ', this.v_detail)
    // console.log('v_unknown: ', this.v_unknown)

    ////////////// OP
    this.worker_performance = ((this.v_standardtime / this.v_totaltime) * 100);
    this.operation_rate = ((this.v_totaltime + this.v_extrawork + this.v_jobspecial) / this.v_detail) * 100;
    this.total_performance = (this.v_worker_performance * this.v_operation_rate) / 100;
    this.v_worker_performance = this.worker_performance === Infinity || this.worker_performance < 0 ? 0 : this.worker_performance;
    this.v_operation_rate = isNaN(this.operation_rate) || this.operation_rate < 0 ? 0 : this.operation_rate;
    this.v_total_performance = this.total_performance < 0 ? 0 : this.total_performance;
    // console.log('v_operation_rate: ', this.v_operation_rate)
    // console.log('v_worker_performance: ', this.v_worker_performance)
    // console.log('v_total_performance: ', this.v_total_performance)

    ////////////// OP + SP
    this.worker_performance_op_sp = ((this.v_standardtime_op_sp / this.v_totaltime_op_sp) * 100);
    this.operation_rate_op_sp = ((this.v_totaltime_op_sp + this.v_extrawork + this.v_jobspecial) / this.v_detail_op_sp) * 100;
    this.total_performance_op_sp = (this.v_worker_performance_op_sp * this.v_operation_rate_op_sp) / 100;
    this.v_worker_performance_op_sp = this.worker_performance_op_sp === Infinity || this.worker_performance_op_sp < 0 ? 0 : this.worker_performance_op_sp;
    this.v_operation_rate_op_sp = isNaN(this.operation_rate_op_sp) || this.operation_rate_op_sp < 0 ? 0 : this.operation_rate_op_sp;
    this.v_total_performance_op_sp = this.total_performance_op_sp < 0 ? 0 : this.total_performance_op_sp;
  }

  get_losstime_total: any;
  get_data: any;
  sv_getData() {
    this.get_losstime_total = this.ServiceJksService.getsv_losstime_total();
    if (this.get_losstime_total.length !== 0) {   // console.log('get_losstime_total:', this.get_losstime_total);
      this.v_totallosstime = this.get_losstime_total.total_losstime;
      this.v_extrawork = this.get_losstime_total.sum_extrawork;
      this.v_jobspecial = this.get_losstime_total.sum_jobspecial;
    }

    this.get_data = this.ServiceJksService.getData();
    if (this.get_data.length !== 0) {
      // console.log(this.get_data);
      
      const standardtime = this.get_data.filter((item: any) => { return item.header === 'Standard Time'; });  // OP
      const totaltime = this.get_data.filter((item: any) => { return item.header === 'Total Time'; });  // OP
      const standardtime_op_sp = this.get_data.filter((item: any) => { return item.header_op_sp === 'Standard Time OP + SP'; });
      const totaltime_op_sp = this.get_data.filter((item: any) => { return item.header_op_sp === 'Total Time OP + SP'; });

      if (standardtime.length !== 0) { this.v_standardtime = standardtime[standardtime.length - 1].value; }  // OP
      if (totaltime.length !== 0) { this.v_totaltime = totaltime[totaltime.length - 1].value; }  // OP

      if (standardtime_op_sp.length !== 0) { this.v_standardtime_op_sp = standardtime_op_sp[standardtime_op_sp.length - 1].value_op_sp; }
      if (totaltime_op_sp.length !== 0) { this.v_totaltime_op_sp = totaltime_op_sp[totaltime_op_sp.length - 1].value_op_sp; }
    }
  }
  sv_getovertime() {
    this.get_service_search = this.ServiceJksService.getservice_search();
    if (this.get_service_search.length > 0) {

      this.v_getovertime = this.ServiceJksService.getovertime(); // console.log('v_getovertime: ',this.v_getovertime);
      
      ///////// OP + SP
      const overtime1 = this.v_getovertime.filter((item: any) => { return item.header === 'overtime01'; });
      const overtime2 = this.v_getovertime.filter((item: any) => { return item.header === 'overtime02'; });
      const overtime3 = this.v_getovertime.filter((item: any) => { return item.header === 'overtime03'; });
      const overtime4 = this.v_getovertime.filter((item: any) => { return item.header === 'overtime04'; });

      ///////// OP
      const overtime1_op = this.v_getovertime.filter((item: any) => { return item.header_op === 'overtime01_op'; });
      const overtime2_op = this.v_getovertime.filter((item: any) => { return item.header_op === 'overtime02_op'; });
      const overtime3_op = this.v_getovertime.filter((item: any) => { return item.header_op === 'overtime03_op'; });
      const overtime4_op = this.v_getovertime.filter((item: any) => { return item.header_op === 'overtime04_op'; });

      ///////// SP
      const overtime1_sp = this.v_getovertime.filter((item: any) => { return item.header_sp === 'overtime01_sp'; });
      const overtime2_sp = this.v_getovertime.filter((item: any) => { return item.header_sp === 'overtime02_sp'; });
      const overtime3_sp = this.v_getovertime.filter((item: any) => { return item.header_sp === 'overtime03_sp'; });
      const overtime4_sp = this.v_getovertime.filter((item: any) => { return item.header_sp === 'overtime04_sp'; });

      ///////// OP + SP
      if (overtime1.length !== 0) { this.overtime_01 = overtime1[overtime1.length - 1].value; } else { this.overtime_01 = this.get_service_search[0].overtime_op_sp; }
      if (overtime2.length !== 0) { this.overtime_02 = overtime2[overtime2.length - 1].value; } else { this.overtime_02 = this.get_service_search[0].accident_op_sp; }
      if (overtime3.length !== 0) { this.overtime_03 = overtime3[overtime3.length - 1].value; } else { this.overtime_03 = this.get_service_search[0].manpower_out_flow_op_sp; }
      if (overtime4.length !== 0) { this.overtime_04 = overtime4[overtime4.length - 1].value; } else { this.overtime_04 = this.get_service_search[0].manpower_in_flow_op_sp; }

      ///////// OP
      if (overtime1_op.length !== 0) { this.overtime_01_op = overtime1_op[overtime1_op.length - 1].value_op; } else { this.overtime_01_op = this.get_service_search[0].overtime; }
      if (overtime2_op.length !== 0) { this.overtime_02_op = overtime2_op[overtime2_op.length - 1].value_op; } else { this.overtime_02_op = this.get_service_search[0].accident; }
      if (overtime3_op.length !== 0) { this.overtime_03_op = overtime3_op[overtime3_op.length - 1].value_op; } else { this.overtime_03_op = this.get_service_search[0].manpower_out_flow; }
      if (overtime4_op.length !== 0) { this.overtime_04_op = overtime4_op[overtime4_op.length - 1].value_op; } else { this.overtime_04_op = this.get_service_search[0].manpower_in_flow; }
    }
  }
  sv_search() {
    if (this.apiDate === undefined) {
      this.apiDate = formatDate(this.date.value, 'yyyy-MM-dd', 'en-US');
    }

    if (this.sh_wc && this.sh_model && this.sh_process && this.sh_cell && this.sh_shift
      && this.sh_ps && this.sh_block_G && this.sh_gobal_cell) {
      //  console.log('this.apiDate: ',this.apiDate)
      const sv = {
        "date_input": this.apiDate,
        "wc_code": this.sh_wc.value,
        "model_code": this.sh_model.value,
        "process_code": this.sh_process.value,
        "cell_code": this.sh_cell.value,
        "shift_code": this.sh_shift.value,
        "production_shift": this.sh_ps.value,
        "block_group_code": this.sh_block_G.value,
        "gb_cell_code": this.sh_gobal_cell.value
      }
      // console.log('sv: ',sv)
      this.ServiceJksService.clearsv_update();
      this.ServiceJksService.sv_update(sv);
    }
  }

  sv: any;
  sv_json() {
    if (this.sh_gobal_cell) {
      // console.log('this.attendance: ', this.attendance) // console.log('this.v_actual_output: ', this.v_actual_output)
      if (this.attendance === 0 && this.attendance_sp === 0) { // console.log("manpower_attendance === 0");
        this.get_service_search = this.ServiceJksService.getservice_search();
        if (this.get_service_search.length > 0) { // console.log('service_search > 0 ')
          //set attendance = base
          this.attendance = isEmpty(this.get_service_search[0].manpower_attendance);
          this.attendance_sp = isEmpty(this.get_service_search[0].manpower_attendance_sp);
          
          this.absent = isEmpty(this.get_service_search[0].manpower_absent);
          this.absent_sp = isEmpty(this.get_service_search[0].manpower_absent_sp);
          
          // this.attendance = parseInt(this.manpower_base) - this.absent;  // old
          this.attendance = parseInt(this.manpower_op) - this.absent;
          this.attendance_sp = parseInt(this.manpower_sp) - this.absent_sp;
          // this.working_time_total = ((parseInt(this.manpower_base) * 480) - (this.absent * 480));  // old
          let cal_op = this.fnCalOP();
          this.working_time_total = ((this.attendance * 480) - (cal_op * 480));   // PLE
          this.working_time_total_op_sp = ((this.attendance_sp * 480) - (cal_op * 480));  // PLE

          this.sv = {
            "date_input": this.apiDate,
            "wc_code": this.sh_wc.value,
            "model_code": this.sh_model.value,
            "process_code": this.sh_process.value,
            "cell_code": this.sh_cell.value,
            "shift_code": this.sh_shift.value,
            "production_shift": this.sh_ps.value,
            "block_group_code": this.sh_block_G.value,
            "gb_cell_code": this.sh_gobal_cell.value,
            "op_meister": this.manpower_op,
            "sp_meister": this.manpower_sp,
            "manpower": this.manpower_base,
            "manpower_attendance": isEmpty(this.get_service_search[0].manpower_attendance),
            manpower_attendance_sp: isEmpty(this.get_service_search[0].manpower_attendance_sp),
            "manpower_absent": isEmpty(this.get_service_search[0].manpower_absent),
            manpower_absent_sp: isEmpty(this.get_service_search[0].manpower_absent_sp),
            "extra_work": isEmpty(this.get_service_search[0].extra_work),
            "job_special": isEmpty(this.get_service_search[0].job_special),
            "total_extra_job": isEmpty(this.get_service_search[0].total_extra_job),
            "actual_output": isEmpty(this.v_actual_output),
            "reject_off": isEmpty(this.get_service_search[0].reject_off),
            "working_time": isEmpty(this.get_service_search[0].working_time),
            "working_man": isEmpty(this.get_service_search[0].working_man),
            working_man_op_sp: isEmpty(this.get_service_search[0].working_man_op_sp),
            "overtime": isEmpty(this.get_service_search[0].overtime),  // OP
            overtime_op_sp: isEmpty(this.get_service_search[0].overtime_op_sp), // OP + SP
            "accident": isEmpty(this.get_service_search[0].accident),
            accident_op_sp: isEmpty(this.get_service_search[0].accident_op_sp),
            "manpower_out_flow": isEmpty(this.get_service_search[0].manpower_out_flow),
            manpower_out_flow_op_sp: isEmpty(this.get_service_search[0].manpower_out_flow_op_sp),
            "manpower_in_flow": isEmpty(this.get_service_search[0].manpower_in_flow),
            manpower_in_flow_op_sp: isEmpty(this.get_service_search[0].manpower_in_flow_op_sp),
            "actual_working_man": isEmpty(this.get_service_search[0].actual_working_man),
            actual_working_man_op_sp: isEmpty(this.get_service_search[0].actual_working_man_op_sp),
            "detail_working": isEmpty(this.get_service_search[0].detail_working),
            detail_working_op_sp: isEmpty(this.get_service_search[0].detail_working_op_sp),
            "unknown_time": isEmpty(this.get_service_search[0].unknown_time),
            unknown_time_op_sp: isEmpty(this.get_service_search[0].unknown_time_op_sp),
            "worker_performance": isEmpty(this.get_service_search[0].worker_performance),
            worker_performance_op_sp: isEmpty(this.get_service_search[0].worker_performance_op_sp),
            "operation_rate": isEmpty(this.get_service_search[0].operation_rate),
            operation_rate_op_sp: isEmpty(this.get_service_search[0].operation_rate_op_sp),
            "total_performance": isEmpty(this.get_service_search[0].total_performance),
            total_performance_op_sp: isEmpty(this.get_service_search[0].total_performance_op_sp),
            "comment": this.get_service_search[0].comment === undefined ? null : this.get_service_search[0].comment,
          }
        } else { // console.log('service_search < 0 ')
          this.sv = {
            "date_input": this.apiDate,
            "wc_code": this.sh_wc.value,
            "model_code": this.sh_model.value,
            "process_code": this.sh_process.value,
            "cell_code": this.sh_cell.value,
            "shift_code": this.sh_shift.value,
            "production_shift": this.sh_ps.value,
            "block_group_code": this.sh_block_G.value,
            "gb_cell_code": this.sh_gobal_cell.value
          };
        }
      } else {
        // console.log("manpower_attendance === undefined"); // manpower_attendance_sp // PLE
        this.sv = {
          "date_input": this.apiDate,
          "wc_code": this.sh_wc.value,
          "model_code": this.sh_model.value,
          "process_code": this.sh_process.value,
          "cell_code": this.sh_cell.value,
          "shift_code": this.sh_shift.value,
          "production_shift": this.sh_ps.value,
          "block_group_code": this.sh_block_G.value,
          "gb_cell_code": this.sh_gobal_cell.value,
          "op_meister": this.manpower_op,
          "sp_meister": this.manpower_sp,
          "manpower": this.manpower_base,
          "manpower_attendance": isEmpty(this.attendance),  // OP
          manpower_attendance_sp: isEmpty(this.attendance_sp), // SP
          "manpower_absent": isEmpty(parseInt(this.txtAbsent.nativeElement.value)), // OP
          manpower_absent_sp: isEmpty(parseInt(this.txtAbsent_sp.nativeElement.value)), //SP
          "extra_work": isEmpty(this.v_extrawork),
          "job_special": isEmpty(this.v_jobspecial),
          "total_extra_job": isEmpty(this.v_total_extrajob),
          "actual_output": isEmpty(this.v_actual_output),
          "reject_off": isEmpty(parseInt(this.txtreject_off.nativeElement.value)),
          "working_time": isEmpty(parseInt(this.txtworking_time.nativeElement.value)),
          "working_man": isEmpty(this.working_time_total),  // OP
          working_man_op_sp: isEmpty(this.working_time_total_op_sp),  // SP
          "overtime": isEmpty(this.overtime_01_op),  // OP
          overtime_op_sp: isEmpty(this.overtime_01),  // OP +SP
          "accident": isEmpty(this.overtime_02_op),  // OP
          accident_op_sp: isEmpty(this.overtime_02),  // OP + SP
          "manpower_out_flow": isEmpty(this.overtime_03_op),  // OP
          manpower_out_flow_op_sp: isEmpty(this.overtime_03),  // OP + SP
          "manpower_in_flow": isEmpty(this.overtime_04_op),  // OP
          manpower_in_flow_op_sp: isEmpty(this.overtime_04),  // OP + SP
          "actual_working_man": isEmpty(this.v_actual),  // OP
          actual_working_man_op_sp: isEmpty(this.v_actual_op_sp),  // OP + SP
          "detail_working": isEmpty(this.v_detail),  // OP
          detail_working_op_sp: isEmpty(this.v_detail_op_sp),  // OP + SP
          "unknown_time": isEmpty(this.v_unknown),  // OP
          unknown_time_op_sp: isEmpty(this.v_unknown_op_sp),  // OP + SP
          "worker_performance": isEmpty(parseFloat(this.v_worker_performance).toFixed(2).toString()),  // OP
          worker_performance_op_sp: isEmpty(parseFloat(this.v_worker_performance_op_sp).toFixed(2).toString()),  // OP + SP
          "operation_rate": isEmpty(parseFloat(this.v_operation_rate).toFixed(2).toString()),  // OP
          operation_rate_op_sp: isEmpty(parseFloat(this.v_operation_rate_op_sp).toFixed(2).toString()),  // OP + SP
          "total_performance": isEmpty(parseFloat(this.v_total_performance).toFixed(2).toString()),  // OP
          total_performance_op_sp: isEmpty(parseFloat(this.v_total_performance_op_sp).toFixed(2).toString()),  // OP + SP
          "comment": this.txtcomment.nativeElement.value === undefined ? null : this.txtcomment.nativeElement.value
        }
      }
      // console.log(this.sv)
      this.ServiceJksService.sv_update(this.sv);
    }
  }

}

function isEmpty(val:any){
  let value = 0;
  if(val === undefined ) {
    value = 0;
  }else if(isNaN(val)) {
    value = 0;
  }else if(val === "" ) {
    value = 0;
  }else if(val === null ) {
    value = 0;
  }else{
    value = val;
  }
  return value;
}