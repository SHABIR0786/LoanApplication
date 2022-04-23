import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { PurchasingYesComponent } from "./purchasing-yes.component";

describe("PurchasingYesComponent", () => {
  let component: PurchasingYesComponent;
  let fixture: ComponentFixture<PurchasingYesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [PurchasingYesComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PurchasingYesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
