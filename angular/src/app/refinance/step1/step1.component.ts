import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-step1",
  templateUrl: "./step1.component.html",
  styleUrls: ["./step1.component.css"],
})
export class Step1Component implements OnInit {
    constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToNext(){
    this._route.navigate(["app/refinance-step2"]);
  }
}
