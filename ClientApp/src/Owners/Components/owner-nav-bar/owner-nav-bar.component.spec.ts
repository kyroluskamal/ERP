import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OwnerNavBarComponent } from './owner-nav-bar.component';

describe('OwnerNavBarComponent', () => {
  let component: OwnerNavBarComponent;
  let fixture: ComponentFixture<OwnerNavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OwnerNavBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OwnerNavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
