import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowNonmilPropinfo12Component } from "./apply-now-nonmil-propinfo12.component";

describe("ApplyNowNonmilPropinfo12Component", () => {
  let component: ApplyNowNonmilPropinfo12Component;
  let fixture: ComponentFixture<ApplyNowNonmilPropinfo12Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowNonmilPropinfo12Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowNonmilPropinfo12Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
