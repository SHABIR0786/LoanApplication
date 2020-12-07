import { Component, DoCheck, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { DataService } from "../../services/data.service";
import { ActivatedRoute } from "@angular/router";
import { LoanApplicationService } from "../../services/loan-application.service";

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
    private _activatedRoute: ActivatedRoute,
    private _loanApplicationService: LoanApplicationService
  ) {}

  ngDoCheck(): void {
    this._dataService.updateData(this.data, "orderCredit");
  }

  ngOnInit(): void {
    console.log(this._dataService.loanApplication);
    this.data = this._dataService.loanApplication.orderCredit;
  }

  prepareFormData(response) {
    for (const key in response) {
      if (response.hasOwnProperty(key)) {
        response[key] = response[key] || {};
      }
    }
    return response;
  }
  sanitizeFormData(formData) {
    formData = Object.assign({}, formData);

    this._activatedRoute.queryParams.subscribe(async (params) => {
      formData.id = params["id"];
    });
    for (const key in formData) {
      if (key && formData.hasOwnProperty(key) && formData[key]) {
        if (
          typeof formData[key] === "object" &&
          Object.keys(formData[key]).length === 0
        ) {
          formData[key] = undefined;
        }
      }
    }
    return formData;
  }
  submitForm() {
    const formData = this.sanitizeFormData(this._dataService.loanApplication);

    this._loanApplicationService.post("Add", formData).subscribe(
      (response: any) => {
        this._dataService.loanApplication = this.prepareFormData(
          response.result
        );
      },
      (error) => {
        console.log(error);
      }
    );
  }
  proceedToNext() {
    this.submitForm();
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
    this.submitForm();
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
