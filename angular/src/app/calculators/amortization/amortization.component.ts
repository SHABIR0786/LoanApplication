import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-amortization",
  templateUrl: "./amortization.component.html",
  styleUrls: ["./amortization.component.css"],
})
export class AmortizationComponent implements OnInit {
  constructor() {}

  ngOnInit(): void {}
  currentLoanAmount = 0;
  interestRate = 0;
  additionalPaymentAmount = 0;
  termInYears: any = "select";
  state = "select";
  additionalPaymentType = "select";
  startMonth = "select";
  startPaymentYear = "select";
  principalDue = [];
  computedInterestDue = [];
  principlebalance = [];
  counter(length: number) {
    return Array.from({ length: length }, (_, i) => i + 1);
  }
  calculateMonthlyMortgagePayment = (principal, interestRate, termInYears) => {
    interestRate = interestRate === 0 ? 0 : interestRate / 100;
    const monthlyInterestRate = interestRate === 0 ? 0 : interestRate / 12;
    const numberOfMonthlyPayments = termInYears * 12;
    return (
      (monthlyInterestRate *
        principal *
        Math.pow(1 + monthlyInterestRate, numberOfMonthlyPayments)) /
        (Math.pow(1 + monthlyInterestRate, numberOfMonthlyPayments) - 1) || 0
    );
  };
  calculateEstimatedMonthlyPayment() {
    console.log(this.currentLoanAmount, this.interestRate, this.termInYears);
    var result = this.calculateMonthlyMortgagePayment(
      this.currentLoanAmount,
      this.interestRate,
      this.termInYears
    );
    result = Math.round(result * 100) / 100;
    var loanAmount = this.currentLoanAmount;
    var interestRate = this.interestRate / 100;
    var computedInterestRate = 0;
    var principleDue = 0;
    console.log(this.termInYears);
    var totalMonths = this.termInYears * 12;
    console.log(totalMonths);
    for (var i = 0; i < totalMonths; i++) {
      computedInterestRate = (loanAmount * interestRate) / 12;
      computedInterestRate = this.formatResult(computedInterestRate);
      this.computedInterestDue.push(computedInterestRate);
      principleDue = result - computedInterestRate;
      principleDue = this.formatResult(principleDue);
      this.principalDue.push(principleDue);
      loanAmount = loanAmount - principleDue;
      loanAmount = this.formatResult(loanAmount);
      this.principlebalance.push(loanAmount);
    }
    console.log(this.computedInterestDue);
    console.log(this.principalDue);
    console.log(this.principlebalance);
  }
  formatResult = (result: number) => {
    return isNaN(parseFloat(result.toFixed(2)))
      ? 0
      : Math.round(result * 100) / 100;
  };
  calculate() {
    this.calculateEstimatedMonthlyPayment();
  }
}
