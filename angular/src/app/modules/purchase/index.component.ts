import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, NavigationEnd, Router } from "@angular/router";
import { OfflineService } from "@app/services/offline.service";
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
  constructor(private router: Router, private offlineService: OfflineService) {
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

  ngOnInit() {
    const stepData = this.offlineService.getStep();
    console.log({ stepData });
  }
}
