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
      home_price: ["", Validators.required],
      down_payment: [null],
      interest_rate: [null],
      loan_term: [null],
      buy_closing: [null],
      property_tax: [null],
      tax_increase: [null],
      home_insurance: [null],
      hoa_fee: [null],
      maintenance_cost: [null],
      home_value_appreciation: [null],
      cost_insurance_increase: [null],
      selling_closing_costs: [null],

      monthly_rental_fee: [null],
      rental_fee_increase: [null],
      renter_insurance: [null],
      security_deposit: [null],
      upfront_cost: [null],

      average_investment_return: [null],
      marginal_federal_tax_rate: [null],
      marginal_state_tax_rate: [null],
      tax_filing_status: [null],
    });
  }

  //   downPaymentChanged(e) {
  //       this.DownPaymentPercent = e;
  //       this.DownPaymentUSD = (this.DownPaymentPercent * this.RentvsBuyForm.value.purchasePrice) / 100;
  //       this.downPaymentTypeUpdated(this.DownPaymentType);
  //       this.calculateEstimatedMonthlyPayment();
  //   }
  //   HomePriceChanged() {
  //       this.calculateEstimatedMonthlyPayment();
  //       this.DownPaymentUSD = (this.DownPaymentPercent * this.RentvsBuyForm.value.purchasePrice) / 100;
  //       this.downPaymentTypeUpdated(this.DownPaymentType);
  //   }
  // downPaymentTypeChanged(value) {
  //     this.DownPaymentType = value;
  //   this.downPaymentTypeUpdated(value);
  //   this.DownPaymentUSD = (this.DownPaymentPercent * this.RentvsBuyForm.value.purchasePrice) / 100;
  //   this.DownPaymentPercent = (this.DownPaymentUSD / this.RentvsBuyForm.value.purchasePrice) * 100;
  // }

  // monthly_rental_fee: [null],
  // rental_fee_increase: [null],
  // renter_insurance: [null],
  // security_deposit: [null],
  // upfront_cost: [null],
  calculateEstimatedMonthlyPayment() {
    this.averageMonthlyPayment = [];
    this.submitted = true;
    var monthlyfee = 0;
    var monthlyPrice = 0;
    monthlyfee = this.RentvsBuyForm.value.monthly_rental_fee;
    monthlyPrice = this.RentvsBuyForm.value.home_price;
    for (var i = 0; i < 30; i++) {
      if (i == 0) {
        var RentalFeeIncrease =
          (monthlyfee * this.RentvsBuyForm.value.rental_fee_increase) / 100;
        monthlyfee =
          this.RentvsBuyForm.value.upfront_cost +
          monthlyfee +
          RentalFeeIncrease +
          this.RentvsBuyForm.value.renter_insurance +
          this.RentvsBuyForm.value.security_deposit;

        var down_payment =
          (monthlyPrice * this.RentvsBuyForm.value.down_payment) / 100;
        var buy_closing =
          (monthlyPrice * this.RentvsBuyForm.value.buy_closing) / 100;
        var property_tax =
          (monthlyPrice * this.RentvsBuyForm.value.property_tax) / 100;
        var interest_rate =
          (monthlyPrice * this.RentvsBuyForm.value.interest_rate) / 100;
        var tax_increase =
          (monthlyPrice * this.RentvsBuyForm.value.tax_increase) / 100;
        var home_insurance = this.RentvsBuyForm.value.home_insurance;
        var hoa_fee = this.RentvsBuyForm.value.hoa_fee;
        var maintenance_cost =
          (monthlyPrice * this.RentvsBuyForm.value.maintenance_cost) / 100;
        var home_value_appreciation =
          (monthlyPrice * this.RentvsBuyForm.value.home_value_appreciation) /
          100;
        var cost_insurance_increase =
          (monthlyPrice * this.RentvsBuyForm.value.cost_insurance_increase) /
          100;
        var selling_closing_costs =
          (monthlyPrice * this.RentvsBuyForm.value.selling_closing_costs) / 100;
        monthlyPrice =
          down_payment +
          monthlyPrice * buy_closing +
          property_tax +
          interest_rate +
          tax_increase +
          home_insurance +
          hoa_fee +
          maintenance_cost +
          home_value_appreciation +
          cost_insurance_increase +
          selling_closing_costs;
      } else {
        // var RentalFeeIncrease = (monthlyfee * (this.RentvsBuyForm.value.rental_fee_increase / 100)) / 1.952;
        var RentalFeeIncrease =
          (monthlyfee * this.RentvsBuyForm.value.rental_fee_increase) / 100;
        var investment_return =
          (monthlyfee * this.RentvsBuyForm.value.average_investment_return) /
          100;
        var marginal_federal_tax_rate =
          (monthlyfee * this.RentvsBuyForm.value.marginal_federal_tax_rate) /
          100;
        var marginal_state_tax_rate =
          (monthlyfee * this.RentvsBuyForm.value.marginal_state_tax_rate) / 100;
        monthlyfee =
          this.RentvsBuyForm.value.upfront_cost +
          monthlyfee +
          RentalFeeIncrease +
          this.RentvsBuyForm.value.renter_insurance +
          this.RentvsBuyForm.value.security_deposit +
          investment_return -
          marginal_federal_tax_rate -
          marginal_state_tax_rate;

        var down_payment =
          (monthlyPrice * this.RentvsBuyForm.value.down_payment) / 100;
        var buy_closing =
          (monthlyPrice * this.RentvsBuyForm.value.buy_closing) / 100;
        var property_tax =
          (monthlyPrice * this.RentvsBuyForm.value.property_tax) / 100;
        var interest_rate =
          (monthlyPrice * this.RentvsBuyForm.value.interest_rate) / 100;
        var tax_increase =
          (monthlyPrice * this.RentvsBuyForm.value.tax_increase) / 100;
        var home_insurance = this.RentvsBuyForm.value.home_insurance;
        var hoa_fee = this.RentvsBuyForm.value.hoa_fee;
        var maintenance_cost =
          (monthlyPrice * this.RentvsBuyForm.value.maintenance_cost) / 100;
        var home_value_appreciation =
          (monthlyPrice * this.RentvsBuyForm.value.home_value_appreciation) /
          100;
        var cost_insurance_increase =
          (monthlyPrice * this.RentvsBuyForm.value.cost_insurance_increase) /
          100;
        var selling_closing_costs =
          (monthlyPrice * this.RentvsBuyForm.value.selling_closing_costs) / 100;
        monthlyPrice =
          down_payment +
          monthlyPrice * buy_closing +
          property_tax +
          interest_rate +
          tax_increase +
          home_insurance +
          hoa_fee +
          maintenance_cost +
          home_value_appreciation +
          cost_insurance_increase +
          selling_closing_costs;
      }
      monthlyfee = Math.floor(monthlyfee);
      const data = {
        year: i + 1,
        monthly_rent: monthlyfee,
        yearly_rent: monthlyfee * 12,
        monthly_price: monthlyPrice,
        yearly_price: monthlyPrice * 12,
      };
      this.averageMonthlyPayment.push(data);
    }

    // if(this.RentvsBuyForm.valid) {
    //   console.log(this.RentvsBuyForm.value.averageMonthlyPayment);
    // }
  }
  downPaymentTypeUpdated(value) {
    this.DownPaymentType = value;
    if (value == "usd") {
      this.RentvsBuyForm.controls.downPaymentInput.setValue(
        this.DownPaymentUSD
      );
    } else {
      this.RentvsBuyForm.controls.downPaymentInput.setValue(
        this.DownPaymentPercent
      );
    }
  }
}
