import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportAlarmTimePeriodComponent } from './report-alarm-time-period.component';

describe('ReportAlarmTimePeriodComponent', () => {
  let component: ReportAlarmTimePeriodComponent;
  let fixture: ComponentFixture<ReportAlarmTimePeriodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportAlarmTimePeriodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportAlarmTimePeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
