import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowIncomeCompensation25Component } from "./apply-now-income-compensation25.component";

describe("ApplyNowIncomeCompensation25Component", () => {
  let component: ApplyNowIncomeCompensation25Component;
  let fixture: ComponentFixture<ApplyNowIncomeCompensation25Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowIncomeCompensation25Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowIncomeCompensation25Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
