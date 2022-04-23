import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

@Component({
  selector: "app-purchase-military-info",
  templateUrl: "./purchase-military-info.component.html",
  styleUrls: ["./purchase-military-info.component.css"],
})
export class PurchaseMilitaryInfoComponent implements OnInit {
  number: number = 1;
  constructor(private route: ActivatedRoute, private router: Router) {
    this.route.params.subscribe((x) => {
      if (x.number) {
        this.number = x.number;
      } else {
        this.router.navigate(["/purchase/purchase-mil-info/1"]);
      }
    });
  }

  ngOnInit() {}
}
