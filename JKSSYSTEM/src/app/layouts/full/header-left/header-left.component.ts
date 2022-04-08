import { MediaMatcher } from '@angular/cdk/layout';
import {ChangeDetectorRef, Component,OnDestroy,AfterViewInit,OnInit} from '@angular/core';
import { MenuItems } from '../../../shared/menu-items/menu-items';

@Component({
  selector: 'app-header-left',
  templateUrl: './header-left.component.html'
})
export class HeaderLeftComponent implements OnDestroy, AfterViewInit, OnInit {
  mobileQuery: MediaQueryList;
  tf: any;
  userright: any;

  private _mobileQueryListener: () => void;

  constructor(
    changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    public menuItems: MenuItems
  ) {
    this.mobileQuery = media.matchMedia('(min-width: 768px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  ngAfterViewInit() {}
  ngOnInit(): void {
    this.userright = localStorage.getItem('userright');
    this.tf = false;
    if (this.userright === "Admin") {
      this.tf = true;
    }
  }
}