import { Injectable } from '@angular/core';

export interface Menu {
  state: string;
  name: string;
  type: string;
  icon: string;
}

const MENUITEMS = [
  { state: 'home', type: 'link', name: 'Home', icon: 'baseline_home_white_24dp' },
  { state: 'report', type: 'link', name: 'Report Summary', icon: 'documents-case' },
  // { state: 'bar-chart', type: 'link', name: 'Dashboard', icon: 'baseline_insert_chart_white_24dp' },
];

@Injectable()
export class MenuItems {
  getMenuitem(): Menu[] {
    return MENUITEMS;
  }
}
