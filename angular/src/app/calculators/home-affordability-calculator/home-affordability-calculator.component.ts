import { Component, OnInit } from "@angular/core";
import {   FormGroup,
  Validators,
  FormBuilder, } from "@angular/forms";

@Component({
  selector: "app-home-affordability-calculator",
  templateUrl: "./home-affordability-calculator.component.html",
  styleUrls: ["./home-affordability-calculator.component.css"],
})
export class HomeAffordabilityCalculatorComponent implements OnInit {
  constructor(private fb: FormBuilder) {}
  homeAffordAbility: FormGroup;
  get homeAffordAbilityControl() {
    return this.homeAffordAbility.controls;
  }
  submitted = false;
  annualIncome = 0;
  monthlyDebt = 0;
  downPayment = 0;
  zipCode = 0;
  RateYourCreditOptions = [
    { value: "Excellent (760+)", key: 1 },
    { value: "Very Good (720 - 759)", key: 2 },
    { value: "Good (680 - 719)", key: 3 },
    { value: "Average (620 - 679)", key: 4 },
    { value: "Fair (580 - 619)", key: 5 },
    { value: "Poor (579 and below)", key: 6 }
  ];
  
  ngOnInit(): void {
    this.homeAffordAbility = this.fb.group({
      annualIncome: ["", Validators.required],
      monthlyDebt: ["", Validators.required],
      downPayment: ["", Validators.required],
      zipCode: ["", Validators.required],
      creditScore: ["", Validators.required]
    });
    this.homeAffordAbility.controls['creditScore'].setValue(1);
  }

  calculatePrincipleAmount = (monthly, interestRate, termInYears) => {
    interestRate = interestRate === 0 ? 0 : interestRate / 100;
    const monthlyInterestRate = interestRate === 0 ? 0 : interestRate / 12;
    const numberOfMonthlyPayments = termInYears * 12;
    var principal = monthly /((monthlyInterestRate *
        Math.pow(1 + monthlyInterestRate, numberOfMonthlyPayments)) /
        (Math.pow(1 + monthlyInterestRate, numberOfMonthlyPayments) - 1) || 0);
        return principal;
  };


  calculate() {
    this.submitted = true;
    var monthlyGrossIncome = this.homeAffordAbility.value.annualIncome / 12;
    var monthlyPITI = monthlyGrossIncome * 0.32;
    if(this.homeAffordAbility.value.monthlyDebt > 0) {
    var monthlyPaymentwithoutDebit = (monthlyPITI - this.homeAffordAbility.value.monthlyDebt) + 2;
    }else{
      var monthlyPaymentwithoutDebit = monthlyPITI;
    }
    var interestRate = 0;
    if(this.homeAffordAbility.value.creditScore == 1){
      interestRate = 3.750;
    }else if(this.homeAffordAbility.value.creditScore == 2){
      interestRate = 3.790;
    }else if(this.homeAffordAbility.value.creditScore == 3){
      interestRate = 4.793;
    }else if(this.homeAffordAbility.value.creditScore == 4){
      interestRate = 5.339;
    }
    console.log(monthlyPaymentwithoutDebit);
    var principal = this.calculatePrincipleAmount(monthlyPaymentwithoutDebit,interestRate,30);
    var totalPrincipal =  principal + this.homeAffordAbility.value.downPayment;
    console.log(totalPrincipal);
    // var YearlyPropertyTaxes = totalPrincipal * (1.20/100) 
    // var YearlyHomeInsuranceinPercent = 15.13023659084891 * 0.42;
    // // var Taxes = Math.ceil((YearlyPropertyTaxes / 12) * 100) / 100;
    // var Insurance = (YearlyHomeInsuranceinPercent * totalPrincipal / 100);
    // totalPrincipal = totalPrincipal - Insurance;
    // console.log(totalPrincipal);
    // var DITI = (this.homeAffordAbility.value.monthlyDebt / monthlyGrossIncome) * 100;
  }
}
