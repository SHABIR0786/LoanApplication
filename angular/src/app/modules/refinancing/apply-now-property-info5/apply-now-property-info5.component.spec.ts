import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropertyInfo5Component } from "./apply-now-property-info5.component";

describe("ApplyNowPropertyInfo5Component", () => {
  let component: ApplyNowPropertyInfo5Component;
  let fixture: ComponentFixture<ApplyNowPropertyInfo5Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropertyInfo5Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropertyInfo5Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
