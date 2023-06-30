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
  submitted = false;
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
    this.api.get("StateService/GetStates").subscribe((x: any) => {
      if (x && x.result) {
        this.states = x.result;
        this.model.empState = 1;
        this.model.currentStateId = 1;
        this.model.personalStateId = 1;
        this.model.propertyStateId = 1;
      }
    });
  }
  onStateChange(event) {
    console.log(event.target.value);
    this.getStateById(event.target.value);
  }
  getStateById(id) {
    this.api.get("StateService/GetStates?id=" + id).subscribe((x: any) => {
      if (x && x.result) {
        this.model.propertyStateName = x.result.stateName;
        console.log(this.model.propertyStateName);
        // this.model.empState = "1";
        // this.model.currentStateId = 1;

        // this.model.newHomeState = "1";
        // this.model.newHomeState = x.result[0].id;
      }
    });
  }
  getCountries() {
    this.api.get("CountryService/GetCountries").subscribe((x: any) => {
      if (x && x.result) this.countries = x.result;
    });
  }
  getCities() {
    this.api.get("CityService/GetCities").subscribe((x: any) => {
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
  onNextClick(f, step) {
    this.submitted = true;
    if (f.valid) {
      this.saveStep();
      this.router.navigate(["/app/refinance/property-info/" + step]);
      this.submitted = false;
    }
  }
  getEditData() {
    let isMillitary;
    if (this.model.isMilitaryMember) {
      isMillitary = "militery-yes";
    } else {
      isMillitary = "militery-no";
    }
    document.getElementById(this.model.objectiveReason).classList.add("blue");
    document.getElementById(this.model.creditScore).classList.add("blue");
    document.getElementById(this.model.typeOfHome).classList.add("blue");
    document
      .getElementById(this.model.currentlyUsingHomeAs)
      .classList.add("blue");
    document.getElementById(isMillitary).classList.add("blue");
  }
}
