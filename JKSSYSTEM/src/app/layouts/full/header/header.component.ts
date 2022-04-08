import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: []
})
export class AppHeaderComponent implements OnInit {
  fname: any;
  lname: any;
  userright: any;
  tf: any;

  constructor() { }

  ngOnInit(): void {
    this.fname = localStorage.getItem('fname');
    this.lname = localStorage.getItem('lname');

    this.userright = localStorage.getItem('userright');
    this.tf = false;
    if (this.userright === "Admin") {
      this.tf = true;
    }
  }
  ngOnDestroy() {
    localStorage.clear();
  }

}
