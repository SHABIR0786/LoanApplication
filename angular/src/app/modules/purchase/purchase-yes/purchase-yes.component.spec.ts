import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchaseYesComponent } from "./purchase-yes.component";

describe("PurchaseYesComponent", () => {
  let component: PurchaseYesComponent;
  let fixture: ComponentFixture<PurchaseYesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchaseYesComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchaseYesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
