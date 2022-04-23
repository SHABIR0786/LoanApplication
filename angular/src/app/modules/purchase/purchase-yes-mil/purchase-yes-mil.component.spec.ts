import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseYesMilComponent } from "./purchase-yes-mil.component";

describe("PurchaseYesMilComponent", () => {
  let component: PurchaseYesMilComponent;
  let fixture: ComponentFixture<PurchaseYesMilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseYesMilComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseYesMilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
