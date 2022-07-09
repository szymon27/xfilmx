import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewNewsFormComponent } from './new-news-form.component';

describe('NewNewsFormComponent', () => {
  let component: NewNewsFormComponent;
  let fixture: ComponentFixture<NewNewsFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewNewsFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewNewsFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
