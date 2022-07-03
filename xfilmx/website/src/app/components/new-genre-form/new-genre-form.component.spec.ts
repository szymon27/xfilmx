import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewGenreFormComponent } from './new-genre-form.component';

describe('NewGenreFormComponent', () => {
  let component: NewGenreFormComponent;
  let fixture: ComponentFixture<NewGenreFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewGenreFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewGenreFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
