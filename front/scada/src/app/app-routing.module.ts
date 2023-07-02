import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './layout/login/login.component';
import { HomeComponent } from './layout/home/home.component';
import { AlarmDisplayComponent } from './layout/alarm-display/alarm-display.component';
import { DisplayReportComponent } from './layout/display-report/display-report.component';

const routes: Routes = [
  {path:'login', component: LoginComponent},
  {path:'home', component:DisplayReportComponent},
  {path:'**', component:DisplayReportComponent},
  {path:'', component:DisplayReportComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
