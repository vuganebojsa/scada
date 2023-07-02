import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisplayOnScanInputTagsComponent } from './display-on-scan-input-tags.component';

describe('DisplayOnScanInputTagsComponent', () => {
  let component: DisplayOnScanInputTagsComponent;
  let fixture: ComponentFixture<DisplayOnScanInputTagsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisplayOnScanInputTagsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisplayOnScanInputTagsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
