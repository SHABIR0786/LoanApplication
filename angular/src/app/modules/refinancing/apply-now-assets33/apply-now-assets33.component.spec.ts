import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowAssets33Component } from "./apply-now-assets33.component";

describe("ApplyNowAssets33Component", () => {
  let component: ApplyNowAssets33Component;
  let fixture: ComponentFixture<ApplyNowAssets33Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowAssets33Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowAssets33Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
