import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseIncomeSource27Component } from "./purchase-income-source27.component";

describe("PurchaseIncomeSource27Component", () => {
  let component: PurchaseIncomeSource27Component;
  let fixture: ComponentFixture<PurchaseIncomeSource27Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseIncomeSource27Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseIncomeSource27Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
