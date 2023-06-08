import { Component, OnInit } from "@angular/core";
import { NgForm } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { PostModel } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-property-info",
  templateUrl: "./property-info.component.html",
  styleUrls: ["./property-info.component.css"],
})
export class PropertyInfoComponent implements OnInit {
  number: number = 1;
  yes = false;
  isEdit = false;
  submitted = false;
  model: PostModel = new PostModel();
  states: any[] = [];
  state;
  cities: any[] = [];
  stateName;
  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private offline: OfflineService,
    private api: ApiService
  ) {
    this.route.params.subscribe((x) => {
      if (x.number) {
        this.number = x.number;
      } else {
        router.navigate(["1"]);
      }
    });
  }
  ngOnInit() {
    this.getStates();
    console.log(this.model.newHomeStateName);
    if (this.model.newHomeStateName) {
      this.getStateById(this.model.newHomeState);
    }
    this.getCities();
    this.model = this.offline.getStep().data;
  }
  onPehlaForm(f: NgForm, step: any) {
    this.submitted = true;
    console.log(f, step);
    if (f.valid) {
      this.router.navigate(["/app/purchase/property-info", step]);
      // this.onNewHomeClick();
      this.submitted = false;

      this.onNextClick();
    }
  }

  skip(step) {
    this.router.navigate(["/app/purchase/property-info", step]);
  }
  getStates() {
    this.api.get("StateService/GetStates").subscribe((x: any) => {
      if (x && x.result) {
        this.states = x.result;
        // console.log(this.model.newHomeState);
        // this.model.empState = "1";
        // this.model.currentStateId = 1;

        // this.model.newHomeState = "1";
        // this.model.newHomeState = x.result[0].id;
      }
    });
  }
  getCities() {
    this.api.get("CityService/GetCities").subscribe((x: any) => {
      if (x && x.result) this.cities = x.result;
    });
  }

  onStateChange(event) {
    console.log(event.target.value);
    this.getStateById(event.target.value);

    // this.states.forEach((element) => {
    //   if (element.id == event.target.value) {
    //     this.model.newHomeStateName = element.stateName;
    //     console.log(this.model.newHomeStateName);
    //   }
    // });
  }
  getStateById(id) {
    this.api.get("StateService/GetStates?id=" + id).subscribe((x: any) => {
      if (x && x.result) {
        this.model.newHomeStateName = x.result.stateName;
        console.log(this.model.newHomeStateName);
        // this.model.empState = "1";
        // this.model.currentStateId = 1;

        // this.model.newHomeState = "1";
        // this.model.newHomeState = x.result[0].id;
      }
    });
  }

  // onNewHomeClick() {
  //   this.offline.saveStep(3, this.model);
  // }
  // onNextTwoClick() {
  //   this.offline.saveStep(3, this.model);
  // }
  // onNextThreeClick() {
  //   this.offline.saveStep(3, this.model);
  // }
  onNextClick() {
    this.offline.saveStep(3, this.model);
  }
  onCreditClick(e) {
    this.model.creditScore = e;
    this.offline.saveStep(3, this.model);
  }
  onHomeTypeClick(e) {
    this.model.homeType = e;
    this.offline.saveStep(3, this.model);
  }
  onAccountNextClick() {
    this.offline.saveStep(3, this.model);
  }
  onNoaNextClick() {
    this.offline.saveStep(3, this.model);
  }
  onHomePlanClick(e) {
    this.model.homePlan = e;
    this.offline.saveStep(3, this.model);
  }
  onMilitaryClick(e) {
    this.model.isMillitary = e;
    this.offline.saveStep(3, this.model);
  }
  onEditNextClick() {
    this.offline.saveStep(3, this.model);
    this.isEdit = false;
  }

  calculatePercent() {
    console.log(this.model.downPaymentPercent);
    this.model.downPaymentPercent = String(
      // Math.round(
      (
        (Number(this.model.downPaymentAmount) /
          Number(this.model.estimatedPrice)) *
        100
      ).toFixed(1)
      // )
    );
  }

  calculateAmount() {
    this.model.downPaymentAmount = String(
      // Math.round(
      (
        (Number(this.model.downPaymentPercent) *
          Number(this.model.estimatedPrice)) /
        100
      ).toFixed(1)
      // )
    );
  }
  editClicked() {
    this.isEdit = true;
    let isMillitary;
    // document.getElementById(this.model.creditScore).classList.add("active");
    // document.getElementById(this.model.homeType).classList.add("active");
    // console.log(this.model.isMillitary, this.model.homePlan);
    // if (this.model.isMillitary) {
    //   isMillitary = "militery-yes";
    // } else {
    //   isMillitary = "militery-no";
    // }
    // document.getElementById(isMillitary).classList.add("active");
    // document
    //   .getElementById("property-" + this.model.homePlan)
    //   .classList.add("active");
  }

  doneClicked(f) {
    if (f.valid) {
      this.isEdit = false;
    }
  }
}
