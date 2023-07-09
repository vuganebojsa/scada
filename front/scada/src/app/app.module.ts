import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './layout/login/login.component';
import { HomeComponent } from './layout/home/home.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { CreateDigitalInputComponent } from './layout/create-digital-input/create-digital-input.component';
import { CreateDigitalOutputComponent } from './layout/create-digital-output/create-digital-output.component';
import { CreateAnalogInputComponent } from './layout/create-analog-input/create-analog-input.component';
import { CreateAnalogOutputComponent } from './layout/create-analog-output/create-analog-output.component';
import { EnterOuputTagValuesComponent } from './layout/enter-ouput-tag-values/enter-ouput-tag-values.component';
import { OutputTagsDisplayComponent } from './layout/output-tags-display/output-tags-display.component';
import { OnOffScanInputTagsComponent } from './layout/on-off-scan-input-tags/on-off-scan-input-tags.component';
import { DisplayOnScanInputTagsComponent } from './layout/display-on-scan-input-tags/display-on-scan-input-tags.component';
import { AddEditAlarmsForAnalogInputsComponent } from './layout/add-edit-alarms-for-analog-inputs/add-edit-alarms-for-analog-inputs.component';
import { AlarmDisplayComponent } from './layout/alarm-display/alarm-display.component';
import { DisplayReportComponent } from './layout/display-report/display-report.component';
import { ReportAlarmTimePeriodComponent } from './layout/report-alarm-time-period/report-alarm-time-period.component';
import { ReportAlarmPriorityComponent } from './layout/report-alarm-priority/report-alarm-priority.component';
import { TagValuesTimePeriodComponent } from './layout/tag-values-time-period/tag-values-time-period.component';
import { LastValueTagAiComponent } from './layout/last-value-tag-ai/last-value-tag-ai.component';
import { LastValueTagDiComponent } from './layout/last-value-tag-di/last-value-tag-di.component';
import { ReportAllValuesOfTagWithIdComponent } from './layout/report-all-values-of-tag-with-id/report-all-values-of-tag-with-id.component';
import { TagManagementComponent } from './layout/tag-management/tag-management.component';
import { InTagsDisplayComponent } from './layout/in-tags-display/in-tags-display.component';
import { CreateAlarmComponent } from './layout/create-alarm/create-alarm.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    NavbarComponent,
    CreateDigitalInputComponent,
    CreateDigitalOutputComponent,
    CreateAnalogInputComponent,
    CreateAnalogOutputComponent,
    EnterOuputTagValuesComponent,
    OutputTagsDisplayComponent,
    OnOffScanInputTagsComponent,
    DisplayOnScanInputTagsComponent,
    AddEditAlarmsForAnalogInputsComponent,
    AlarmDisplayComponent,
    DisplayReportComponent,
    ReportAlarmTimePeriodComponent,
    ReportAlarmPriorityComponent,
    TagValuesTimePeriodComponent,
    LastValueTagAiComponent,
    LastValueTagDiComponent,
    ReportAllValuesOfTagWithIdComponent,
    TagManagementComponent,
    InTagsDisplayComponent,
    CreateAlarmComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
