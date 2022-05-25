import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchasePersonalInfo18Component } from "./purchase-personal-info18.component";

describe("PurchasePersonalInfo18Component", () => {
  let component: PurchasePersonalInfo18Component;
  let fixture: ComponentFixture<PurchasePersonalInfo18Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchasePersonalInfo18Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchasePersonalInfo18Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
