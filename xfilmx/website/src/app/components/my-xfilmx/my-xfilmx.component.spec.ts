import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyXfilmxComponent } from './my-xfilmx.component';

describe('MyXfilmxComponent', () => {
  let component: MyXfilmxComponent;
  let fixture: ComponentFixture<MyXfilmxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyXfilmxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MyXfilmxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
