import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowIncomeCoborrower28Component } from "./apply-now-income-coborrower28.component";

describe("ApplyNowIncomeCoborrower28Component", () => {
  let component: ApplyNowIncomeCoborrower28Component;
  let fixture: ComponentFixture<ApplyNowIncomeCoborrower28Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowIncomeCoborrower28Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowIncomeCoborrower28Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
