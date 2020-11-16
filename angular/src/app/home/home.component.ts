import {
  Component,
  Injector,
  ChangeDetectionStrategy,
  OnInit,
  DoCheck,
} from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";
import { appModuleAnimation } from "@shared/animations/routerTransition";

@Component({
  templateUrl: "./home.component.html",
  animations: [appModuleAnimation()],
  changeDetection: ChangeDetectionStrategy.OnPush,
  styleUrls: ["./home.component.css"],
})
export class HomeComponent extends AppComponentBase implements OnInit, DoCheck {
  // buyingAHome: string = "Buying A home Guide";

  constructor(injector: Injector) {
    super(injector);
  }

  firstName: string = "";
  lastName: string = "";
  email: string = "";
  phoneNumber?: number = null;
  mortgagePurposes = [];
  howDoYouWantToBorrows = [];

  loadMortgagePurposes() {
    this.mortgagePurposes = [
      { id: 1, name: "Found A Home/ Made An Offer" },
      { id: 2, name: "Still Looking For A Home" },
      { id: 3, name: "Refinance" },
      { id: 4, name: "Refinance With Cashout" },
    ];
  }

  loadHowDoYouWantToBorrows() {
    this.howDoYouWantToBorrows = [
      { id: 1, name: "found" },
      { id: 2, name: "still" },
      { id: 3, name: "refinance" },
      { id: 4, name: "With" },
    ];
  }

  ngDoCheck() {
    console.log(this.firstName);
    console.log(this.lastName);
    console.log(this.email);
    console.log(this.phoneNumber);
    console.log(this.mortgagePurposes);
    console.log(this.howDoYouWantToBorrows);
  }

  ngOnInit() {
    this.loadMortgagePurposes();
    this.loadHowDoYouWantToBorrows();
  }
}
