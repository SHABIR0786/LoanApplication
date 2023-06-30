import { Component, OnInit } from "@angular/core";
import { DemographicInfoModels } from "./demographic-info-models";
import { DemographicInfoService } from "./demographic-info.service";
import { Router } from "@angular/router";
@Component({
  selector: "app-demographic-info",
  templateUrl: "./demographic-info.component.html",
  styleUrls: ["./demographic-info.component.css"],
})
export class DemographicInfoComponent implements OnInit {
  demographicInfoModels: DemographicInfoModels = new DemographicInfoModels();
  constructor(
    private demographicInfoService: DemographicInfoService,
    private router: Router
  ) {}

  ngOnInit(): void {
    if (
      localStorage.demographicInfoModels != undefined &&
      localStorage.demographicInfoModels != ""
    ) {
      this.demographicInfoModels = JSON.parse(
        localStorage.getItem("demographicInfoModels")
      );
    }
  }

  create() {
    if (this.demographicInfoModels.canNotProvideEthnicInfo == false) {
      this.demographicInfoModels.demographicInfoByFinancialInstitution.isEthnicityByObservation = true;
    }
    if (this.demographicInfoModels.canNotProvideRaceInfo == false) {
      this.demographicInfoModels.demographicInfoByFinancialInstitution.isRaceByObservation = true;
    }

    if (this.demographicInfoModels.canNotProvideSexInfo == false) {
      this.demographicInfoModels.demographicInfoByFinancialInstitution.isGenderByObservation = true;
    }
    var obj = this.demographicInfoModels;
    localStorage.setItem("demographicInfoModels", JSON.stringify(obj));
    this.demographicInfoService.create(obj).subscribe((data: any) => {
      if (data.success == true) {
        alert("Data inserted successfully");
        this.router.navigateByUrl(
          "app/admin/incomplete-loan-application/loan-originator-info"
        );
      }
    });
  }
}
