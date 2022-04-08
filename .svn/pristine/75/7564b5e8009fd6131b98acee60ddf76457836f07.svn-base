
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AppRoutes } from './app.routing';
import { AppComponent } from './app.component';

import { FlexLayoutModule } from '@angular/flex-layout';
import { FullComponent } from './layouts/full/full.component';
import { AppHeaderComponent } from './layouts/full/header/header.component';
import { AppSidebarComponent } from './layouts/full/sidebar/sidebar.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DemoMaterialModule } from './demo-material-module';

import { SharedModule } from './shared/shared.module';
import { SpinnerComponent } from './shared/spinner.component';

import { HomeComponent } from './home/home.component';
import { TableComponent } from './table/table.component';
import { DialogHomeComponent } from './home/dialog-home/dialog-home.component';

import { ChartsComponent } from './charts/charts.component';
import { ChartsModule } from 'ng2-charts';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SettingComponent } from './setting/setting.component';
import { DialogSettingComponent } from './setting/dialog-setting/dialog-setting.component';
import { HomeOvertimeComponent } from './home/home-overtime/home-overtime.component';
import { HomeLosstimeComponent } from './home/home-losstime/home-losstime.component';
import { HomeWorkingmanComponent } from './home/home-workingman/home-workingman.component';
import { HomeKeysComponent } from './home/home-keys/home-keys.component';

import { SettingWcComponent } from './setting/setting-wc/setting-wc.component';
import { DialogWcComponent } from './setting/setting-wc/dialog-wc/dialog-wc.component';
import { SettingModelComponent } from './setting/setting-model/setting-model.component';
import { SettingCellProcessComponent } from './setting/setting-cell-process/setting-cell-process.component';
import { SettingCellComponent } from './setting/setting-cell/setting-cell.component';
import { SettingBlockShiftComponent } from './setting/setting-block-shift/setting-block-shift.component';
import { SettingBlockGroupComponent } from './setting/setting-block-group/setting-block-group.component';
import { SettingGobalCellComponent } from './setting/setting-gobal-cell/setting-gobal-cell.component';
import { SettingTssCodeComponent } from './setting/setting-tss-code/setting-tss-code.component';
import { DetailWcComponent } from './setting/detail-wc/detail-wc.component';
import { DetailModelComponent } from './setting/detail-model/detail-model.component';
import { DetailCellComponent } from './setting/detail-cell/detail-cell.component';
import { DetailCellProcessComponent } from './setting/detail-cell-process/detail-cell-process.component';

import { PageMaster1Component } from './setting/pages/page-master1/page-master1.component';
import { PageMaster2Component } from './setting/pages/page-master2/page-master2.component';

import { DialogModelComponent } from './setting/setting-model/dialog-model/dialog-model.component';
import { DialogCellProcessComponent } from './setting/setting-cell-process/dialog-cell-process/dialog-cell-process.component';
import { DialogCellComponent } from './setting/setting-cell/dialog-cell/dialog-cell.component';
import { DialogBlockShiftComponent } from './setting/setting-block-shift/dialog-block-shift/dialog-block-shift.component';
import { DialogBlockGroupComponent } from './setting/setting-block-group/dialog-block-group/dialog-block-group.component';
import { DialogGobalCellComponent } from './setting/setting-gobal-cell/dialog-gobal-cell/dialog-gobal-cell.component';
import { DialogTssComponent } from './setting/setting-tss-code/dialog-tss/dialog-tss.component';
import { HeaderLeftComponent } from './layouts/full/header-left/header-left.component';
import { DialogDetailComponent } from './setting/dialog-detail/dialog-detail.component';
import { BarChartComponent } from './bar-chart/bar-chart.component';
import { BarChart2Component } from './bar-chart2/bar-chart2.component';
import { BarChart3Component } from './bar-chart3/bar-chart3.component';
import { BarChart4Component } from './bar-chart4/bar-chart4.component';
import { SettingManpowerComponent } from './setting/setting-manpower/setting-manpower.component';
import { DialogManpowerComponent } from './setting/setting-manpower/dialog-manpower/dialog-manpower.component';
import { SettingStDbComponent } from './setting/setting-st-db/setting-st-db.component';
import { ProgressBarIndeterminateComponent } from './shared/progress-bar-indeterminate.component';
import { ReportComponent } from './report/report.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { DialogUserprofileComponent } from './user-profile/dialog-userprofile/dialog-userprofile.component';

@NgModule({
  declarations: [
    AppComponent,
    FullComponent,
    AppHeaderComponent,
    SpinnerComponent,
    AppSidebarComponent,
    HomeComponent,
    TableComponent,
    DialogHomeComponent,
    ChartsComponent,
    LoginComponent,
    SettingComponent,
    DialogSettingComponent,
    HomeOvertimeComponent,
    HomeLosstimeComponent,
    HomeWorkingmanComponent,
    HomeKeysComponent,
    SettingWcComponent,
    DialogWcComponent,
    SettingModelComponent,
    SettingCellProcessComponent,
    SettingCellComponent,
    SettingBlockShiftComponent,
    SettingBlockGroupComponent,
    SettingGobalCellComponent,
    SettingTssCodeComponent,
    DetailWcComponent,
    DetailModelComponent,
    DetailCellComponent,
    DetailCellProcessComponent,
    PageMaster1Component,
    PageMaster2Component,
    DialogModelComponent,
    DialogCellProcessComponent,
    DialogCellComponent,
    DialogBlockShiftComponent,
    DialogBlockGroupComponent,
    DialogGobalCellComponent,
    DialogTssComponent,
    HeaderLeftComponent,
    DialogDetailComponent,
    BarChartComponent,
    BarChart2Component,
    BarChart3Component,
    BarChart4Component,
    SettingManpowerComponent,
    DialogManpowerComponent,
    SettingStDbComponent,
    ProgressBarIndeterminateComponent,
    ReportComponent,
    UserProfileComponent,
    DialogUserprofileComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    DemoMaterialModule,
    FormsModule,
    FlexLayoutModule,
    HttpClientModule,
    SharedModule,
    RouterModule.forRoot(AppRoutes),
    ChartsModule,
    ReactiveFormsModule
  ],
  providers: [
    {
      provide: LocationStrategy,
      useClass: PathLocationStrategy
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
