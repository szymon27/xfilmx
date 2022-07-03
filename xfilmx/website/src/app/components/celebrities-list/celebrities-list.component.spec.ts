import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CelebritiesListComponent } from './celebrities-list.component';

describe('CelebritiesListComponent', () => {
  let component: CelebritiesListComponent;
  let fixture: ComponentFixture<CelebritiesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CelebritiesListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CelebritiesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
