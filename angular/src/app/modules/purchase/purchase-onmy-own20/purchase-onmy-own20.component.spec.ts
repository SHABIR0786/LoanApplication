import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseOnmyOwn20Component } from "./purchase-onmy-own20.component";

describe("PurchaseOnmyOwn20Component", () => {
  let component: PurchaseOnmyOwn20Component;
  let fixture: ComponentFixture<PurchaseOnmyOwn20Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseOnmyOwn20Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseOnmyOwn20Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
