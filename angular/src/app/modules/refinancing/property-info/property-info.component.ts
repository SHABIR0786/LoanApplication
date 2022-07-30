import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { RefinancePost } from "@app/modules/models/post.model";
import { ApiService } from "@app/services/api.service";
import { OfflineService } from "@app/services/offline.service";

@Component({
  selector: "app-property-info",
  templateUrl: "./property-info.component.html",
  styleUrls: ["./property-info.component.css", "./../index.component.css"],
})
export class PropertyInfoComponent implements OnInit {
  number: number = 1;
  model: RefinancePost = new RefinancePost();
  states: any[] = [];
  cities: any[] = [];
  countries: any[] = [];
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
        this.router.navigate(["1"]);
      }
    });
  }

  ngOnInit() {
    this.getStates();
    this.getCities();
    this.getCountries();
    this.model = this.offline.getStep().data;
  }
  getStates() {
    this.api.get("State/states").subscribe((x: any) => {
      if (x && x.result) {
        this.states = x.result;
        this.model.empState = 1;
        this.model.currentStateId = 1;
        this.model.personalStateId = 1;
        this.model.propertyStateId = 1;
      }
    });
  }
  getCountries() {
    this.api.get("Country/Country/Countries").subscribe((x: any) => {
      if (x && x.result) this.countries = x.result;
    });
  }
  getCities() {
    this.api.get("City/cities").subscribe((x: any) => {
      if (x && x.result) this.cities = x.result;
    });
  }
  onScoreClick(obj: string) {
    this.model.creditScore = obj;
    this.saveStep();
  }
  onHomeClick(obj: string) {
    this.model.typeOfHome = obj;
    this.saveStep();
  }
  onCurHome(obj: string) {
    this.model.currentlyUsingHomeAs = obj;
    this.saveStep();
  }
  milClick(obj: boolean) {
    this.model.isMilitaryMember = obj == true ? 1 : 0;
    this.saveStep();
  }
  saveStep() {
    this.offline.saveStep(2, this.model);
  }
}
