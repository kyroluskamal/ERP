import { TestBed } from '@angular/core/testing';

import { OwnersAuthenticationService } from './owners-authentication.service';

describe('OwnersAuthenticationService', () => {
  let service: OwnersAuthenticationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OwnersAuthenticationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
