import { Injectable } from '@angular/core';
import axios from 'axios';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ServiceJksService {
  
  items: any = [];
  page: any = [];
  data: any = [];
  overtime: any = [];
  s_update: any = [];

  constructor() { }
  /////////////////////////////////////////////////////////////////////// Items
  addItems(item: any) {
    this.items.push(item);
  }
  getItems() {
    // console.log('getItems: ', this.items)
    return this.items;
  }
  clearItems() {
    this.items = [];
    return this.items;
  }
  /////////////////////////////////////////////////////////////////////// dialog_detail
  adddialog_detail(page: any) {
    this.page.push(page);
  }
  getdialog_detail() {
    // console.log('getdialog_detail: ', this.page)
    return this.page;
  }
  cleardialog_detail() {
    this.page = [];
    return this.page;
  }
  /////////////////////////////////////////////////////////////////////// Data
  addData(d: any) {
    // console.log('addData: ', d)
    this.data.push(d);
  }
  getData() {
    // console.log('getData: ', this.data)
    return this.data;
  }
  clearData() {
    this.data = [];
    return this.data;
  }
  /////////////////////////////////////////////////////////////////////// overtime
  addovertime(o: any) {
    // console.log('addovertime: ', o)
    this.overtime.push(o);
  }
  getovertime() {
    // console.log('getovertime: ', this.overtime)
    return this.overtime;
  }
  clearovertime() {
    this.overtime = [];
    return this.overtime;
  }
  /////////////////////////////////////////////////////////////////////// sv_update
  sv_update(d: any) {
    // console.log('sv_update: ', d)
    this.s_update.push(d);
  }
  getsv_update() {
    // console.log('getsv_update: ', this.s_update)
    return this.s_update;
  }
  clearsv_update() {
    this.s_update = [];
    return this.s_update;
  }
  /////////////////////////////////////////////////////////////////////// sv_over
  over: any = [];
  sv_over(d: any) {
    // console.log('sv_over: ', d)
    this.over.push(d);
  }
  getsv_over() {
    // console.log('getsv_over: ', this.s_update)
    return this.over;
  }
  clearsv_over() {
    this.over = [];
    return this.over;
  }
  /////////////////////////////////////////////////////////////////////// sv_workingman
  workingman: any = [];
  sv_workingman(d: any) {
    // console.log('workingman: ', d)
    this.workingman.push(d);
  }
  getsv_workingman() {
    // console.log('workingman: ', this.workingman)
    return this.workingman;
  }
  clearsv_workingman() {
    this.workingman = [];
    return this.workingman;
  }
  /////////////////////////////////////////////////////////////////////// sv_losstime
  losstime: string = "";
  sv_losstime(d: any) {
    // console.log('sv_losstime: ', d)
    this.losstime = d;
  }
  getsv_losstime() {
    // console.log('getsv_losstime: ', this.losstime)
    return this.losstime;
  }
  clearsv_losstime() {
    this.losstime = "";
    return this.losstime;
  }
  /////////////////////////////////////////////////////////////////////// sv_losstime_total
  _total: string = "";
  sv_losstime_total(d: any) {
    // console.log('_total: ', d)
    this._total = d;
  }
  getsv_losstime_total() {
    // console.log('_total: ', this._total)
    return this._total;
  }
  clearsv_losstime_total() {
    this._total = "";
    // console.log('clearsv_losstime_total: ', this._total)
    return this._total;
  }
  /////////////////////////////////////////////////////////////////////// Actual
  actual: string = "";
  addActual(d: any) {
    // console.log('addData: ', d)
    this.actual = d;
  }
  getActual() {
    // console.log('actual: ', this.actual)
    return this.actual;
  }
  clearActual() {
    this.actual = "";
    return this.actual;
  }
  /////////////////////////////////////////////////////////////////////// Actual OP + SP
  actual_op_sp: string = "";
  addActualOPSP(d: any) {
    // console.log('addData: ', d)
    this.actual_op_sp = d;
  }
  getActualOPSP() {
    // console.log('actual: ', this.actual)
    return this.actual_op_sp;
  }
  clearActualOPSP() {
    this.actual_op_sp = "";
    return this.actual_op_sp;
  }
  /////////////////////////////////////////////////////////////////////// service_search
  search: any = [];
  service_search(d: any) {
    // console.log('service_search: ', d)
    this.search.push(d);
  }
  getservice_search() {
    // console.log('getservice_search: ', this.search)
    return this.search;
  }
  clearservice_search() {
    this.search = [];
    // console.log('clearservice_search: ', this.search)
    return this.search;
  }
  /////////////////////////////////////////////////////////////////////// service_prodouction
  prodouction: any = [];
  service_prodouction(d: any) {
    // console.log('prodouction: ', d)
    this.prodouction.push(d);
  }
  getservice_prodouction() {
    // console.log('getservice_prodouction: ', this.prodouction)
    return this.prodouction;
  }
  clearservice_prodouction() {
    this.prodouction = [];
    // console.log('clearservice_prodouction: ', this.prodouction)
    return this.prodouction;
  }
  /////////////////////////////////////////////////////////////////////// service_barchart
  barchart: any = [];
  service_barchart(d: any) {
    // console.log('service_barchart: ', d)
    this.barchart.push(d);
  }
  getservice_barchart() {
    // console.log('getservice_barchart: ', this.barchart)
    return this.barchart;
  }
  clearservice_barchart() {
    this.barchart = [];
    // console.log('clearservice_barchart: ', this.barchart)
    return this.barchart;
  }
  /////////////////////////////////////////////////////////////////////// user_profile
  u:any = [];
  user_profile(data: any) {
    this.u.push(data);
  }
  getuser_profile() {
    return this.u;
  }

  clearuser_profile() {
    this.u = [];
    return this.u;
  }
  ///////////////////////////////////////////////////////////////////// service api
  async s_get(url: any) {
    try {
      const response = await axios.get(environment.api + url, { headers: { Pragma: 'no-cache' } });

      return response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }

}
