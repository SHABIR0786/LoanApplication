import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step5",
  templateUrl: "./animated-step5.component.html",
  styleUrls: ["./animated-step5.component.css"],
})
export class AnimatedStep5Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step4"]);
  }
  proceedToNext() {
    this._route.navigate(["app/buy-a-home-animated-step6"]);
  }
}
