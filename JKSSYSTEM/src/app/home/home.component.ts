import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { environment } from '../../environments/environment';
import { ServiceJksService } from '../service-jks.service';
import Swal from 'sweetalert2'
// Dialog
import { MatDialog } from '@angular/material/dialog';
import { BarChartComponent } from '../bar-chart/bar-chart.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})

export class HomeComponent implements OnInit {
  userid: any;
  userright: any;
  tf: any;
  get_service: any;
  get_serviceov: any;
  constructor(private serviceJksService: ServiceJksService, public dialog: MatDialog) { }

  arrBirds: string[] = [];
  sh: any;
  submitSearch() {
    this.get_service = this.serviceJksService.getsv_update();
    if (this.get_service.length !== 0) {
      // console.log('aa: ', this.get_service);
      const a = {
        "date_input": this.get_service[this.get_service.length - 1].date_input,
        "wc_code": this.get_service[this.get_service.length - 1].wc_code,
        "model_code": this.get_service[this.get_service.length - 1].model_code,
        "process_code": this.get_service[this.get_service.length - 1].process_code,
        "cell_code": this.get_service[this.get_service.length - 1].cell_code,
        "shift_code": this.get_service[this.get_service.length - 1].shift_code,
        "production_shift": this.get_service[this.get_service.length - 1].production_shift,
        "block_group_code": this.get_service[this.get_service.length - 1].block_group_code,
        "gb_cell_code": this.get_service[this.get_service.length - 1].gb_cell_code
      };

      // console.log('a: ', a);
      this.search(a);
      this.search_temp(a);
      this.search_barchart(a);
    }
  }
  items: any
  v_sum: number = 0;
  v_sum_extrawork: number = 0;
  v_sum_jobspecial: number = 0;
  serv: any = [];
  temp: any
  loss: any;
  async search(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      const response = await instance.post('/Summary/SummaryAll/Search', params)
      console.log("summaryall: ", response.data);

      response.data.check_overtime = params.production_shift;
      this.items = this.serviceJksService.clearservice_search();
      this.items = this.serviceJksService.service_search(response.data)

      return response.data;

    } catch (error) {
      // console.log('RES ERROR SummaryAll/Search: ', error.response)
      // if (error.response.status === 400) {
      this.items = this.serviceJksService.clearservice_search();
      const a = {
        check_overtime: params.production_shift
      }
      this.items = this.serviceJksService.service_search(a)
    }
  }

  tss: any = [];
  async getTss() {
    try {
      const response = await axios.get(environment.apijks + '/Master/Tss');
      this.tss = response.data;
      // console.log(this.tss);

    } catch (error) {
      console.error(error.stack);
    }
  }
  async search_temp(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      const response = await instance.post('/SummaryTemp/Tss/Search', params)
      console.log("search_temp: ", response.data);

      let sum = 0;
      let sum_extrawork = 0;
      let sum_jobspecial = 0;
      for (let i = 0; i < response.data.length; i++) {
        sum += response.data[i].loss_time;
        this.v_sum = sum; //console.log("v_sum: ", this.v_sum);

        let chk_extrawork = this.tss.some((x: any) => x.tss_code == parseInt(response.data[i].tss_code) && x.cal_extrawork == true);
        let chk_jobspecial = this.tss.some((x: any) => x.tss_code == parseInt(response.data[i].tss_code) && x.cal_jobspecial == true);

        // if (response.data[i].tss_code === "160") {
        if (chk_extrawork == true) {
          sum_extrawork += response.data[i].loss_time;
          this.v_sum_extrawork = sum_extrawork; //console.log("v_sum_extrawork: ", this.v_sum_extrawork);
        }
        // if (response.data[i].tss_code === "150") {
        if (chk_jobspecial == true) {
          sum_jobspecial += response.data[i].loss_time;
          this.v_sum_jobspecial = sum_jobspecial; //console.log("v_sum_jobspecial: ", this.v_sum_jobspecial);
        }
      }

      const a = {
        total_losstime: this.v_sum,
        sum_extrawork: this.v_sum_extrawork,
        sum_jobspecial: this.v_sum_jobspecial
      }
      this.loss = this.serviceJksService.clearsv_losstime_total();
      this.loss = this.serviceJksService.sv_losstime_total(a);

      this.temp = this.serviceJksService.clearsv_losstime();
      this.temp = this.serviceJksService.sv_losstime(response.data)

      return response.data;
    } catch (error) {
      console.log('RES ERROR: ', error.response)
    }
  }
  barchart: any;
  async search_barchart(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      // console.log("data: ", params);
      const response = await instance.post('/Summary/barchart', params)
      console.log("barchart: ", response);

      response.data.ps = params.production_shift;
      this.barchart = this.serviceJksService.clearservice_barchart();
      this.barchart = this.serviceJksService.service_barchart(response.data)

      return response.data;
    } catch (error) {
      console.log('RES ERROR: ', error.response)

      this.barchart = this.serviceJksService.clearservice_barchart();
      const a = {
        ps: params.production_shift
      }
      this.barchart = this.serviceJksService.service_barchart(a)
    }
  }

  get_workingman: any;
  submitUpdate() {
    this.get_service = this.serviceJksService.getsv_update();
    this.get_serviceov = this.serviceJksService.getsv_over();
    this.get_workingman = this.serviceJksService.getsv_workingman();
    if (this.get_service.length !== 0) {
      const b = {
        "homgkey": this.get_service[this.get_service.length - 1],
        "overtime": this.get_serviceov[this.get_serviceov.length - 1],
        "workingman": this.get_workingman[this.get_workingman.length - 1]
      }
      var body = Object.assign({}, b.homgkey, b.overtime, b.workingman);
      body.userid = this.userid;
      console.log('body', body);

      if (this.get_service[this.get_service.length - 1].block_group_code === undefined ||
        this.get_service[this.get_service.length - 1].gb_cell_code === undefined) {
        Swal.fire({
          icon: 'warning',
          title: 'กรุณาเลือกข้อมูล',
          text: 'Block Group หรือ Gobal Cell Code'
        })
      } else {
        addData(body);
      }
    }
  }
  submitClear() {
    window.location.reload();
  }
  submitDelete() {
    this.get_service = this.serviceJksService.getsv_update();
    if (this.get_service.length !== 0) {
      // console.log('aa: ', this.get_service[0]);
      const a = {
        "date_input": this.get_service[0].date_input,
        "wc_code": this.get_service[0].wc_code,
        "model_code": this.get_service[0].model_code,
        "process_code": this.get_service[0].process_code,
        "cell_code": this.get_service[0].cell_code,
        "shift_code": this.get_service[0].shift_code,
        "production_shift": this.get_service[0].production_shift
      };
      // console.log(a)
      Swal.fire({
        title: 'คุณต้องการลบข้อมูลใช่หรือไม่',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: 'ใช่',
        cancelButtonText: 'ไม่'
      }).then(async (result) => {
        if (result.value) {
          deleteData(a);
        }
      })
    }
  }
  clickbarchart() {
    const dialogRef = this.dialog.open
      (BarChartComponent, {
        width: '80%',
      });

    dialogRef.afterClosed().subscribe(async result => {
      console.log('dialog Closed')
    });
  }

  async ngOnInit() {
    this.userid = localStorage.getItem('userid');
    this.userright = localStorage.getItem('userright');
    this.tf = false;
    if (this.userright !== "Viewer") {
      this.tf = true;
    }

    await this.getTss();
  }

  ngOnDestroy() {
    this.items = this.serviceJksService.clearservice_search();
    this.temp = this.serviceJksService.clearsv_losstime();
    this.loss = this.serviceJksService.clearsv_losstime_total();
    this.barchart = this.serviceJksService.clearservice_barchart();
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

    // console.log('datas: ', datas)
    const response = await instance.post('/Summary/SummaryAll/Add', datas)

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'บันทึกข้อมูลเสร็จเรียบร้อยแล้ว.',
      showConfirmButton: false,
      timer: 1500
    })

    // console.log("post: ", response);
    return response.data;

  } catch (error) {
    console.log('RES ERROR: ', error.response)

    Swal.fire({
      icon: 'error',
      title: error.response.status,
      text: error.response.data
    })
  }
}

async function deleteData(datas: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks
    });

    // console.log(datas)
    const response = await instance.post('/Summary/SummaryAll/Delete', datas)
    // console.log("delete: ", response);

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'ลบข้อมูลเสร็จเรียบร้อย.',
      showConfirmButton: false,
      timer: 1500
    })

    window.location.reload();

    return response.data;
  } catch (error) {
    console.log('RES ERROR: ', error.response)

    Swal.fire({
      icon: 'error',
      title: error.response.status,
      text: error.response.data
    })
  }
}