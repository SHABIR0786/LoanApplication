import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPersonalInfoCoborrower16Component } from "./apply-now-personal-info-coborrower16.component";

describe("ApplyNowPersonalInfoCoborrower16Component", () => {
  let component: ApplyNowPersonalInfoCoborrower16Component;
  let fixture: ComponentFixture<ApplyNowPersonalInfoCoborrower16Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPersonalInfoCoborrower16Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(
      ApplyNowPersonalInfoCoborrower16Component
    );
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
