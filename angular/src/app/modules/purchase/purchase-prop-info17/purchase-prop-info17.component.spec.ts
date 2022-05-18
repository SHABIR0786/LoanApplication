import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchasePropInfo17Component } from "./purchase-prop-info17.component";

describe("PurchasePropInfo17Component", () => {
  let component: PurchasePropInfo17Component;
  let fixture: ComponentFixture<PurchasePropInfo17Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchasePropInfo17Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchasePropInfo17Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
