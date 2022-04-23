import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropertyInfo7Component } from "./apply-now-property-info7.component";

describe("ApplyNowPropertyInfo7Component", () => {
  let component: ApplyNowPropertyInfo7Component;
  let fixture: ComponentFixture<ApplyNowPropertyInfo7Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropertyInfo7Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropertyInfo7Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
