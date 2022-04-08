import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDatepickerInputEvent } from '@angular/material';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import axios from 'axios';
import { ChartOptions, ChartType } from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  getDataCSV: any = [];
  getDetail: any = [];
  getTSS: any = [];
  responseerror: any;
  responseerror_excel: any;
  show: boolean = false;
  showerror_excel: boolean = false;
  options: FormGroup;
  floatLabelControl = new FormControl('all');
  date = new FormControl(new Date());
  events: string = "";
  apiDatestart: any;
  apiDateend: any;

  keyss: any = [];
  thheaders: any = [];
  tdrows: any = [];
  resultnon: any = [];

  key_detail: any = [];
  thheaders_detail: any = [];
  tdrows_detail: any = [];
  worker_performance: any = [];
  operation_rate: any = [];
  total_performance: any = [];
  total_efficiency: any = [];

  bc_rows: any = [];
  bc_key: any = [];
  bc_col: any = [];
  get_service: any = [];
  dataset: any = [];

  barChartLabels: Label[] = [];
  barChartData: any = [];

  constructor(fb: FormBuilder,
    private httpService: HttpClient,) {
    this.options = fb.group({
      floatLabel: this.floatLabelControl,
      wc: this.wcControl,
      model: this.modelControl,
      shift: this.shiftControl,
    });
  }

  startEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.events = `${event.value}`;
    this.apiDatestart = formatDate(this.events, 'yyyy-MM-dd', 'en-US');
    console.log(this.apiDatestart);
  }
  endEvent(type: string, event: MatDatepickerInputEvent<Date>) {
    this.events = `${event.value}`;
    this.apiDateend = formatDate(this.events, 'yyyy-MM-dd', 'en-US');
    console.log(this.apiDateend);
  }

  wcControl = new FormControl('all', Validators.required);
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
    // console.log('sh_wc: ', this.sh_wc);
  }

  modelControl = new FormControl('all', Validators.required);
  models: any = [];
  getMODEL() {
    this.httpService.get(environment.apijks + '/Master/ProductModel', { headers: { Pragma: 'no-cache' } }).subscribe(
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
    // console.log('sh_model: ', this.sh_model);
  }

  processControl = new FormControl('all', Validators.required);
  process: any = [];
  getPROCESS() {
    this.httpService.get(environment.apijks + '/Master/ProcessName', { headers: { Pragma: 'no-cache' } }).subscribe(
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
    // console.log('sh_process: ', this.sh_process);
  }

  cellControl = new FormControl('all', Validators.required);
  cell: any = [];
  async getCell() {
    try {
      const response = await axios.get(environment.apijks + '/Master/CellName', { headers: { Pragma: 'no-cache' } });
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
    // console.log('sh_cell: ', this.sh_cell);
  }

  shiftControl = new FormControl('all', Validators.required);
  shift: any = [];
  getshift() {
    try {
      this.httpService.get(environment.apijks + '/Master/BlockShift', { headers: { Pragma: 'no-cache' } }).subscribe(
        data => {
          this.shift = data as string[];
        }
      );
    } catch (err) {
      console.log('ERROR SHIFT: ', err.stack)
    }
  }
  sh_shift: any;
  fn_shift(event: any) {
    this.sh_shift = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log('sh_shift: ', this.sh_shift);
  }

  async ngOnInit() {
    await this.getWC();
    this.getMODEL();
    this.getPROCESS();
    this.getCell();
    await this.getshift();
  }

  //// Search Monthly Report ////
  async submitSearch() {
    const today = new Date();
    const dd = ("0" + today.getDate()).slice(-2);
    const mm = ("0" + (today.getMonth() + 1)).slice(-2);
    const yyyy = today.getFullYear();
    if (this.apiDatestart === undefined) {
      this.apiDatestart = yyyy + "-" + mm + "-" + dd;
    }
    if (this.apiDateend === undefined) {
      this.apiDateend = yyyy + "-" + mm + "-" + dd;
    }

    if (this.sh_wc === undefined || this.sh_wc.value == "all") {
      this.sh_wc = { value: "", text: "All" };
    }
    if (this.sh_model === undefined || this.sh_model.value == "all") {
      this.sh_model = { value: "", text: "All" };
    }
    if (this.sh_process === undefined || this.sh_process.value == "all") {
      this.sh_process = { value: "", text: "All" };
    }
    if (this.sh_cell === undefined || this.sh_cell.value == "all") {
      this.sh_cell = { value: "", text: "All" };
    }
    if (this.sh_shift === undefined || this.sh_shift.value == "all") {
      this.sh_shift = { value: "", text: "All" };
    }

    if (this.sh_wc !== undefined && this.sh_model !== undefined && this.sh_process !== undefined && this.sh_cell !== undefined && this.sh_shift !== undefined) {
      const params = {
        start_date: this.apiDatestart,
        end_date: this.apiDateend,
        wc_code: this.sh_wc.value,
        model_code: this.sh_model.value,
        process_code: this.sh_process.value,
        cell_code: this.sh_cell.value,
        shift_code: this.sh_shift.value
      }
      // console.log(params);

      this.getTSS = await this.getmonthly_TSS(params);
      this.getDetail = await this.getmonthly_detail(params);
      this.getBar();
    }
  }
  //// Table TSS ////
  async getmonthly_TSS(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      // console.log(params);
      const response = await instance.post("/Monthly/TSS", params);
      // console.log("response tss: ", response);

      this.tdrows = [];
      this.thheaders = [];
      this.keyss = [];
      response.data.map((item: any) => (
        this.keyss.push(Object.keys(item)),
        this.tdrows.push(item)
      ))
      this.thheaders = this.keyss[0].slice(1, this.keyss[0].length);

      return response.data;
    } catch (error) {
      console.log('RES ERROR TSS: ', error.response);

      this.tdrows = [];
      this.thheaders = [];
      this.keyss = [];
      this.show = false;
    }
  }
  //// Table Detail ////
  async getmonthly_detail(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });

      // console.log(params);
      const response = await instance.post("/Monthly/Detail", params);
      // console.log("response detail: ", response);

      this.tdrows_detail = [];
      this.thheaders_detail = [];
      this.key_detail = [];
      response.data.table.map((item: any) => (
        this.key_detail.push(Object.keys(item)),
        this.tdrows_detail.push(item)
      ))
      this.thheaders_detail = this.key_detail[0];

      let headerdynamic;
      if (this.thheaders.length > 0) {
        headerdynamic = this.thheaders.slice(1, this.thheaders.length);
      } else {
        headerdynamic = this.thheaders_detail.slice(1, this.thheaders_detail.length);
      }

      this.worker_performance = [];
      this.operation_rate = [];
      this.total_performance = [];
      this.total_efficiency = [];
      for (const key of headerdynamic) {
        let valuesdt = 0;
        let valueact = 0;
        let sumworker_performance = 0;
        let arr: any = {};

        let v_special_job = 0;
        let v_extra_work = 0;
        let v_non = 0;
        let sumoperation_rate = 0;
        let arr_or: any = {};
        let arr_tp: any = {};
        let arr_te: any = {};
        arr.key = key;
        arr_or.key = key;
        arr_tp.key = key;
        arr_te.key = key;
        let improvement_rate = 0;
        ///////////////////////////////////////// Worker Performance /////////////////////////////////////////
        for (const items of this.tdrows_detail) {
          if (items.name === "Total_standard") {
            valuesdt += items[key];
          }
          if (items.name === "Total_actual_time") {
            valueact += items[key];
          }
        }
        sumworker_performance = (valuesdt / valueact) * 100;
        arr.value = sumworker_performance;
        this.worker_performance.push(arr);
        ///////////////////////////////////////// Operation Rate /////////////////////////////////////////
        for (const item of this.tdrows) {
          if (item.tss_code === "150") {
            v_special_job = item[key];
          }
          if (item.tss_code === "160") {
            v_extra_work = item[key];
          }
          if (item.tss_code === "non") {
            v_non = item[key];
          }
        }
        let poa = (valueact + v_special_job + v_extra_work);
        let poan = (valueact + v_non + v_special_job + v_extra_work);
        sumoperation_rate = ((poa / poan) * 100);
        arr_or.value = sumoperation_rate;
        this.operation_rate.push(arr_or);
        ///////////////////////////////////////// Total Performance /////////////////////////////////////////
        arr_tp.value = (sumworker_performance * sumoperation_rate) / 100;
        this.total_performance.push(arr_tp);
        ///////////////////////////////////////// Total efficiency /////////////////////////////////////////
        arr_te.value = ((sumworker_performance + improvement_rate) * sumoperation_rate) / 100;
        this.total_efficiency.push(arr_te);
      }

      this.show = true;
      this.showerror_excel = true;
      this.responseerror = "";
      this.responseerror_excel = "";
      return response.data;
    } catch (error) {
      console.log('RES ERROR DETAIL: ', error.response);

      this.show = false;
      this.responseerror = "ไม่พบข้อมูล";
    }
  }
  //// Bar Chart ////
  async getManpower(datas: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      console.log(datas);
      
      const response = await instance.post('/Detail/Manpower/Search', datas)
      console.log("getManpower: ", response);
      // if (response.data.length > 0) {
      //   console.log(response.data[0].process_detail);
      //   console.log(response.data[0].gb_cell_code);
      //   // this.block_GControl.setValue(response.data[0].block_group_code);
      //   // this.gobal_cellControl.setValue(response.data[0].gb_cell_code);
      // }

      return response.data;
    } catch (error) {
      console.log(error.stack)
      console.log('RES ERROR: ', error.response)
    }
  }

  getBar() {
    this.get_service = this.getDetail.table; // console.log('this.getDetail.table: ', this.getDetail.table);
    if (this.get_service.length > 0) { // console.log('get_service: ', this.get_service);
      this.bc_key = [];
      this.bc_col = [];
      this.dataset = [];

      this.get_service.map((item: any) => (
        this.bc_key.push(Object.keys(item))
      ))
      this.bc_col = this.bc_key[0].slice(1, this.bc_key[0].length);
      // console.log('bc_col: ',this.bc_col);

      for (let i = 0; i < this.bc_col.length; i++) {
        const grapRecord: any = {};
        grapRecord.name = this.bc_col[i];
        this.barChartData[i] = [
          { barThickness: 70, maxBarThickness: 50, data: [this.get_service[2][this.bc_col[i]]], label: 'Total actual time', stack: 'a' },
          { barThickness: 70, maxBarThickness: 50, data: [this.get_service[0][this.bc_col[i]]], label: 'Non-working time', stack: 'a' },
          { barThickness: 70, maxBarThickness: 50, data: [this.get_service[3][this.bc_col[i]]], label: 'Total standard time', stack: 'b' },
          { barThickness: 70, maxBarThickness: 50, data: [this.get_service[1][this.bc_col[i]]], label: 'PF Loss', stack: 'b' }
        ];
        // console.log('barchart2: ', this.barChartData[i]);
        grapRecord.data = this.barChartData[i];
        this.dataset.push(grapRecord)
      }
      // console.log('dataset: ', this.dataset);
    }
    else {
      console.log('aa', this.get_service);
    }

    // console.log(this.sh_wc);
    // console.log(this.sh_model);
    // console.log(this.sh_process);
    // console.log(this.sh_cell);
    // console.log(this.sh_shift);
    // this.bc_col.push("Cell Submain-A") // test
    // console.log('bc_col: ', this.bc_col);
    // let arr_col = [];
    // let cells = "";
    // for (let i = 0; i < this.bc_col.length; i++) {
    //   if (this.bc_col[i] != "total") {
    //     const grapRecord: any = {};
    //     cells = this.bc_col[i].substr(this.bc_col[i].indexOf(' ') + 1, this.bc_col[i].indexOf('-'));
    //     grapRecord.cell = cells.substring(0, cells.indexOf('-'));
    //     grapRecord.shift = this.bc_col[i].substr(this.bc_col[i].lastIndexOf('-') + 1);
    //     arr_col.push(grapRecord);
    //   }
    // }
    // console.log(arr_col);
    
    // if (this.sh_wc.value !== "" && this.sh_model.value !== "" && this.sh_process.value !== "") {
    //     for (let i = 0; i < arr_col.length; i++) {
    //       const a = {
    //         "date_input": this.apiDatestart,
    //         "wc_code": this.sh_wc.value,
    //         "model_code": this.sh_model.value,
    //         "process_code": this.sh_process.value,
    //         "cell_code": arr_col[i].cell,
    //         "shift_code": arr_col[i].shift
    //       };
    //       this.getManpower(a);
    //     }     
    // }
    const params = {
      start_date: this.apiDatestart,
      end_date: this.apiDateend,
      wc_code: this.sh_wc.value,
      model_code: this.sh_model.value,
      process_code: this.sh_process.value,
      cell_code: this.sh_cell.value,
      shift_code: this.sh_shift.value
    }
    console.log(params);
  }
  public barChartOptions: ChartOptions = {
    responsive: true,
    plugins: {
    }
  };
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [pluginDataLabels];
  // public barChartColors = [
  //   { backgroundColor: ['#062555'] },
  //   { backgroundColor: ['#EBEBD3'] },

  //   { backgroundColor: ['#09357a'] },
  //   { backgroundColor: ['#89b7ff'] },
  // ];
  // public barChartColors = [
  //   { backgroundColor: ['rgb(248, 184, 131)'] },
  //   { backgroundColor: ['rgb(229, 101, 144)'] },

  //   { backgroundColor: ['rgb(53, 124, 210)'] },
  //   { backgroundColor: ['rgb(64, 64, 65)'] },
  // ];
  public barChartColors = [
    { backgroundColor: ['rgb(91, 155, 213)'] },
    { backgroundColor: ['rgb(255, 242, 204)'] },

    { backgroundColor: ['rgb(165, 165, 165)'] },
    { backgroundColor: ['rgb(255, 192, 0)'] },
  ];
  async exportMonthly() {
    const today = new Date();
    const dd = ("0" + today.getDate()).slice(-2);
    const mm = ("0" + (today.getMonth() + 1)).slice(-2);
    const yyyy = today.getFullYear();
    if (this.apiDatestart === undefined) {
      this.apiDatestart = yyyy + "-" + mm + "-" + dd;
    }
    if (this.apiDateend === undefined) {
      this.apiDateend = yyyy + "-" + mm + "-" + dd;
    }
    if (this.sh_wc !== undefined && this.sh_model !== undefined && this.sh_process !== undefined && this.sh_cell !== undefined && this.sh_shift !== undefined) {
      const params = {
        "start_date": this.apiDatestart,
        "end_date": this.apiDateend,
        "wc_code": this.sh_wc.value,
        "model_code": this.sh_model.value,
        "shift_code": this.sh_shift.value
      }
      this.exportExcel(params, "MonthlyReport", "/Monthly/exportMonthly");
    }
  }
  //// Export Summary Report ////
  async exportFile() {
    const today = new Date();
    const dd = ("0" + today.getDate()).slice(-2);
    const mm = ("0" + (today.getMonth() + 1)).slice(-2);
    const yyyy = today.getFullYear();
    // console.log(today)
    // console.log(dd)
    // console.log(mm)
    // console.log(yyyy)

    if (this.apiDatestart === undefined) {
      this.apiDatestart = yyyy + "-" + mm + "-" + dd;
    }
    if (this.apiDateend === undefined) {
      this.apiDateend = yyyy + "-" + mm + "-" + dd;
    }

    const params = {
      start_date: this.apiDatestart,
      end_date: this.apiDateend,
      wc_code: this.sh_wc.value,
      model_code: this.sh_model.value,
      process_code: this.sh_process.value,
      cell_code: this.sh_cell.value,
      shift_code: this.sh_shift.value
    }

    if (this.floatLabelControl.value === "all") {
      this.getDataCSV = await this.getSummaryAll(params);
    }

    if (this.floatLabelControl.value === "jks") {
      this.getDataCSV = await this.getSummaryJKS(params);
    }

    if (this.floatLabelControl.value === "ot") {
      this.getDataCSV = await this.getSummaryOT(params);
    }

    if (this.floatLabelControl.value === "tss") {
      this.getDataCSV = await this.getSummaryTSS(params);
    }
  }
  async getSummaryAll(params: any) {
    this.exportExcel(params, "SummaryReport", "/Summary/exportSummary")
  }
  async getSummaryJKS(params: any) {
    this.exportExcel(params, "SummaryJKS", "/Summary/exportSummaryJKS")
  }
  async getSummaryOT(params: any) {
    this.exportExcel(params, "SummaryOT", "/Summary/exportSummaryOT")
  }
  async getSummaryTSS(params: any) {
    this.exportExcel(params, "SummaryTSS", "/Summary/exportSummaryTSS")
  }
  async exportExcel(params: any, namefile: string = "", url: string = "") {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        },
        responseType: 'blob'
      });

      // console.log(params);
      const response = await instance.post(url, params);
      // console.log("response: ", response);

      const today = new Date();
      const dd = ("0" + today.getDate()).slice(-2);
      const mm = ("0" + (today.getMonth() + 1)).slice(-2);
      const yyyy = today.getFullYear();
      const hh = today.getHours();
      const mn = today.getMinutes();
      const sc = today.getMilliseconds();
      // console.log(today)
      // console.log(dd)
      // console.log(mm)
      // console.log(yyyy)
      // console.log(yyyy + mm + dd + hh + mn + sc);

      // console.log("msSaveBlob: ", window.navigator.msSaveBlob)
      if (window.navigator.msSaveBlob) //IE & Edge
      { //msSaveBlob only available for IE & Edge
        console.log("IE & Edge")
        const blob = new Blob([response.data], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8' });
        window.navigator.msSaveBlob(blob, namefile + `-` + yyyy + mm + dd + hh + mn + sc + `.xlsx`);
      }
      else //Chrome & FF
      {
        // console.log("Chrome")
        const url = window.URL.createObjectURL(new Blob([response.data]));
        const link = document.createElement('a');
        link.href = url;
        link.setAttribute('download', namefile + `-` + yyyy + mm + dd + hh + mn + sc + `.xlsx`);
        document.body.appendChild(link);
        link.click();
      }

      this.showerror_excel = true;
      this.responseerror_excel = "";
    } catch (error) {
      console.log('RES ERROR: ', error.response)
      this.showerror_excel = false;
      this.responseerror_excel = "! ไม่สามารถ download file ได้ เนื่องจากไม่พบข้อมูล";
    }
  }

  async exportHistory() {
    const today = new Date();
    const dd = ("0" + today.getDate()).slice(-2);
    const mm = ("0" + (today.getMonth() + 1)).slice(-2);
    const yyyy = today.getFullYear();
    if (this.apiDatestart === undefined) {
      this.apiDatestart = yyyy + "-" + mm + "-" + dd;
    }
    if (this.apiDateend === undefined) {
      this.apiDateend = yyyy + "-" + mm + "-" + dd;
    }
    if (this.sh_wc !== undefined && this.sh_model !== undefined && this.sh_process !== undefined && this.sh_cell !== undefined && this.sh_shift !== undefined) {
      const params = {
        start_date: this.apiDatestart,
        end_date: this.apiDateend,
        wc_code: this.sh_wc.value,
        model_code: this.sh_model.value,
        process_code: this.sh_process.value,
        cell_code: this.sh_cell.value,
        shift_code: this.sh_shift.value
      }
      this.exportExcel(params, "HistoryReport", "/Summary/exportHistory");
    }
  }
}