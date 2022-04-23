import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchasePersonalInfoEdit25Component } from "./purchase-personal-info-edit25.component";

describe("PurchasePersonalInfoEdit25Component", () => {
  let component: PurchasePersonalInfoEdit25Component;
  let fixture: ComponentFixture<PurchasePersonalInfoEdit25Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchasePersonalInfoEdit25Component],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchasePersonalInfoEdit25Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
