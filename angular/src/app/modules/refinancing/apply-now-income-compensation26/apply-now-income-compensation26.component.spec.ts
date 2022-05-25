import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowIncomeCompensation26Component } from "./apply-now-income-compensation26.component";

describe("ApplyNowIncomeCompensation26Component", () => {
  let component: ApplyNowIncomeCompensation26Component;
  let fixture: ComponentFixture<ApplyNowIncomeCompensation26Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowIncomeCompensation26Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowIncomeCompensation26Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
