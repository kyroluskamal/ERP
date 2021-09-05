import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientMainDomainNavBarComponent } from './client-main-domain-nav-bar.component';

describe('ClientMainDomainNavBarComponent', () => {
  let component: ClientMainDomainNavBarComponent;
  let fixture: ComponentFixture<ClientMainDomainNavBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientMainDomainNavBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientMainDomainNavBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
