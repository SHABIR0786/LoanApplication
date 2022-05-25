import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseIncome26Component } from "./purchase-income26.component";

describe("PurchaseIncome26Component", () => {
  let component: PurchaseIncome26Component;
  let fixture: ComponentFixture<PurchaseIncome26Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseIncome26Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseIncome26Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
