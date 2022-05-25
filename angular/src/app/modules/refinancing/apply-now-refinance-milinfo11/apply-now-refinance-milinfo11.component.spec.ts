import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowRefinanceMilinfo11Component } from "./apply-now-refinance-milinfo11.component";

describe("ApplyNowRefinanceMilinfo11Component", () => {
  let component: ApplyNowRefinanceMilinfo11Component;
  let fixture: ComponentFixture<ApplyNowRefinanceMilinfo11Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowRefinanceMilinfo11Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowRefinanceMilinfo11Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
