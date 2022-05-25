import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowRefinanceNo3Component } from "./apply-now-refinance-no3.component";

describe("ApplyNowRefinanceNo3Component", () => {
  let component: ApplyNowRefinanceNo3Component;
  let fixture: ComponentFixture<ApplyNowRefinanceNo3Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowRefinanceNo3Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowRefinanceNo3Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
