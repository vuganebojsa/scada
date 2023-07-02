import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditAlarmsForAnalogInputsComponent } from './add-edit-alarms-for-analog-inputs.component';

describe('AddEditAlarmsForAnalogInputsComponent', () => {
  let component: AddEditAlarmsForAnalogInputsComponent;
  let fixture: ComponentFixture<AddEditAlarmsForAnalogInputsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditAlarmsForAnalogInputsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditAlarmsForAnalogInputsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
