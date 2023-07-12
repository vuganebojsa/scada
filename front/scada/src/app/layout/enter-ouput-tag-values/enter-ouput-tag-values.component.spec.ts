import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnterOuputTagValuesComponent } from './enter-ouput-tag-values.component';

describe('EnterOuputTagValuesComponent', () => {
  let component: EnterOuputTagValuesComponent;
  let fixture: ComponentFixture<EnterOuputTagValuesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnterOuputTagValuesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnterOuputTagValuesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
