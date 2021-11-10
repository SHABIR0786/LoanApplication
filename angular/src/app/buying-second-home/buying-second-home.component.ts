import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-buying-second-home",
  templateUrl: "./buying-second-home.component.html",
  styleUrls: ["./buying-second-home.component.css"],
})
export class BuyingSecondHomeComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  ReadMore:boolean = true

  visible:boolean = false

  readmore(){
    this.ReadMore = !this.ReadMore
    this.visible = !this.visible
  }
}
