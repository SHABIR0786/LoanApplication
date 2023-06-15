import { Component, OnInit } from "@angular/core";
import {DemographicInfoModels} from "./demographic-info-models"
import {DemographicInfoService} from "./demographic-info.service"
@Component({
  selector: "app-demographic-info",
  templateUrl: "./demographic-info.component.html",
  styleUrls: ["./demographic-info.component.css"],
})
export class DemographicInfoComponent implements OnInit {
  demographicInfoModels:DemographicInfoModels=new DemographicInfoModels();
  constructor(private demographicInfoService:DemographicInfoService) {}

  ngOnInit(): void {}

  create()
  { 
    if(this.demographicInfoModels.canNotProvideEthnicInfo ==false)
    {
      this.demographicInfoModels.demographicInfoByFinancialInstitution.isEthnicityByObservation= true;
    }
    if(this.demographicInfoModels.canNotProvideRaceInfo == false)
    {
      this.demographicInfoModels.demographicInfoByFinancialInstitution.isRaceByObservation= true;
    }

    if(this.demographicInfoModels.canNotProvideSexInfo == false)
    {
      this.demographicInfoModels.demographicInfoByFinancialInstitution.isGenderByObservation = true;
    }
    var obj =this.demographicInfoModels
    this.demographicInfoService.create(obj).subscribe((data:any)=>{
      if(data.success == true)
      {
        alert("Data inserted successfully")
      }
    })
  }
}
