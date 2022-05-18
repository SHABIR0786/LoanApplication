import { async, ComponentFixture, TestBed } from "@angular/core/testing";

import { ApplyNowPropertyInfo7AComponent } from "./apply-now-property-info7-a.component";

describe("ApplyNowPropertyInfo7AComponent", () => {
  let component: ApplyNowPropertyInfo7AComponent;
  let fixture: ComponentFixture<ApplyNowPropertyInfo7AComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApplyNowPropertyInfo7AComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplyNowPropertyInfo7AComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });
});
