import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';

@Component({
  selector: 'app-page-master1',
  templateUrl: './page-master1.component.html'
})
export class PageMaster1Component implements OnInit {
  isLinear = false;
  firstFormGroup:any;
  secondFormGroup: any;
  thirdFormGroup: any;
  fourthFormGroup: any;
  fifthFormGroup: any;
  sixthFormGroup: any;
  seventhFormGroup: any;
  eighthFormGroup: any;

  constructor(private _formBuilder: FormBuilder) {}

  ngOnInit() {
    this.firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.thirdFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.fourthFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.fifthFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.sixthFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.seventhFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
    this.eighthFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    });
  }
}
