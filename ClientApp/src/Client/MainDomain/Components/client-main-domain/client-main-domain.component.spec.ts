import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientMainDomainComponent } from './client-main-domain.component';

describe('ClientMainDomainComponent', () => {
  let component: ClientMainDomainComponent;
  let fixture: ComponentFixture<ClientMainDomainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClientMainDomainComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClientMainDomainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
