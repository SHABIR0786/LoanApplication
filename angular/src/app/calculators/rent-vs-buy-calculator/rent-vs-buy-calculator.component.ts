import { Component, OnInit } from "@angular/core";
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from "@angular/forms";

@Component({
  selector: "app-rent-vs-buy-calculator",
  templateUrl: "./rent-vs-buy-calculator.component.html",
  styleUrls: ["./rent-vs-buy-calculator.component.css"],
})
export class RentVsBuyCalculatorComponent implements OnInit {
  RentvsBuyForm: FormGroup;
  form: Object = {};
  submitted = false;
  averageMonthlyPayment = [];
  rental = {};
  DownPaymentType = "usd";
  DownPaymentPercent = 0;
  DownPaymentUSD = 50000;
  fillingTaxStatus = [
    "Single",
    "Married Filing Jointly",
    "Married Filing Separately",
    "Head of Household",
    "Qualified Widow",
  ];
  RateYourCreditOptions = [
    { value: "Excellent (720 or above)", key: 0 },
    { value: "Good (660 - 719)", key: 1 },
    { value: "Average (620 - 659)", key: 2 },
    { value: "Below Average (580 - 619)", key: 3 },
    { value: "Poor (579 and below)", key: 4 },
  ];
  constructor(private fb: FormBuilder) {}
  get RentvsBuyFormControl() {
    return this.RentvsBuyForm.controls;
  }
  myForm() {}
  ngOnInit(): void {
    this.RentvsBuyForm = this.fb.group({
      zipCode: ["", Validators.required],
      creditScore: ["", Validators.required],
      purchasePrice: ["", Validators.required],
      loanTerm: ["", Validators.required],
      interestRate: ["", Validators.required],
      monthlyPayment: ["", Validators.required],
    });
  }
  downPaymentTypeUpdated(value) {
    if (value == "usd") {
      this.RentvsBuyForm.value.DownPayment = this.DownPaymentUSD;
    } else {
      this.RentvsBuyForm.value.DownPayment = this.DownPaymentPercent;
    }
  }
  downPaymentTypeChanged(value) {
    this.downPaymentTypeUpdated(value);
    this.DownPaymentUSD =
      (this.DownPaymentPercent * this.RentvsBuyForm.value.purchasePrice) / 100;
    this.DownPaymentPercent =
      (this.DownPaymentUSD / this.RentvsBuyForm.value.purchasePrice) * 100;
  }
  calculateEstimatedMonthlyPayment() {
    this.submitted = true;
    var monthlyfee = 0;
    monthlyfee = this.RentvsBuyForm.value.monthlyRentalFee;
    for (var i = 0; i < 30; i++) {
      if (i == 0) {
        var RentalFeeIncrease =
          (monthlyfee * this.RentvsBuyForm.value.rentalFeeIncrease) / 100;
        monthlyfee =
          monthlyfee +
          this.RentvsBuyForm.value.renterInsurance +
          RentalFeeIncrease;
      } else {
        var RentalFeeIncrease =
          (monthlyfee * (this.RentvsBuyForm.value.rentalFeeIncrease / 100)) /
          1.952;
        monthlyfee = monthlyfee + RentalFeeIncrease;
      }
      monthlyfee = Math.round(monthlyfee);
      this.averageMonthlyPayment.push(monthlyfee);
    }
    console.log(this.averageMonthlyPayment);
    // if(this.RentvsBuyForm.valid) {
    //   console.log(this.RentvsBuyForm.value.averageMonthlyPayment);
    // }
  }
}
