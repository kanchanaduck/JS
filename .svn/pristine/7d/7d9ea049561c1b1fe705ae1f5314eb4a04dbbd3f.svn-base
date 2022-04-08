import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(public router: Router){}
  
  ngOnInit(){
    // console.log(localStorage.getItem('username'))
    if(localStorage.getItem('fname') === null){
      this.router.navigate(['/login']);
    }
  }
}
