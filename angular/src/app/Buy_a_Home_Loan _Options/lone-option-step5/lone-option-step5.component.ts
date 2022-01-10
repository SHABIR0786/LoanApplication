import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IBuyingHomeLoanOptionModel } from "@app/interfaces/IBuyingHomeLoanOptionModel";
import { LoanOptionHomeBuyingDataService } from "../../services/loanOptionHomeBuyingData.service";
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from "@angular/forms";
@Component({
  selector: "app-lone-option-step5",
  templateUrl: "./lone-option-step5.component.html",
  styleUrls: ["./lone-option-step5.component.css"],
})
export class LoneOptionStep5Component implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private _route: Router,
    private _loanOptionHomeBuyingDataService: LoanOptionHomeBuyingDataService
  ) {}
  formData: IBuyingHomeLoanOptionModel;
  form: FormGroup;
  submitted = false;
  Percentage = null;

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      estimatePrice: [null, Validators.required],
      downPayment: [null, Validators.required],
    });
    this.formData = this._loanOptionHomeBuyingDataService.data;
    if (this.formData == null || this.formData == undefined) {
      this._route.navigate(["app/buy-a-home-loan-options-animated-step1"]);
    }
    this.Percentage = this.formData.downPaymentPercent;
  }
  percentChange() {
    this.form.value.estimatePrice = parseInt(this.form.value.estimatePrice);
    this.form.value.downPayment = parseInt(this.form.value.downPayment);
    if (this.form.value.downPayment <= this.form.value.estimatePrice) {
      this.Percentage =
        (this.form.value.downPayment / this.form.value.estimatePrice) * 100;
      this.Percentage = this.Percentage.toFixed(0);
      this.submitted = true;
    } else {
      this.form.controls["downPayment"].setValue(0);
      this.Percentage = 0;
      this.submitted = false;
    }
  }
  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-loan-options-animated-step4"]);
  }
  proceedToNext() {
    var data = this.form.value;
    if (this.form.invalid && !this.submitted) {
      return;
    }
    this.formData.estimatePrice = data.estimatePrice;
    this.formData.downPayment = data.downPayment;
    this.formData.downPaymentPercent = this.Percentage;
    this._loanOptionHomeBuyingDataService.data = this.formData;
    this._route.navigate(["app/buy-a-home-loan-options-animated-step6"]);
  }
}
