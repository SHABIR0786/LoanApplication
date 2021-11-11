import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-consolidate-your-debit",
  templateUrl: "./consolidate-your-debit.component.html",
  styleUrls: ["./consolidate-your-debit.component.css"],
})
export class ConsolidateYourDebitComponent implements OnInit {
  // show = false;

  ReadMore: boolean = true;

  visible: boolean = false;

  onclick() {
    this.ReadMore = !this.ReadMore;
    this.visible = !this.visible;
  }

  constructor() {}

  ngOnInit(): void {}
}
