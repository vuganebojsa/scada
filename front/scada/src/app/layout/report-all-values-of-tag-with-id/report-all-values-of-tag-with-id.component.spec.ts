import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportAllValuesOfTagWithIdComponent } from './report-all-values-of-tag-with-id.component';

describe('ReportAllValuesOfTagWithIdComponent', () => {
  let component: ReportAllValuesOfTagWithIdComponent;
  let fixture: ComponentFixture<ReportAllValuesOfTagWithIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportAllValuesOfTagWithIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ReportAllValuesOfTagWithIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
