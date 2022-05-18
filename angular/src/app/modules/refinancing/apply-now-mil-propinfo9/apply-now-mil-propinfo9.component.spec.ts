import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowMilPropinfo9Component } from "./apply-now-mil-propinfo9.component";

describe("ApplyNowMilPropinfo9Component", () => {
  let component: ApplyNowMilPropinfo9Component;
  let fixture: ComponentFixture<ApplyNowMilPropinfo9Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowMilPropinfo9Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowMilPropinfo9Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
