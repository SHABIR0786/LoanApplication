import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { IBuyingHomeModel } from "@app/interfaces/IBuyingHomeModel";
import { HomeBuyingDataService } from "../../services/homeBuyingData.service";
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from "@angular/forms";
@Component({
  selector: "app-animated-step7",
  templateUrl: "./animated-step7.component.html",
  styleUrls: ["./animated-step7.component.css"],
})
export class AnimatedStep7Component implements OnInit {
  constructor(
    private formBuilder: FormBuilder,
    private _route: Router,
    private _homeBuyingDataService: HomeBuyingDataService
  ) {}
  formData: IBuyingHomeModel;
  form: FormGroup;
  submitted = false;
  get StepSevenControl() {
    return this.form.controls;
  }

  amount = 0;
  downPercent = 0;
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      amount: [null, Validators.required],
      downPercent: [null, [Validators.max(100), Validators.min(0)]],
    });
    this.formData = this._homeBuyingDataService.data;
    if (this.formData == null || this.formData == undefined) {
      this._route.navigate(["app/buy-a-home-animated-step1"]);
    }
  }

  proceedToPrevious() {
    this._route.navigate(["app/buy-a-home-animated-step6"]);
  }

  percentChange(e) {
    if (e.target.value > 100) {
      this.form.controls["downPercent"].setValue(100);
    }
    if (e.target.value < 0) {
      this.form.controls["downPercent"].setValue(0);
    }
    this.form.controls["amount"].setValue(
      this._homeBuyingDataService.data.purchasePrice * (e.target.value / 100)
    );
  }
  downPaymentChange(e) {
    console.log(e.target.value);
    if (e.target.value > this._homeBuyingDataService.data.purchasePrice) {
      e.preventDefault();
      this.form.controls["amount"].setValue(
        this._homeBuyingDataService.data.purchasePrice
      );
    }
    this.form.controls["downPercent"].setValue(
      (parseInt(e.target.value.split("$")[1]) /
        this._homeBuyingDataService.data.purchasePrice) *
        100
    );
  }

  proceedToNext() {
    var data = this.form.value;
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.formData.downPayment = data.amount;
    this.formData.downPaymentPercent = data.downPercent;
    this._homeBuyingDataService.data = this.formData;
    this._route.navigate(["app/buy-a-home-animated-step8"]);
  }
}
