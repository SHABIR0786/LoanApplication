import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseDependants22Component } from "./purchase-dependants22.component";

describe("PurchaseDependants22Component", () => {
  let component: PurchaseDependants22Component;
  let fixture: ComponentFixture<PurchaseDependants22Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseDependants22Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseDependants22Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
