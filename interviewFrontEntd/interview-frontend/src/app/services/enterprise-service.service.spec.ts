import { TestBed } from '@angular/core/testing';

import { EnterpriseServiceService } from './enterprise-service.service';

describe('EnterpriseServiceService', () => {
  let service: EnterpriseServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EnterpriseServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
