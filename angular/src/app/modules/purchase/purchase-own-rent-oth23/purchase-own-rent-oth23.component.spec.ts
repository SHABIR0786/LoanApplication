import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseOwnRentOth23Component } from "./purchase-own-rent-oth23.component";

describe("PurchaseOwnRentOth23Component", () => {
  let component: PurchaseOwnRentOth23Component;
  let fixture: ComponentFixture<PurchaseOwnRentOth23Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseOwnRentOth23Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseOwnRentOth23Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
