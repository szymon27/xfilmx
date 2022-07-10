import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCelebritieFormComponent } from './new-celebritie-form.component';

describe('NewCelebritieFormComponent', () => {
  let component: NewCelebritieFormComponent;
  let fixture: ComponentFixture<NewCelebritieFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewCelebritieFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewCelebritieFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
