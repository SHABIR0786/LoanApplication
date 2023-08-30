import { Component, OnInit } from "@angular/core";
import { MilitaryServiceModel } from "./military-service-model";
import { MilitaryServicesService } from "./military-services.service";
import { Router } from "@angular/router";
@Component({
  selector: "app-military-service",
  templateUrl: "./military-service.component.html",
  styleUrls: ["./military-service.component.css"],
})
export class MilitaryServiceComponent implements OnInit {
  currentDate: Date = new Date();
  militaryServiceModel: MilitaryServiceModel = new MilitaryServiceModel();
  constructor(
    private militaryServicesService: MilitaryServicesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.militaryServiceModel.isServeUSForces = false;

    if (
      localStorage.militaryServiceModel != undefined &&
      localStorage.militaryServiceModel != ""
    ) {
      this.militaryServiceModel = JSON.parse(
        localStorage.getItem("militaryServiceModel")
      );
    }
  }
  createMilitaryService() {
    if (this.militaryServiceModel.isServeUSForces == false) {
      this.militaryServiceModel.isCurrentlyServing = false;
      this.militaryServiceModel.isCurrentlyRetired = false;
      this.militaryServiceModel.isNonActivatedMember = false;
      this.militaryServiceModel.isSurvivingSpouse = false;
    }
    localStorage.setItem(
      "militaryServiceModel",
      JSON.stringify(this.militaryServiceModel)
    );
    this.militaryServicesService
      .createMilitaryService(this.militaryServiceModel)
      .subscribe((data: any) => {
        if (data.success == true) {
          alert("Data inserted successfully");
          this.router.navigateByUrl(
            "app/admin/incomplete-loan-application/demographic-info"
          );
        }
      });
  }
  assignValueToFlg() {
    this.militaryServiceModel.isServeUSForces = true;
  }
  removeValueFromFlg() {
    this.militaryServiceModel.isServeUSForces = false;
  }
  test() {
    debugger;
    var aa = this.militaryServiceModel.isServeUSForces;
  }
}
