import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ServiceSettingService {

  items:any = [];
  page:any = [];
  
  constructor() { }

  addToData(data:any) {
    this.items.push(data);
  }

  getItems() {
    console.log('service ',this.items)
    return this.items;
  }

  clearItems() {
    this.items = [];
    return this.items;
  }


  dialog_detail(page:any){
    this.page.push(page);
  }
  getdialog_detail() {
    console.log('dialog: ',this.page)
    return this.page;
  }
  cleardialog_detail() {
    this.page = [];
    return this.page;
  }

}
