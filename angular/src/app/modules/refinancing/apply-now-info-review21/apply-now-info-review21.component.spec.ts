import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowInfoReview21Component } from "./apply-now-info-review21.component";

describe("ApplyNowInfoReview21Component", () => {
  let component: ApplyNowInfoReview21Component;
  let fixture: ComponentFixture<ApplyNowInfoReview21Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowInfoReview21Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowInfoReview21Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
