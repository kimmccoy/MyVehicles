import { TestBed } from '@angular/core/testing';

import { RegoClientService } from './rego-client-service';

describe('RegoClient', () => {
  let service: RegoClientService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RegoClientService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
