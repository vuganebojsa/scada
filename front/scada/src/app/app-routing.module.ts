import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './layout/login/login.component';
import { HomeComponent } from './layout/home/home.component';
import { AlarmDisplayComponent } from './layout/alarm-display/alarm-display.component';
import { DisplayReportComponent } from './layout/display-report/display-report.component';
import { TagManagementComponent } from './layout/tag-management/tag-management.component';

const routes: Routes = [
  {path:'login', component: LoginComponent},
  {path:'home', component:HomeComponent},
  {path:'', component:HomeComponent},
  {path:'alarms', component:AlarmDisplayComponent},
  {path:'tags', component:TagManagementComponent},
  {path:'reports', component:DisplayReportComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
