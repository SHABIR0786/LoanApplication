import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowIncomeReview32Component } from "./apply-now-income-review32.component";

describe("ApplyNowIncomeReview32Component", () => {
  let component: ApplyNowIncomeReview32Component;
  let fixture: ComponentFixture<ApplyNowIncomeReview32Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowIncomeReview32Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowIncomeReview32Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
