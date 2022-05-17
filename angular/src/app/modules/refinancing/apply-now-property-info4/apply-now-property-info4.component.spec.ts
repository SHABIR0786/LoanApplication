import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropertyInfo4Component } from "./apply-now-property-info4.component";

describe("ApplyNowPropertyInfo4Component", () => {
  let component: ApplyNowPropertyInfo4Component;
  let fixture: ComponentFixture<ApplyNowPropertyInfo4Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropertyInfo4Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropertyInfo4Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
