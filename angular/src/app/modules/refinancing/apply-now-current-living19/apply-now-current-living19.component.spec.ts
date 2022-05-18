import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowCurrentLiving19Component } from "./apply-now-current-living19.component";

describe("ApplyNowCurrentLiving19Component", () => {
  let component: ApplyNowCurrentLiving19Component;
  let fixture: ComponentFixture<ApplyNowCurrentLiving19Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowCurrentLiving19Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowCurrentLiving19Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
