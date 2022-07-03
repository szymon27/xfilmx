import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCountryFormComponent } from './new-country-form.component';

describe('NewCountryFormComponent', () => {
  let component: NewCountryFormComponent;
  let fixture: ComponentFixture<NewCountryFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewCountryFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewCountryFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
