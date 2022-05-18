import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowThanx37Component } from "./apply-now-thanx37.component";

describe("ApplyNowThanx37Component", () => {
  let component: ApplyNowThanx37Component;
  let fixture: ComponentFixture<ApplyNowThanx37Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowThanx37Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowThanx37Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
