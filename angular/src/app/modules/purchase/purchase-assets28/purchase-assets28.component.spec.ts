import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseAssets28Component } from "./purchase-assets28.component";

describe("PurchaseAssets28Component", () => {
  let component: PurchaseAssets28Component;
  let fixture: ComponentFixture<PurchaseAssets28Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseAssets28Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseAssets28Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
