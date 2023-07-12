import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateDigitalOutputComponent } from './create-digital-output.component';

describe('CreateDigitalOutputComponent', () => {
  let component: CreateDigitalOutputComponent;
  let fixture: ComponentFixture<CreateDigitalOutputComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateDigitalOutputComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateDigitalOutputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
