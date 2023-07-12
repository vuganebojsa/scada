import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDigitalInputComponent } from './create-digital-input.component';

describe('CreateDigitalInputComponent', () => {
  let component: CreateDigitalInputComponent;
  let fixture: ComponentFixture<CreateDigitalInputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDigitalInputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateDigitalInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
