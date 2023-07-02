import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnOffScanInputTagsComponent } from './on-off-scan-input-tags.component';

describe('OnOffScanInputTagsComponent', () => {
  let component: OnOffScanInputTagsComponent;
  let fixture: ComponentFixture<OnOffScanInputTagsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OnOffScanInputTagsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OnOffScanInputTagsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
