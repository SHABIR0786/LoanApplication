import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropInfoOwn15Component } from "./apply-now-prop-info-own15.component";

describe("ApplyNowPropInfoOwn15Component", () => {
  let component: ApplyNowPropInfoOwn15Component;
  let fixture: ComponentFixture<ApplyNowPropInfoOwn15Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropInfoOwn15Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropInfoOwn15Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
