import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseSeparate21Component } from "./purchase-separate21.component";

describe("PurchaseSeparate21Component", () => {
  let component: PurchaseSeparate21Component;
  let fixture: ComponentFixture<PurchaseSeparate21Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseSeparate21Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseSeparate21Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
