import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewProductionFormComponent } from './new-production-form.component';

describe('NewProductionFormComponent', () => {
  let component: NewProductionFormComponent;
  let fixture: ComponentFixture<NewProductionFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewProductionFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewProductionFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
