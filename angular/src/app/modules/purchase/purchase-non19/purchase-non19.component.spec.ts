import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseNon19Component } from "./purchase-non19.component";

describe("PurchaseNon19Component", () => {
  let component: PurchaseNon19Component;
  let fixture: ComponentFixture<PurchaseNon19Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseNon19Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseNon19Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
