import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowRefinancePersonal10Component } from "./apply-now-refinance-personal10.component";

describe("ApplyNowRefinancePersonal10Component", () => {
  let component: ApplyNowRefinancePersonal10Component;
  let fixture: ComponentFixture<ApplyNowRefinancePersonal10Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowRefinancePersonal10Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowRefinancePersonal10Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
