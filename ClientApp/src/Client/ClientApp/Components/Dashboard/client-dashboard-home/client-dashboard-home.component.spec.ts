import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientDashboardHomeComponent } from './client-dashboard-home.component';

describe('ClientDashboardHomeComponent', () => {
  let component: ClientDashboardHomeComponent;
  let fixture: ComponentFixture<ClientDashboardHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientDashboardHomeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientDashboardHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
