import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPersonalInfoDependents18Component } from "./apply-now-personal-info-dependents18.component";

describe("ApplyNowPersonalInfoDependents18Component", () => {
  let component: ApplyNowPersonalInfoDependents18Component;
  let fixture: ComponentFixture<ApplyNowPersonalInfoDependents18Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPersonalInfoDependents18Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(
      ApplyNowPersonalInfoDependents18Component
    );
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
