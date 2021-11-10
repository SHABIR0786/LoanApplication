import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-buying-vacation-home",
  templateUrl: "./buying-vacation-home.component.html",
  styleUrls: ["./buying-vacation-home.component.css"],
})
export class BuyingVacationHomeComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  ReadMore:boolean = true

  visible:boolean = false

  readmore(){
    this.ReadMore = !this.ReadMore
    this.visible = !this.visible
  }
}
