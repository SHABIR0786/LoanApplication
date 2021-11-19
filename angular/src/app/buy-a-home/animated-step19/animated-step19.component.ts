import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
@Component({
  selector: "app-animated-step19",
  templateUrl: "./animated-step19.component.html",
  styleUrls: ["./animated-step19.component.css"],
})
export class AnimatedStep19Component implements OnInit {
  constructor(private _route: Router) {}

  ngOnInit(): void {}
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step18"]);
  }
}
