import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import axios from 'axios';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  returnUrl: any;
  showErrorMessage: any;
  errorMessage: string = "";

  constructor(
    private readonly fb: FormBuilder,
    private router: Router
  ) {
    this.form = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  submitForm() {
    this.showErrorMessage = false;
    // console.log('login : ', this.form.getRawValue());
    // const username = this.form.get('username')!.value;
    // const password = this.form.get('password')!.value;

    // console.log(this.form.value.username)
    // console.log(this.form.value.password)
    const params = {
      "userid": this.form.value.username,
      "password": this.form.value.password
    };

    this.getdata(params);
  }

  ngOnInit(): void {
  }

  async getdata(params: any) {
    try {
      const instance = axios.create({
        baseURL: environment.apijks,
        headers: {
          'Content-Type': 'application/json'
        }
      });

      // console.log(params);
      const response = await instance.post("/Account/Getuserid", params);
      // console.log("response: ", response);
      localStorage.setItem('userid', response.data.userid);
      localStorage.setItem('fname', response.data.fname);
      localStorage.setItem('lname', response.data.lname);
      localStorage.setItem('userright', response.data.userright);

      this.router.navigate(['/home']);

      return response.data
    } catch (error) {
      console.log('RES ERROR: ', error.response)
      console.log('RES ERROR STATUS: ', error.response.status)
      console.log('RES ERROR DATA: ', error.response.data)
      this.errorMessage = error.response.data;
      this.showErrorMessage = true;
      localStorage.clear(); 
    }

  }


}


