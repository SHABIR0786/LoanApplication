import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowCoborrowerSource29Component } from "./apply-now-coborrower-source29.component";

describe("ApplyNowCoborrowerSource29Component", () => {
  let component: ApplyNowCoborrowerSource29Component;
  let fixture: ComponentFixture<ApplyNowCoborrowerSource29Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowCoborrowerSource29Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowCoborrowerSource29Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
