import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlarmDisplayComponent } from './alarm-display.component';

describe('AlarmDisplayComponent', () => {
  let component: AlarmDisplayComponent;
  let fixture: ComponentFixture<AlarmDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AlarmDisplayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AlarmDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
