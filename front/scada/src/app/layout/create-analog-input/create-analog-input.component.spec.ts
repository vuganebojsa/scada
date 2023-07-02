import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAnalogInputComponent } from './create-analog-input.component';

describe('CreateAnalogInputComponent', () => {
  let component: CreateAnalogInputComponent;
  let fixture: ComponentFixture<CreateAnalogInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateAnalogInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateAnalogInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
