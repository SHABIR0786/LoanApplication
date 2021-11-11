import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-lower-your-payment",
  templateUrl: "./lower-your-payment.component.html",
  styleUrls: ["./lower-your-payment.component.css"],
})
export class LowerYourPaymentComponent implements OnInit {
  ReadMore: boolean = true;

  visible: boolean = false;

  onclick() {
    this.ReadMore = !this.ReadMore;
    this.visible = !this.visible;
  }
  constructor() {}

  ngOnInit(): void {}
}
