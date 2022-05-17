import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowCoborrowerSource30Component } from "./apply-now-coborrower-source30.component";

describe("ApplyNowCoborrowerSource30Component", () => {
  let component: ApplyNowCoborrowerSource30Component;
  let fixture: ComponentFixture<ApplyNowCoborrowerSource30Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowCoborrowerSource30Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowCoborrowerSource30Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
