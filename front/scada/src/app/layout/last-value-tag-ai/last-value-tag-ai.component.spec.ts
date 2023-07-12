import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastValueTagAiComponent } from './last-value-tag-ai.component';

describe('LastValueTagAiComponent', () => {
  let component: LastValueTagAiComponent;
  let fixture: ComponentFixture<LastValueTagAiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LastValueTagAiComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LastValueTagAiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
