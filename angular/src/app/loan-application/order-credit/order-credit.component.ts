import { Component, DoCheck, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../services/data.service";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-order-credit",
  templateUrl: "./order-credit.component.html",
  styleUrls: ["./order-credit.component.css"],
})
export class OrderCreditComponent implements OnInit, DoCheck {
  data: any = {};

  constructor(
    private _dataService: DataService,
    private _route: Router,
    private _activatedRoute: ActivatedRoute
  ) {}

  ngDoCheck(): void {
    this._dataService.updateData(this.data, "orderCredit");
  }

  ngOnInit(): void {
    console.log(this._dataService.loanApplication);
    this.data = this._dataService.loanApplication.orderCredit;
  }

  proceedToNext() {
    // this._ngWizardService.next();

    this._activatedRoute.queryParams.subscribe(async (params) => {
      const id = params["id"];
      if (id) {
        this._route.navigate(["app/additional-detail"], {
          queryParams: {
            id: id,
          },
        });
      } else {
        this._route.navigate(["app/additional-detail"]);
      }
    });
  }

  proceedToPrevious() {
    this._activatedRoute.queryParams.subscribe(async (params) => {
      const id = params["id"];
      if (id) {
        this._route.navigate(["app/employment-income"], {
          queryParams: {
            id: id,
          },
        });
      } else {
        this._route.navigate(["app/employment-income"]);
      }
    });
  }
}
