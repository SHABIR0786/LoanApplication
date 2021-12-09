import { Result } from "common";
import { IBuyingHomeModel } from "@app/interfaces/IBuyingHomeModel";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step1",
  templateUrl: "./animated-step1.component.html",
  styleUrls: ["./animated-step1.component.css"],
})
export class AnimatedStep1Component implements OnInit {
  constructor(private _route: Router) {}
  selected = 1;
  ngOnInit(): void {
    const response: Result<IBuyingHomeModel> = JSON.parse(
      localStorage.getItem("1")
    );
    this.selected = response.result.propertyTypeId;
  }

  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated"]);
  }

  proceedToNext(value) {
    var Form = localStorage.getItem("1");
    if (Form) {
      Form = JSON.parse(Form);
      Form.propertyTypeId = value;
      localStorage.setItem("1", JSON.stringify(Form));
    } else {
      var newForm: Object = {};
      newForm.propertyTypeId = value;
      localStorage.setItem("1", JSON.stringify(newForm));
    }
    this._route.navigate(["app/buy-a-home-animated-step2"]);
  }
}
