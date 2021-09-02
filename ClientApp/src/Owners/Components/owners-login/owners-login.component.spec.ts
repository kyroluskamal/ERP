import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnersLoginComponent } from './owners-login.component';

describe('OwnersLoginComponent', () => {
  let component: OwnersLoginComponent;
  let fixture: ComponentFixture<OwnersLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnersLoginComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnersLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
