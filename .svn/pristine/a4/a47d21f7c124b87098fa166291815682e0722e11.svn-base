import { Routes } from '@angular/router';

import { FullComponent } from './layouts/full/full.component';
import { HomeComponent } from './home/home.component';
import { BarChartComponent } from './bar-chart/bar-chart.component';
import { LoginComponent } from './login/login.component';
import { SettingComponent } from './setting/setting.component';

import { PageMaster1Component } from './setting/pages/page-master1/page-master1.component';
import { PageMaster2Component } from './setting/pages/page-master2/page-master2.component';
import { SettingManpowerComponent } from './setting/setting-manpower/setting-manpower.component';
import { SettingStDbComponent } from './setting/setting-st-db/setting-st-db.component';
import { ReportComponent } from './report/report.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

export const AppRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full'
  },
  {
    path: '',
    component: FullComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'user', component: UserProfileComponent },

      { path: 'home', component: HomeComponent },
      { path: 'report', component: ReportComponent },
      { path: 'bar-chart', component: BarChartComponent },
      { path: 'setting', component: SettingComponent },

      { path: 'page1', component: PageMaster1Component },
      { path: 'page2', component: PageMaster2Component },
      { path: 'manpower', component: SettingManpowerComponent },
      { path: 'ST-DB', component: SettingStDbComponent },
    ]
  }
];
