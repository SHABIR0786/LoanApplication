import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowMilPropinfo9AComponent } from "./apply-now-mil-propinfo9-a.component";

describe("ApplyNowMilPropinfo9AComponent", () => {
  let component: ApplyNowMilPropinfo9AComponent;
  let fixture: ComponentFixture<ApplyNowMilPropinfo9AComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowMilPropinfo9AComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowMilPropinfo9AComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
