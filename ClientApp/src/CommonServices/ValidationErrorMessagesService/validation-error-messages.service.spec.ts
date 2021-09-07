import { TestBed } from '@angular/core/testing';

import { ValidationErrorMessagesService } from './validation-error-messages.service';

describe('ValidationErrorMessagesService', () => {
  let service: ValidationErrorMessagesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ValidationErrorMessagesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
