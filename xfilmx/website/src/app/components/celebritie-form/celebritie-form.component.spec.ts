import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CelebritieFormComponent } from './celebritie-form.component';

describe('CelebritieFormComponent', () => {
  let component: CelebritieFormComponent;
  let fixture: ComponentFixture<CelebritieFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CelebritieFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CelebritieFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
