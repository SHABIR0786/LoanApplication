import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPersonalInfoMarital17Component } from "./apply-now-personal-info-marital17.component";

describe("ApplyNowPersonalInfoMarital17Component", () => {
  let component: ApplyNowPersonalInfoMarital17Component;
  let fixture: ComponentFixture<ApplyNowPersonalInfoMarital17Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPersonalInfoMarital17Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPersonalInfoMarital17Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
