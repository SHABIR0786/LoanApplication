import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-pre-approval",
  templateUrl: "./pre-approval.component.html",
  styleUrls: ["./pre-approval.component.css"],
})
export class PreApprovalComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}

  ReadMore:boolean = true

  visible:boolean = false

  readmore(){
    this.ReadMore = !this.ReadMore
    this.visible = !this.visible
  }
}
