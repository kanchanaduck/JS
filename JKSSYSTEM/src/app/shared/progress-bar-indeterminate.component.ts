import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-progress-bar-indeterminate',
  template: `<mat-progress-bar mode="indeterminate"></mat-progress-bar>`
})
export class ProgressBarIndeterminateComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
