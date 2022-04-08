import { Component, OnInit, ViewChild } from '@angular/core';
import { ServiceJksService } from '../../service-jks.service';
import axios from 'axios';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-home-workingman',
  templateUrl: './home-workingman.component.html',
  styleUrls: ['../home.component.css']
})
export class HomeWorkingmanComponent implements OnInit {
  userid: any;
  standardtime: any = 0; standardtime_op_sp: any = 0;
  manpower: number = 1; manpower_op_sp: number = 1;
  time: number = 0; time_op_sp: number = 0;
  v_sum: any; v_sum_op_sp: any;
  getservice: any = [];
  t_losstime: number = 0;
  v_actual: number = 0; v_actual_op_sp: number = 0;
  serv: any = [];
  items: any = [];
  get_service: any = [];

  constructor(
    private ServiceJksService: ServiceJksService
  ) { }

  get: any = [];
  async ngOnInit() {
    this.userid = localStorage.getItem('userid');
  }

  getAC: any; getAC_OPSP: any;
  getST: any = [];
  ngDoCheck() {
    this.getservice = this.ServiceJksService.getsv_losstime_total();
    this.getAC = this.ServiceJksService.getActual();
    if (this.getAC !== "") { // console.log('this.getAC: ', this.getAC);
      this.v_actual = this.getAC;
    }
    this.getAC_OPSP = this.ServiceJksService.getActualOPSP();
    if (this.getAC_OPSP !== "") { // console.log('this.getAC: ', this.getAC);
      this.v_actual_op_sp = this.getAC_OPSP;
    }
    if (this.getservice !== "") { // console.log('total_losstime2: ', this.getservice);
      this.t_losstime = this.getservice.total_losstime;
    }
    // console.log('v_actual: ', this.v_actual)
    // console.log('v_actual_op_sp: ', this.v_actual_op_sp)
    // console.log('t_losstime: ', this.t_losstime)

    this.time = (this.v_actual - this.t_losstime); //console.log('time: ', this.time); console.log('manpower: ', this.manpower); 
    this.v_sum = this.manpower * this.time; //console.log('v_sum: ', this.v_sum);

    this.time_op_sp = (this.v_actual_op_sp - this.t_losstime); //console.log('time: ', this.time_op_sp); console.log('manpower: ', this.manpower_op_sp); 
    this.v_sum_op_sp = this.manpower_op_sp * this.time_op_sp; //console.log('v_sum: ', this.v_sum_op_sp);

    this.serv = {
      "header": "Standard Time",
      "value": this.standardtime,
      "header_op_sp": "Standard Time OP + SP",
      "value_op_sp": this.standardtime_op_sp
    };
    this.ServiceJksService.addData(this.serv);
    // console.log('this.standardtime: ', this.standardtime)

    this.serv = {
      "header": "Total Time",
      "value": this.v_sum,
      "header_op_sp": "Total Time OP + SP",
      "value_op_sp": this.v_sum_op_sp
    };
    this.ServiceJksService.addData(this.serv);

    this.items = this.ServiceJksService.getservice_search();
    if (this.items.length > 0) {  // console.log('this.v_sum: ',this.v_sum)
      if (this.time === 0) {
        this.services2();
      }else if (this.time_op_sp === 0) {
        this.services2();
      } else {
        this.services();
      }

      this.getST = this.ServiceJksService.getservice_prodouction();
      if (this.getST.length > 0) {
        // console.log('getservice_prodouction: ', this.getST);
        this.standardtime = this.getST[0].qty_1 === undefined ? 0 : this.getST[0].qty_1;
        this.standardtime_op_sp = this.getST[0].qty_1 === undefined ? 0 : this.getST[0].qty_1;
      }
    }
  }

  async services() {
    this.get_service = this.ServiceJksService.getsv_losstime();
    // console.log('getsv_losstime: ', this.get_service)
    if (this.get_service !== "") {
      // console.log('services: ', this.get_service)

      this.get = this.get_service;
      const sv = {
        "standard_time": this.standardtime,
        "actual_time": this.time,
        "total_time": this.v_sum,
        "standard_time_op_sp": this.standardtime_op_sp,
        "actual_time_op_sp": this.time_op_sp,
        "total_time_op_sp": this.v_sum_op_sp,
        "t_summary_tss": this.get,
      }
      this.ServiceJksService.sv_workingman(sv);
    } else {
      const sv = {
        "standard_time": this.standardtime,
        "actual_time": this.time,
        "total_time": this.v_sum,
        "standard_time_op_sp": this.standardtime_op_sp,
        "actual_time_op_sp": this.time_op_sp,
        "total_time_op_sp": this.v_sum_op_sp,
        "t_summary_tss": []
      }
      this.ServiceJksService.sv_workingman(sv);
    }
  }
  async services2() {
    this.get_service = this.ServiceJksService.getsv_losstime();
    if (this.get_service.length > 0) {
      // console.log('services2: ', this.get_service)
      this.get = this.get_service;
    }

    const sv = {
      "standard_time": this.items[0].standard_time === undefined ? 0 : this.items[0].standard_time,
      "actual_time": this.items[0].actual_time === undefined ? 0 : this.items[0].actual_time,
      "total_time": this.items[0].total_time === undefined ? 0 : this.items[0].total_time,
      "standard_time_op_sp": this.items[0].standard_time_op_sp === undefined ? 0 : this.items[0].standard_time_op_sp,
      "actual_time_op_sp": this.items[0].actual_time_op_sp === undefined ? 0 : this.items[0].actual_time_op_sp,
      "total_time_op_sp": this.items[0].total_time_op_sp === undefined ? 0 : this.items[0].total_time_op_sp,
      "t_summary_tss": this.get,
    }
    this.ServiceJksService.sv_workingman(sv);
  }
}