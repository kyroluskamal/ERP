import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerBodyComponent } from './owner-body.component';

describe('OwnerBodyComponent', () => {
  let component: OwnerBodyComponent;
  let fixture: ComponentFixture<OwnerBodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnerBodyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnerBodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
