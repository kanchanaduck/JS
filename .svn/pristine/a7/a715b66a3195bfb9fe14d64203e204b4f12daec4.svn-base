import { Component, OnInit } from '@angular/core';
import { ChartDataSets, ChartOptions, ChartType } from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Label } from 'ng2-charts';

@Component({
  selector: 'app-bar-chart2',
  templateUrl: './bar-chart2.component.html',
  styleUrls: ['./bar-chart2.component.css']
})
export class BarChart2Component implements OnInit {

  public barChartOptions: ChartOptions = {
    responsive: true,
    scales: { xAxes: [{}], yAxes: [{}] },
    plugins: {
      datalabels: {
        color: 'white',
      }
    }
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
    { backgroundColor: ['#062555'] },
    { backgroundColor: ['#EBEBD3'] },

    { backgroundColor: ['#09357a'] },
    { backgroundColor: ['#89b7ff'] },

    { backgroundColor: ['#023957'] },
    { backgroundColor: ['#83d3ff'] },
  ];


  constructor() { }

  ngOnInit(): void {
  }

}
