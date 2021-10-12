import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { AmortisationComponent } from "./amortisation.component";

describe("AmortisationComponent", () => {
  let component: AmortisationComponent;
  let fixture: ComponentFixture<AmortisationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [AmortisationComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmortisationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
