import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step4",
  templateUrl: "./animated-step4.component.html",
  styleUrls: ["./animated-step4.component.css"],
})
export class AnimatedStep4Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step3"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step5"]);
  }
}
