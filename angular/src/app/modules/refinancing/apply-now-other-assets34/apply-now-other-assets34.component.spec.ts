import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowOtherAssets34Component } from "./apply-now-other-assets34.component";

describe("ApplyNowOtherAssets34Component", () => {
  let component: ApplyNowOtherAssets34Component;
  let fixture: ComponentFixture<ApplyNowOtherAssets34Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowOtherAssets34Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowOtherAssets34Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
