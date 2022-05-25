import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowCreditScore36Component } from "./apply-now-credit-score36.component";

describe("ApplyNowCreditScore36Component", () => {
  let component: ApplyNowCreditScore36Component;
  let fixture: ComponentFixture<ApplyNowCreditScore36Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowCreditScore36Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowCreditScore36Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
