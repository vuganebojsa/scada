import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TagValuesTimePeriodComponent } from './tag-values-time-period.component';

describe('TagValuesTimePeriodComponent', () => {
  let component: TagValuesTimePeriodComponent;
  let fixture: ComponentFixture<TagValuesTimePeriodComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TagValuesTimePeriodComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TagValuesTimePeriodComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
