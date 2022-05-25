import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowRefinanceYes8Component } from "./apply-now-refinance-yes8.component";

describe("ApplyNowRefinanceYes8Component", () => {
  let component: ApplyNowRefinanceYes8Component;
  let fixture: ComponentFixture<ApplyNowRefinanceYes8Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowRefinanceYes8Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowRefinanceYes8Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
