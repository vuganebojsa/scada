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
