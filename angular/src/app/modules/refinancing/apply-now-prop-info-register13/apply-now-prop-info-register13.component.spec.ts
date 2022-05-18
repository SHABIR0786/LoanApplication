import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropInfoRegister13Component } from "./apply-now-prop-info-register13.component";

describe("ApplyNowPropInfoRegister13Component", () => {
  let component: ApplyNowPropInfoRegister13Component;
  let fixture: ComponentFixture<ApplyNowPropInfoRegister13Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropInfoRegister13Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropInfoRegister13Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
