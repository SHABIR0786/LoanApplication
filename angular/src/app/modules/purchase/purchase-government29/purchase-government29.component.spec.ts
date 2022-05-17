import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseGovernment29Component } from "./purchase-government29.component";

describe("PurchaseGovernment29Component", () => {
  let component: PurchaseGovernment29Component;
  let fixture: ComponentFixture<PurchaseGovernment29Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseGovernment29Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseGovernment29Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
