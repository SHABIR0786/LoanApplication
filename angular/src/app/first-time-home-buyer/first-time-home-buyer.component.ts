import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-first-time-home-buyer",
  templateUrl: "./first-time-home-buyer.component.html",
  styleUrls: ["./first-time-home-buyer.component.css"],
})
export class FirstTimeHomeBuyerComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
  ReadMore:boolean = true

  visible:boolean = false

  readmore(){
    this.ReadMore = !this.ReadMore
    this.visible = !this.visible
  }
}
