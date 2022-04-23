import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropertyInfo6Component } from "./apply-now-property-info6.component";

describe("ApplyNowPropertyInfo6Component", () => {
  let component: ApplyNowPropertyInfo6Component;
  let fixture: ComponentFixture<ApplyNowPropertyInfo6Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropertyInfo6Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropertyInfo6Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
