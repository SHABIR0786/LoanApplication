import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPersonalIncome22Component } from "./apply-now-personal-income22.component";

describe("ApplyNowPersonalIncome22Component", () => {
  let component: ApplyNowPersonalIncome22Component;
  let fixture: ComponentFixture<ApplyNowPersonalIncome22Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPersonalIncome22Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPersonalIncome22Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
