import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowIncomeEmployment23Component } from "./apply-now-income-employment23.component";

describe("ApplyNowIncomeEmployment23Component", () => {
  let component: ApplyNowIncomeEmployment23Component;
  let fixture: ComponentFixture<ApplyNowIncomeEmployment23Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowIncomeEmployment23Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowIncomeEmployment23Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
