import { Component, OnInit, ViewChild } from '@angular/core';
import axios from 'axios';
// Service
import { ServiceJksService } from '../../service-jks.service';
import { environment } from '.../../environments/environment';
import Swal from 'sweetalert2'
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-dialog-userprofile',
  templateUrl: './dialog-userprofile.component.html',
  styleUrls: []
})
export class DialogUserprofileComponent implements OnInit {
  items: any;
  headers: any;
  button: any;
  getData: any;

  options: FormGroup;
  floatLabelControl = new FormControl('User');
  checked: any = 0;
  @ViewChild('fname') fname: any;
  @ViewChild('lname') lname: any;
  @ViewChild('userid') userid: any;
  @ViewChild('password') password: any;

  constructor(fb: FormBuilder,
    private serviceJksService: ServiceJksService
  ) {
    this.options = fb.group({
      floatLabel: this.floatLabelControl,
    });
  }

  onChange(e: any) {
    if (e.checked === true) {
      this.checked = 1; console.log(this.checked);
    } else {
      this.checked = 0; console.log(this.checked);
    }
  }

  submit(button: any, datas: any) {
    if (this.fname.nativeElement.value != "" && this.lname.nativeElement.value != ""
      && this.userid.nativeElement.value != "" && this.password.nativeElement.value != "") {
      if (button == "Add") {
        const a = {
          "userid": this.userid.nativeElement.value,
          "fname": this.fname.nativeElement.value,
          "lname": this.lname.nativeElement.value,
          "password": this.password.nativeElement.value,
          "userright": this.floatLabelControl.value,
          "statusactive": this.checked
        };
        addData(a);
      } else {
        const d = {
          "userid": this.userid.nativeElement.value,
          "fname": this.fname.nativeElement.value,
          "lname": this.lname.nativeElement.value,
          "password": this.password.nativeElement.value,
          "userright": this.floatLabelControl.value,
          "statusactive": this.checked
        };
        console.log(this.floatLabelControl);
        
        editData(d, datas.id);
      }
    }
  }

  ngOnInit(): void {
    this.items = this.serviceJksService.getuser_profile();
console.log(this.items);

    if (this.items == "Add") {
      this.headers = "Add Data";
      this.button = "Add";
    } else {
      this.headers = "Edit Data";
      this.button = "Edit";
      this.floatLabelControl.setValue(this.items[0].userright);
    }
  }
  ngOnDestroy() {
    this.items = this.serviceJksService.clearuser_profile();
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
    const response = await instance.post('/Account/AddData', datas)

    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'Your work has been saved.',
      showConfirmButton: false,
      timer: 1500
    })

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

async function editData(datas: any, id: any) {
  try {
    const instance = axios.create({
      baseURL: environment.apijks,
      headers: {
        'Content-Type': 'application/json'
      }
    });
    console.log(datas);
    const response = await instance.put('Account/UpdateData/' + id, datas)
    console.log(response);


    Swal.fire({
      toast: true,
      position: 'top-end',
      icon: 'success',
      title: 'Edit data success.',
      showConfirmButton: false,
      timer: 1500
    })

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