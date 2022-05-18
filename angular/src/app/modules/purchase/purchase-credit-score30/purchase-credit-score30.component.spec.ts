import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseCreditScore30Component } from "./purchase-credit-score30.component";

describe("PurchaseCreditScore30Component", () => {
  let component: PurchaseCreditScore30Component;
  let fixture: ComponentFixture<PurchaseCreditScore30Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseCreditScore30Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseCreditScore30Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
