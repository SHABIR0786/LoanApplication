import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseMonthlyExpenses24Component } from "./purchase-monthly-expenses24.component";

describe("PurchaseMonthlyExpenses24Component", () => {
  let component: PurchaseMonthlyExpenses24Component;
  let fixture: ComponentFixture<PurchaseMonthlyExpenses24Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseMonthlyExpenses24Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseMonthlyExpenses24Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
