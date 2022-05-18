import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowMonthlyExpense20Component } from "./apply-now-monthly-expense20.component";

describe("ApplyNowMonthlyExpense20Component", () => {
  let component: ApplyNowMonthlyExpense20Component;
  let fixture: ComponentFixture<ApplyNowMonthlyExpense20Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowMonthlyExpense20Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowMonthlyExpense20Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
