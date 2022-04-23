import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPurchaseGov35Component } from "./apply-now-purchase-gov35.component";

describe("ApplyNowPurchaseGov35Component", () => {
  let component: ApplyNowPurchaseGov35Component;
  let fixture: ComponentFixture<ApplyNowPurchaseGov35Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPurchaseGov35Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPurchaseGov35Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
