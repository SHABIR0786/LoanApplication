import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowCurrentEmployer24Component } from "./apply-now-current-employer24.component";

describe("ApplyNowCurrentEmployer24Component", () => {
  let component: ApplyNowCurrentEmployer24Component;
  let fixture: ComponentFixture<ApplyNowCurrentEmployer24Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowCurrentEmployer24Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowCurrentEmployer24Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
