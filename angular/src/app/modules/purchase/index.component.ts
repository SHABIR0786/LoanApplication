import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, NavigationEnd, Router } from "@angular/router";
const ROUTE_DATA = [
  "/purchase/welcome",
  "/purchase/property-info",
  "/purchase/income-info",
  "/purchase/assets-info",
  "/purchase/gov",
];
const TABS_DATA = [];
@Component({
  selector: "app-index",
  templateUrl: "./index.component.html",
  styleUrls: ["./index.component.css"],
})
export class IndexComponent implements OnInit {
  a: number = 0;
  constructor(private router: Router) {
    this.router.events.subscribe((x) => {
      if (x instanceof NavigationEnd) {
        if (x.urlAfterRedirects === "/app/purchase") {
          this.a = 0;
        } else {
          ROUTE_DATA.filter((obj, i) => {
            if (new RegExp(obj + "(.*?)").test(x.urlAfterRedirects)) {
              this.a = i + 1;
            }
          });
        }
      }
    });
  }

  ngOnInit() {}
}
