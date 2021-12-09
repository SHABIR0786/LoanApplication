import { Result } from "common";
import { IBuyingHomeModel } from "@app/interfaces/IBuyingHomeModel";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step2",
  templateUrl: "./animated-step2.component.html",
  styleUrls: ["./animated-step2.component.css"],
})
export class AnimatedStep2Component implements OnInit {
  constructor(private _route: Router) {}
  selected: number = 1;
  ngOnInit(): void {
    const response: Result<IBuyingHomeModel> = JSON.parse(
      localStorage.getItem("1")
    );
    this.selected = response.result.propertyUseId;
  }
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step1"]);
  }
  proceedToNext(value) {
    var Form = localStorage.getItem("1");
    if (Form) {
      Form = JSON.parse(Form);
      Form.propertyUseId = value;
      localStorage.setItem("1", JSON.stringify(Form));
    } else {
      var newForm: Object = {};
      newForm.propertyUseId = value;
      localStorage.setItem("1", JSON.stringify(newForm));
    }
    this._route.navigate(["app/buy-a-home-animated-step3"]);
  }
}
