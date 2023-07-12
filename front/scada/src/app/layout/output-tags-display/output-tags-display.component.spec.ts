import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutputTagsDisplayComponent } from './output-tags-display.component';

describe('OutputTagsDisplayComponent', () => {
  let component: OutputTagsDisplayComponent;
  let fixture: ComponentFixture<OutputTagsDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OutputTagsDisplayComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OutputTagsDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
