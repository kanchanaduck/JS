import { Component, OnInit, ViewChild } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Label } from 'ng2-charts';
import axios from 'axios';
import { environment } from '../../environments/environment';
import { ServiceJksService } from '../service-jks.service';
import { isNull } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})
export class BarChartComponent implements OnInit {

  constructor(private serviceJksService: ServiceJksService) { }

  get_service: any;
  total_working_time: number = 0;
  total_actual_time: number = 0;
  non_working_time: number = 0;
  total_standard_time: number = 0;
  pf_loss: number = 0;
  gb_cell_code: string = "";
  process_detail: string = "";
  production_shift: string = "";

  barChartLabels: Label[] = [];
  barChartData: ChartDataSets[] = []


  async ngOnInit() {
    this.get_service = this.serviceJksService.getservice_barchart();
    if (this.get_service.length > 0) {
      // console.log('aa: ', this.get_service[0]);
      // console.log('aa: ', this.get_service[0].years);
      // console.log('aa: ', this.get_service[0].gb_cell_code);
      // console.log('aa: ', this.get_service[0].process_detail);
      // console.log('aa: ', this.get_service[0].ps);

      this.total_working_time = this.get_service[0].total_working_time;
      this.total_actual_time = this.get_service[0].total_actual_time;
      this.non_working_time = this.get_service[0].non_working_time;
      this.total_standard_time = this.get_service[0].total_standard_time;
      this.pf_loss = this.get_service[0].pf_loss;

      this.gb_cell_code = this.get_service[0].gb_cell_code;
      this.process_detail = this.get_service[0].process_detail;
      this.production_shift = this.get_service[0].ps;

      this.barChartLabels = [this.get_service[0].years === undefined ? '' : this.get_service[0].years];
      this.barChartData = [
        { barThickness: 100, maxBarThickness: 80, data: [this.total_working_time], label: 'Total Working Time', stack: 'a' },
        { barThickness: 100, maxBarThickness: 80, data: [], label: '', stack: 'a' },

        { barThickness: 100, maxBarThickness: 80, data: [this.total_actual_time], label: 'Total actual time', stack: 'b' },
        { barThickness: 100, maxBarThickness: 80, data: [this.non_working_time], label: 'Non-working time', stack: 'b' },

        { barThickness: 100, maxBarThickness: 80, data: [this.total_standard_time], label: 'Total standard time', stack: 'c' },
        { barThickness: 100, maxBarThickness: 80, data: [this.pf_loss], label: 'PF Loss', stack: 'c' }
      ];
    }
    // const a = {
    //   "date_input": "2020-10-15",
    //   "wc_code": "WC-004",
    //   "model_code": "M-013",
    //   "process_code": "P-037",
    //   "cell_code": "C-003",
    //   "shift_code": "S-002",
    //   "production_shift": "2"
    // }
  }

  public barChartOptions: ChartOptions = {
    responsive: true,
    plugins: {
      datalabels: {
        color: 'white',
        // font: {
        //   size: 16
        // }
      }
    }
  };
  // public barChartLabels: Label[] = ['2020'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [pluginDataLabels];

  // public barChartData: ChartDataSets[] = [
  //   { barThickness: 100, maxBarThickness: 80, data: [ 2760 ], label: 'Total Working Time', stack: 'a' },
  //   { barThickness: 100, maxBarThickness: 80, data: [], label: '', stack: 'a' },

  //   { barThickness: 100, maxBarThickness: 80, data: [2590], label: 'Total actual time', stack: 'b' },
  //   { barThickness: 100, maxBarThickness: 80, data: [200], label: 'Non-working time', stack: 'b' },

  //   { barThickness: 100, maxBarThickness: 80, data: [1427], label: 'Total standard time', stack: 'c' },
  //   { barThickness: 100, maxBarThickness: 80, data: [1163], label: 'PF Loss', stack: 'c' }
  // ];

  public barChartColors = [
    { backgroundColor: ['#062555'] },
    { backgroundColor: ['#EBEBD3'] },

    { backgroundColor: ['#09357a'] },
    { backgroundColor: ['#89b7ff'] },

    { backgroundColor: ['#0059b2'] },
    { backgroundColor: ['#80c0ff'] },
  ];

  ngOnDestroy() {
    // this.get_service = this.serviceJksService.clearservice_barchart();
  }

}