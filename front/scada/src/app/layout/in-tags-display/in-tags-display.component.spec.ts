import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InTagsDisplayComponent } from './in-tags-display.component';

describe('InTagsDisplayComponent', () => {
  let component: InTagsDisplayComponent;
  let fixture: ComponentFixture<InTagsDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InTagsDisplayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InTagsDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
