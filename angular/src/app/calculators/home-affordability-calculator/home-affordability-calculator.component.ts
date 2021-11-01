import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-home-affordability-calculator",
  templateUrl: "./home-affordability-calculator.component.html",
  styleUrls: ["./home-affordability-calculator.component.css"],
})
export class HomeAffordabilityCalculatorComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
  annualIncome = 0;
  monthlyDebt = 0;
  downPayment = 0;
  zipCode = 0;
  RateYourCreditOptions = [
    { value: "Excellent (720 or above)", key: 0 },
    { value: "Good (660 - 719)", key: 1 },
    { value: "Average (620 - 659)", key: 2 },
    { value: "Below Average (580 - 619)", key: 3 },
    { value: "Poor (579 and below)", key: 4 },
  ];

  calculate() {
    var monthlyGrossIncome = this.annualIncome / 12;
    var DITI = (this.monthlyDebt / monthlyGrossIncome) * 100;
    console.log("Debit to Income Ratio" + DITI);
    var amountwithoutdebit = monthlyGrossIncome;
    console.log();
    var HousingRatio = amountwithoutdebit;
    console.log(HousingRatio);
    var amounttotal = HousingRatio * 360;
    console.log(amounttotal);
  }
}
