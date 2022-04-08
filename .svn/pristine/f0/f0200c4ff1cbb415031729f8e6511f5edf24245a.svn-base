import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Label } from 'ng2-charts';
import { multi } from '../bar-chart/data';

@Component({
  selector: 'app-bar-chart3',
  templateUrl: './bar-chart3.component.html',
  styleUrls: ['./bar-chart3.component.css']
})
export class BarChart3Component implements OnInit {
  public barChartOptions: ChartOptions = {
    responsive: true,
    scales: { xAxes: [{}], yAxes: [{}] },
  };
  public barChartLabels: Label[] = ['2020'];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [pluginDataLabels];

  public barChartData: ChartDataSets[] = [
    { barThickness: 100, maxBarThickness: 80, data: [2790], label: 'Total Working Time', stack: 'a' },
    { barThickness: 100, maxBarThickness: 80, data: [], label: '', stack: 'a' },

    { barThickness: 100, maxBarThickness: 80, data: [2590], label: 'Total actual time', stack: 'b' },
    { barThickness: 100, maxBarThickness: 80, data: [200], label: 'Non-working time', stack: 'b' },

    { barThickness: 100, maxBarThickness: 80, data: [1427], label: 'Total standard time', stack: 'c' },
    { barThickness: 100, maxBarThickness: 80, data: [1163], label: 'PF Loss', stack: 'c' }
  ];

  public barChartColors = [
    { backgroundColor: ['#6bb385'] },
    { backgroundColor: ['#EBEBD3'] },

    { backgroundColor: ['#89b7ff'] },
    { backgroundColor: ['#EBEFBF'] },

    { backgroundColor: ['#A2999E'] },
    { backgroundColor: ['#F4D35E'] },
  ];


  constructor() { }

  ngOnInit(): void {
  }
}
