import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowCoborrowerOtherSource31Component } from "./apply-now-coborrower-other-source31.component";

describe("ApplyNowCoborrowerOtherSource31Component", () => {
  let component: ApplyNowCoborrowerOtherSource31Component;
  let fixture: ComponentFixture<ApplyNowCoborrowerOtherSource31Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowCoborrowerOtherSource31Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowCoborrowerOtherSource31Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
