import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowRefinanceYes2Component } from "./apply-now-refinance-yes2.component";

describe("ApplyNowRefinanceYes2Component", () => {
  let component: ApplyNowRefinanceYes2Component;
  let fixture: ComponentFixture<ApplyNowRefinanceYes2Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowRefinanceYes2Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowRefinanceYes2Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
