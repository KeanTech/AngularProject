import { TestBed } from '@angular/core/testing';

import { RoomsandtempsService } from './roomsandtemps.service';

describe('RoomsandtempsService', () => {
  let service: RoomsandtempsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RoomsandtempsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
