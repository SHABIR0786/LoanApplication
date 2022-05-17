import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropInfoRefer14Component } from "./apply-now-prop-info-refer14.component";

describe("ApplyNowPropInfoRefer14Component", () => {
  let component: ApplyNowPropInfoRefer14Component;
  let fixture: ComponentFixture<ApplyNowPropInfoRefer14Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropInfoRefer14Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropInfoRefer14Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
