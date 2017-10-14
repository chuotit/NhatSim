import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SimNetworkComponent } from './sim-network.component';

describe('SimNetworkComponent', () => {
  let component: SimNetworkComponent;
  let fixture: ComponentFixture<SimNetworkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SimNetworkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SimNetworkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
