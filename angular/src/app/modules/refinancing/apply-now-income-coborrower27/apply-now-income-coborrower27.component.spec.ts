import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowIncomeCoborrower27Component } from "./apply-now-income-coborrower27.component";

describe("ApplyNowIncomeCoborrower27Component", () => {
  let component: ApplyNowIncomeCoborrower27Component;
  let fixture: ComponentFixture<ApplyNowIncomeCoborrower27Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowIncomeCoborrower27Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowIncomeCoborrower27Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
