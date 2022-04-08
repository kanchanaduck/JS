import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { environment } from '../../../environments/environment';
import axios from 'axios';
import { ServiceJksService } from '../../service-jks.service';
import Swal from 'sweetalert2'

@Component({
  selector: 'app-dialog-home',
  templateUrl: './dialog-home.component.html',
  styleUrls: ['../home.component.css']
})
export class DialogHomeComponent implements OnInit {
  items: any;
  values: number = 0;
  @ViewChild('txtworkno') txtworkno: any;
  @ViewChild('txtman') txtman: any;
  @ViewChild('txttss') txttss: any;
  @ViewChild('txtqty') txtqty: any;
  @ViewChild('txtresponsible') txtresponsible: any;
  strcss: any;
  strdid: any;

  constructor(private serviceJksService: ServiceJksService) { }

  tssControl = new FormControl('', Validators.required);
  tss: any = [];
  async getTss() {
    try {
      const response = await axios.get(environment.apijks + '/Master/Tss');
      this.tss = response.data;
    } catch (error) {
      console.error(error.stack);
    }
  }
  sh_tss: any;
  selectChang(event: any) {
    this.sh_tss = {
      value: event.value,
      text: event.source.triggerValue
    };
    console.log(this.sh_tss);

    let chk_arry = this.tss.some((x:any) => x.tss_code == this.sh_tss.value && x.cal_qty == true);
    // console.log(chk_arry);
    // if (this.sh_tss.text === '150 : Special Job' || this.sh_tss.text === '160 : Extra Work') {
    if (chk_arry) {
      this.strcss = "input-bgcolor";
      this.strdid = false;
    } else {
      this.strcss = "";
      this.strdid = true;
    }
  }
  onKey1(event: any) { // without type info
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txttss.nativeElement.value))) {
      this.values = parseInt(event.target.value) * parseInt(this.txttss.nativeElement.value);
    }
  }
  onKey(event: any) { // without type info
    if (!isNaN(parseInt(event.target.value) * parseInt(this.txtman.nativeElement.value))) {
      this.values = parseInt(event.target.value) * parseInt(this.txtman.nativeElement.value);
    }
  }

  get_service: any;
  get_sv_update: any;
  submit() {
    if (this.sh_tss === undefined || this.sh_tss.value === undefined) {
      this.sh_tss = this.items[0].tss_code;
    } else {
      this.sh_tss = this.sh_tss.value;
    }

    // console.log('this.sh_tss: ',this.sh_tss)
    this.get_sv_update = this.serviceJksService.getsv_update();
    this.get_service = this.serviceJksService.getservice_search();
    const d = {
      "date_input": this.get_sv_update[0].date_input,
      "wc_code": this.get_sv_update[0].wc_code,
      "model_code": this.get_sv_update[0].model_code,
      "process_code": this.get_sv_update[0].process_code,
      "cell_code": this.get_sv_update[0].cell_code,
      "shift_code": this.get_sv_update[0].shift_code,
      "production_shift": this.get_service[0].production_shift,
      "block_group_code": this.get_service[0].block_group_code,
      "gb_cell_code": this.get_service[0].gb_cell_code,
      "tss_code": this.sh_tss,
      "extra_work_no": this.txtworkno.nativeElement.value,
      "manpower_pers": parseInt(this.txtman.nativeElement.value),
      "tss_min": parseInt(this.txttss.nativeElement.value),
      "mc_qty": parseInt(this.txtqty.nativeElement.value),
      "respond": this.txtresponsible.nativeElement.value,
      "loss_time": parseInt(this.values.toString())
    };

    // console.log("d: ", d);
    editData(d);
  }

  async ngOnInit() {
    await this.getTss();

    this.items = this.serviceJksService.getItems();
    console.log('this.items', this.items);

    console.log('tss_code: ', parseInt(this.items[0].tss_code));
    this.tssControl.setValue(this.items[0].tss_code);

    let chk_arry = this.tss.some((x:any) => x.tss_code == parseInt(this.items[0].tss_code) && x.cal_qty == true);
    console.log(chk_arry);
    // if (this.items[0].tss_code === '150' || this.items[0].tss_code === '160') {
    if (chk_arry) {
      this.strcss = "input-bgcolor";
      this.strdid = false;
    } else {
      this.strcss = "";
      this.strdid = true;
    }

  }
  ngOnDestroy() {
    this.items = this.serviceJksService.clearItems();
  }
}

async function editData(datas: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json'
      }
    });
    const response = await instance.put('/SummaryTemp/Tss/Edit', datas)

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'แก้ไขข้อมูลเสร็จเรียบร้อย.',
      showConfirmButton: false,
      timer: 1500
    })

    // console.log("put: ", response);
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