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
  model: PostModel = new PostModel();
  states: any[] = [];
  cities: any[] = [];
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
    this.getCities();
    this.model = this.offline.getStep().data;
  }
  onPehlaForm(f: NgForm) {
    this.router.navigate(["/app/purchase/property-info", 2]);
    this.onNewHomeClick();
  }
  getStates() {
    this.api.get("State/states").subscribe((x: any) => {
      if (x && x.result) {
        this.states = x.result;
        this.model.empState = "1";
        this.model.currentStateId = 1;
        this.model.newHomeState = "1";
        //this.model.newHomeState = x.result[0].id;
      }
    });
  }
  getCities() {
    this.api.get("City/cities").subscribe((x: any) => {
      if (x && x.result) this.cities = x.result;
    });
  }

  onNewHomeClick() {
    this.offline.saveStep(3, this.model);
  }
  onNextTwoClick() {
    this.offline.saveStep(3, this.model);
  }
  onNextThreeClick() {
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
  }
  onPriceKeyUp() {
    this.model.downPaymentPercent =
      (parseFloat(this.model.downPaymentAmount ?? "0") * 100) /
        parseFloat(this.model.estimatedPrice ?? "0") +
      "";
  }
}
