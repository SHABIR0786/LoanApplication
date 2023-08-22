import { Component, OnInit } from "@angular/core";
import {
  FinancialInfoAssetsLiabilitiesModels,
  mortgageFinancialAssets,
  mortgageFinancialOtherAssets,
  mortgageFinancialLiabilities,
  mortgageFinancialOtherLaibilities,
} from "./financial-info-assets-liabilities-models";
import { FinancialInfoAssetsLiabilitiesService } from "./financial-info-assets-liabilities.service";
import { Router } from "@angular/router";
@Component({
  selector: "app-financial-info-assets-liabilities",
  templateUrl: "./financial-info-assets-liabilities.component.html",
  styleUrls: ["./financial-info-assets-liabilities.component.css"],
})
export class FinancialInfoAssetsLiabilitiesComponent implements OnInit {
  constructor(
    private financialInfoService: FinancialInfoAssetsLiabilitiesService,
    private router: Router
  ) {}
  flgMortgageFinancialOtherAssets: boolean = false;
  flgMortgageFinancialLiabilities: boolean = false;
  flgMortgageFinancialOtherLaibilities: boolean = false;
  totalMortgageFinancialAssets: number;
  totalMortgageFinancialOtherAssets: number;
  totalMortgageFinancialOtherLaibilities: number;
  mortgageFinancialAssets: mortgageFinancialAssets = new mortgageFinancialAssets();
  mortgageFinancialOtherAssets: mortgageFinancialOtherAssets = new mortgageFinancialOtherAssets();
  mortgageFinancialLiabilities: mortgageFinancialLiabilities = new mortgageFinancialLiabilities();
  mortgageFinancialOtherLaibilities: mortgageFinancialOtherLaibilities = new mortgageFinancialOtherLaibilities();
  financialInfoAssetsLiabilitiesModels: FinancialInfoAssetsLiabilitiesModels = new FinancialInfoAssetsLiabilitiesModels();
  ngOnInit(): void {
    // this.getAllMortgageApplicationAssetandLiability()

    if (
      localStorage.financialInfoAssetsLiabilitiesModels != undefined &&
      localStorage.financialInfoAssetsLiabilitiesModels != ""
    ) {
      this.financialInfoAssetsLiabilitiesModels = JSON.parse(
        localStorage.getItem("financialInfoAssetsLiabilitiesModels")
      );
    }
    if (localStorage.flgMortgageFinancialOtherAssets != undefined) {
      this.flgMortgageFinancialOtherAssets = JSON.parse(
        localStorage.getItem("flgMortgageFinancialOtherAssets")
      );
    }
    if (localStorage.flgMortgageFinancialLiabilities != undefined) {
      this.flgMortgageFinancialLiabilities = JSON.parse(
        localStorage.getItem("flgMortgageFinancialLiabilities")
      );
    }
    if (localStorage.flgMortgageFinancialOtherLaibilities != undefined) {
      this.flgMortgageFinancialOtherLaibilities = JSON.parse(
        localStorage.getItem("flgMortgageFinancialOtherLaibilities")
      );
    }
  }

  addMortgageFinancialAssets() {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.push(
      new mortgageFinancialAssets()
    );
  }
  removeMortgageFinancialAssets() {
    var mortgageFinancialAssetsLength = this
      .financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.length;
    if (mortgageFinancialAssetsLength == 1) {
      return;
    } else {
      var obj = mortgageFinancialAssetsLength - 1;
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.splice(
        obj,
        1
      );
    }
  }

  addMortgageFinancialOtherAssets() {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets.push(
      new mortgageFinancialOtherAssets()
    );
  }
  removeMortgageFinancialOtherAssets() {
    var mortgageFinancialOtherAssets = this.financialInfoAssetsLiabilitiesModels
      .mortgageFinancialOtherAssets.length;
    if (mortgageFinancialOtherAssets == 1) {
      return;
    } else {
      var obj = mortgageFinancialOtherAssets - 1;
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets.splice(
        obj,
        1
      );
    }
  }

  addMortgageFinancialLiabilities() {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.push(
      new mortgageFinancialLiabilities()
    );
  }
  removeMortgageFinancialLiabilities() {
    var indexList: any[] = [];
    if (
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities
        .length > 0
    ) {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.forEach(
        (element: any, index: any) => {
          if (element.isPaidBeforeClosing == true) {
            indexList.push({ index: index });
          }
        }
      );
      if (indexList.length > 0) {
        indexList.sort((a: any, b: any) => {
          return b.index - a.index;
        });

        indexList.forEach((element: any) => {
          this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.splice(
            element.index,
            1
          );
        });
      } else {
        var mortgageFinancialLength = this.financialInfoAssetsLiabilitiesModels
          .mortgageFinancialLiabilities.length;
        if (mortgageFinancialLength == 1) {
          return;
        } else {
          var obj = mortgageFinancialLength - 1;
          this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.splice(
            obj,
            1
          );
        }
      }
    }
    // var mortgageFinancialLiabilitiesLength = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.length;
    // this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.splice(1, mortgageFinancialLiabilitiesLength)
  }

  addMortgageFinancialOtherLaibilities() {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities.push(
      new mortgageFinancialOtherLaibilities()
    );
  }
  removeMortgageFinancialOtherLaibilities() {
    var mortgageFinancialOtherLaibilitiesLength = this
      .financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities
      .length;
    if (mortgageFinancialOtherLaibilitiesLength == 1) {
      return;
    } else {
      var obj = mortgageFinancialOtherLaibilitiesLength - 1;
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities.splice(
        obj,
        1
      );
    }
  }
  submitFinancialAssetsLiabilities() {
    if (this.flgMortgageFinancialOtherAssets == true) {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets = [];
    }
    if (this.flgMortgageFinancialLiabilities == true) {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities = [];
    }
    if (this.flgMortgageFinancialOtherLaibilities == true) {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities = [];
    }

    // var obj = {
    //   mortgageFinancialAssets: this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets,
    //   mortgageFinancialOtherAssets: this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities,
    //   mortgageFinancialLiabilities: this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets,
    //   mortgageFinancialOtherLaibilities: this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities
    // }
    localStorage.setItem(
      "financialInfoAssetsLiabilitiesModels",
      JSON.stringify(this.financialInfoAssetsLiabilitiesModels)
    );
    localStorage.setItem(
      "flgMortgageFinancialOtherAssets",
      JSON.stringify(this.flgMortgageFinancialOtherAssets)
    );
    localStorage.setItem(
      "flgMortgageFinancialLiabilities",
      JSON.stringify(this.flgMortgageFinancialLiabilities)
    );
    localStorage.setItem(
      "flgMortgageFinancialOtherLaibilities",
      JSON.stringify(this.flgMortgageFinancialOtherLaibilities)
    );
    this.financialInfoService
      .createFinancialInfoAssetsLiabilities(
        this.financialInfoAssetsLiabilitiesModels
      )
      .subscribe((data: any) => {
        if (data.success == true) {
          alert("Data inserted successfully");
          this.router.navigateByUrl(
            "app/admin/incomplete-loan-application/financial-info-real-estate"
          );
        }
      });
  }

  getTotalMortgageFinancialAssets() {
    this.totalMortgageFinancialAssets = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.reduce(
      (sum, current) => sum + current.cashMarketValue,
      0
    );
  }
  getTotalMortgageFinancialOtherAssets() {
    this.totalMortgageFinancialOtherAssets = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets.reduce(
      (sum, current) => sum + current.cashMarketValue,
      0
    );
  }
  getTotalMortgageFinancialOtherLaibilities() {
    this.totalMortgageFinancialOtherLaibilities = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.reduce(
      (sum, current) => sum + current.monthlyPayment,
      0
    );
  }
  getAllMortgageApplicationAssetandLiability() {
    var obj = {
      Sorting: "",
      SkipCount: 0,
      MaxResultCount: 10,
    };

    this.financialInfoService
      .getAllFinancialInfoAssetsLiabilities(obj)
      .subscribe((data) => {});
  }
  // nextBtnClick(){
  //   console.log(this.borrowerInfo);
  //   this.borrowService.createMortgageLoanApplication(this.borrowerInfo).subscribe(
  //        (res: any) => {
  //       console.log(res.result);
  //       alert("data has inserted successfully");
  //     }
  //   );
  // }
}
