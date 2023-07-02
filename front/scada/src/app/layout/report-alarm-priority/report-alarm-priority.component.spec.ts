import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportAlarmPriorityComponent } from './report-alarm-priority.component';

describe('ReportAlarmPriorityComponent', () => {
  let component: ReportAlarmPriorityComponent;
  let fixture: ComponentFixture<ReportAlarmPriorityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportAlarmPriorityComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportAlarmPriorityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
