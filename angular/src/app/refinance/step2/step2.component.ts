import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-step2",
  templateUrl: "./step2.component.html",
  styleUrls: ["./step2.component.css"],
})
export class Step2Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious(){
    this._route.navigate(["app/refinance-step1"]);
  }
  proceedToNext(){
    this._route.navigate(["app/refinance-step3"]);
  }
}
