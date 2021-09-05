import { TestBed } from '@angular/core/testing';

import { ClientAuthenticationService } from './client-authentication.service';

describe('ClientAuthenticationService', () => {
  let service: ClientAuthenticationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ClientAuthenticationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
