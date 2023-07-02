import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateAnalogOutputComponent } from './create-analog-output.component';

describe('CreateAnalogOutputComponent', () => {
  let component: CreateAnalogOutputComponent;
  let fixture: ComponentFixture<CreateAnalogOutputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateAnalogOutputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateAnalogOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
