import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-keep-your-payment-from-raising",
  templateUrl: "./keep-your-payment-from-raising.component.html",
  styleUrls: ["./keep-your-payment-from-raising.component.css"],
})
export class KeepYourPaymentFromRaisingComponent implements OnInit {
  ReadMore: boolean = true;

  visible: boolean = false;

  onclick() {
    this.ReadMore = !this.ReadMore;
    this.visible = !this.visible;
  }
  constructor() {}

  ngOnInit(): void {}
}
