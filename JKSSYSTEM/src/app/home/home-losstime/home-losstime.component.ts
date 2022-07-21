import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Dialog
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogHomeComponent } from '../dialog-home/dialog-home.component';
// Service
import { ServiceJksService } from '../../service-jks.service';

import { environment } from '../../../environments/environment';
import { FormControl, Validators } from '@angular/forms';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-home-losstime',
  templateUrl: './home-losstime.component.html',
  styleUrls: ['../home.component.css']
})
export class HomeLosstimeComponent implements OnInit {
  userid: any;
  userright: any;
  tf: any;
  displayedColumns: string[] = ['action', 'otherjob', 'tss_code', 'extra_work_no', 'manpower_pers', 'tss_min', 'mc_qty', 'respond', 'loss_time'];
  dataSource: any;
  getData: any;
  values: string = "";
  @ViewChild('txtworkno') txtworkno: any;
  @ViewChild('txtman') txtman: any;
  @ViewChild('txttss') txttss: any;
  @ViewChild('txtqty') txtqty: any;
  @ViewChild('txtresponsible') txtresponsible: any;
  strcss: any;
  strdid: any;
  v_sum: number = 0;
  v_sum_extrawork: number = 0;
  v_sum_jobspecial: number = 0;
  serv: any = [];
  get_service: any;
  get_sv_update: any;
  get: any;
  get_loss: any;

  constructor(
    public dialog: MatDialog,
    private serviceJksService: ServiceJksService
  ) {
  }

  tssControl = new FormControl('', Validators.required);
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
  sh_tss: any;
  selectChang(event: any) {
    // this.tssControl.setValue("");
    this.txtworkno.nativeElement.value = "";
    this.txtman.nativeElement.value = "";
    this.txttss.nativeElement.value = "";
    this.txtqty.nativeElement.value = "";
    this.txtresponsible.nativeElement.value = "";
    this.values = "";

    this.sh_tss = {
      value: event.value,
      text: event.source.triggerValue
    };
    // console.log('sh_tss: ', this.sh_tss);
    // console.log('sh_tss: ', this.sh_tss.value);
    let chk_arry = this.tss.some((x:any) => x.tss_code == this.sh_tss.value && x.cal_qty == true);
    // console.log(chk_arry);

    if (chk_arry) {
      this.strcss = "input-bgcolor";
      this.strdid = false;
    } else {
      this.strcss = "";
      this.strdid = true;
    }
  }


  error: any = {
    manpower: true,
    tss: true,
    qty: true,
  };


  onKey(event: any) { 

    let manpower: any = (isNaN(this.txtman.nativeElement.value) || this.txtman.nativeElement.value==="")? 1: this.txtman.nativeElement.value
    let tss: any = (isNaN(this.txttss.nativeElement.value) || this.txttss.nativeElement.value==="")? 1: parseFloat(this.txttss.nativeElement.value).toFixed(2)
    let qty: any = (isNaN(this.txtqty.nativeElement.value) || this.txtqty.nativeElement.value==="")? 1: this.txtqty.nativeElement.value

    this.error.manpower = manpower<1 || this.txtman.nativeElement.value==="" ? true:false;
    this.error.tss = tss<0 || this.txttss.nativeElement.value==="" ? true:false;
    this.error.qty = !this.strdid && ( qty<1 || this.txtqty.nativeElement.value==="") ? true:false;

    this.values = parseFloat((manpower  * tss * (this.strdid? 1: qty)).toString()).toFixed(2);
    
  }

  async submit() {
    if (this.sh_tss) {
      this.get_service = this.serviceJksService.getsv_update();
      if (this.get_service.length !== 0) {
        // console.log('aa: ', this.get_service[this.get_service.length - 1]);
        const a = {
          "date_input": this.get_service[this.get_service.length - 1].date_input,
          "wc_code": this.get_service[this.get_service.length - 1].wc_code,
          "model_code": this.get_service[this.get_service.length - 1].model_code,
          "process_code": this.get_service[this.get_service.length - 1].process_code,
          "cell_code": this.get_service[this.get_service.length - 1].cell_code,
          "shift_code": this.get_service[this.get_service.length - 1].shift_code,
          "production_shift": this.get_service[this.get_service.length - 1].production_shift,
          "block_group_code": this.get_service[this.get_service.length - 1].block_group_code,
          "gb_cell_code": this.get_service[this.get_service.length - 1].gb_cell_code,
          "tss_code": this.sh_tss.value,
          "extra_work_no": this.txtworkno.nativeElement.value,
          "manpower_pers": (isNaN(parseInt(this.txtman.nativeElement.value)) ? null : parseInt(this.txtman.nativeElement.value)),
          "tss_min": (isNaN(this.txttss.nativeElement.value) ? null : this.txttss.nativeElement.value),
          "mc_qty": (isNaN(parseInt(this.txtqty.nativeElement.value)) ? null : parseInt(this.txtqty.nativeElement.value)),
          "respond": this.txtresponsible.nativeElement.value,
          "loss_time": this.values,
          "ins_by": this.userid,
        };

        // console.log('a: ', a);
        this.addData(a);
      }
    }
  }

  openDialog(data: any) {
    // console.log(data)
    this.serviceJksService.addItems(data);  // ส่งค่า row ไปที่ fn addToData

    const dialogRef = this.dialog.open
      (DialogHomeComponent, {
        width: '90%',
        data: { data: data }
      });

    dialogRef.afterClosed().subscribe(async result => {
      console.log('The dialog was closed');
      // this.getData = result;

      this.get_sv_update = this.serviceJksService.getsv_update();
      this.get_service = this.serviceJksService.getservice_search();
      // console.log(this.get_sv_update);
      // console.log(this.get_service);
      const a = {
        "date_input": this.get_sv_update[0].date_input,
        "wc_code": this.get_sv_update[0].wc_code,
        "model_code": this.get_sv_update[0].model_code,
        "process_code": this.get_sv_update[0].process_code,
        "cell_code": this.get_sv_update[0].cell_code,
        "shift_code": this.get_sv_update[0].shift_code,
        "production_shift": this.get_sv_update[0].production_shift,
        "block_group_code": this.get_sv_update[0].block_group_code,
        "gb_cell_code": this.get_sv_update[0].gb_cell_code,
        "tss_code": data.tss_code
      };
      // console.log(a);
      this.search_temp(a);
    });
  }
  openDialogDelete(data: any) {
    Swal.fire({
      title: 'คุณต้องการลบข้อมูลใช่หรือไม่',
      text: 'delete : ' + data.tss_code,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'ใช่',
      cancelButtonText: 'ไม่'
    }).then(async (result) => {
      if (result.value) {
        this.get_sv_update = this.serviceJksService.getsv_update();
        this.get_service = this.serviceJksService.getservice_search();
        const a = {
          "date_input": this.get_sv_update[0].date_input,
          "wc_code": this.get_sv_update[0].wc_code,
          "model_code": this.get_sv_update[0].model_code,
          "process_code": this.get_sv_update[0].process_code,
          "cell_code": this.get_sv_update[0].cell_code,
          "shift_code": this.get_sv_update[0].shift_code,
          "production_shift": this.get_service[0].production_shift,
          "block_group_code": this.get_service[0].block_group_code,
          "gb_cell_code": this.get_service[0].gb_cell_code,
          "tss_code": data.tss_code,
          "extra_work_no": data.extra_work_no
        };
        // console.log('a: ', a);

        await this.deleteData(a);
      } else if (result.dismiss === Swal.DismissReason.cancel) {
      }
    })
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

  get_losstime_total: any;
  v_totallosstime: any;

  async ngDoCheck() {
    this.get_service = this.serviceJksService.getservice_search();
    if (this.get_service.length > 0) {
      this.get_loss = this.serviceJksService.getsv_losstime();
      // console.log('aa: ', this.get_loss.length);
      this.dataSource = this.get_loss
      // console.log('bb: ', this.dataSource);
    }
    this.get_losstime_total = this.serviceJksService.getsv_losstime_total();
    // console.log('bb: ', this.get_losstime_total);
    if (this.get_losstime_total.length !== "") {
      this.v_totallosstime = this.get_losstime_total.total_losstime === undefined ? 0 : this.get_losstime_total.total_losstime;
    }
  }

  async addData(datas: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });

      // console.log('datas: ', datas)
      const response = await instance.post('/SummaryTemp/Tss/Add', datas)

      this.search_temp(datas);

      // console.log("post addData: ", response);
      return response.data;
    } catch (error) {
      console.log(error.response.status)
      console.log('RES ERROR: ', error.response)

      Swal.fire({
        icon: 'error',
        title: error.response.status,
        text: error.response.data
      })
    }
  }

  temp: any
  async search_temp(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });
      const response = await instance.post('/SummaryTemp/Tss/Search', params)
      // console.log("search_temp tss: ", response);

      let sum = 0;
      let sum_extrawork = 0;
      let sum_jobspecial = 0;
      for (let i = 0; i < response.data.length; i++) {
        sum += response.data[i].loss_time;
        this.v_sum = sum; //console.log("v_sum: ", this.v_sum);

        let chk_extrawork = this.tss.some((x:any) => x.tss_code == parseInt(response.data[i].tss_code) && x.cal_extrawork == true);
        let chk_jobspecial = this.tss.some((x:any) => x.tss_code == parseInt(response.data[i].tss_code) && x.cal_jobspecial == true);
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
      // console.log('a: ', a);

      this.serviceJksService.clearsv_losstime_total();
      this.serviceJksService.sv_losstime_total(a);

      this.temp = this.serviceJksService.clearsv_losstime();
      this.temp = this.serviceJksService.sv_losstime(response.data)

      this.get_loss = await this.serviceJksService.getsv_losstime();
      // console.log('this.get_loss: ', this.get_loss);
      this.dataSource = await this.get_loss;

      return response.data;
    } catch (error) {
      console.log('RES ERROR: ', error.response)
    }
  }

  async deleteData(datas: any) {
    try {
      const response = await axios.post(environment.apijks + '/SummaryTemp/Tss/Delete', datas)
      // console.log("delete: ", response);

      Swal.fire({
        toast: true,
        position: 'top-end',
        icon: 'success',
        title: 'ลบข้อมูลเสร็จเรียบร้อย.',
        showConfirmButton: false,
        timer: 1500
      })

      this.search_temp(datas);

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

}