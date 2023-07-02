import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LastValueTagDiComponent } from './last-value-tag-di.component';

describe('LastValueTagDiComponent', () => {
  let component: LastValueTagDiComponent;
  let fixture: ComponentFixture<LastValueTagDiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LastValueTagDiComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LastValueTagDiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
