import { Component, OnInit } from "@angular/core";
import {MilitaryServiceModel} from "./military-service-model";
import {MilitaryServicesService} from "./military-services.service"
@Component({
  selector: "app-military-service",
  templateUrl: "./military-service.component.html",
  styleUrls: ["./military-service.component.css"],
})
export class MilitaryServiceComponent implements OnInit {
  militaryServiceModel:MilitaryServiceModel = new MilitaryServiceModel()
  constructor(private militaryServicesService:MilitaryServicesService) {}

  ngOnInit(): void {}
  createMilitaryService(){
    if(this.militaryServiceModel.isServeUSForces == false)
    {
      this.militaryServiceModel.isCurrentlyServing = false;
      this.militaryServiceModel.isCurrentlyRetired= false;
      this.militaryServiceModel.isNonActivatedMember= false;
      this.militaryServiceModel.isSurvivingSpouse= false;
    }
    this.militaryServicesService.createMilitaryService(this.militaryServiceModel).subscribe((data:any)=>{
      if(data.success == true)
      {
        alert("Data inserted successfully")
      }
    })
  }
  assignValueToFlg()
  {
    this.militaryServiceModel.isServeUSForces = true;
  }
  removeValueFromFlg()
  {
    this.militaryServiceModel.isServeUSForces = false;
   
  }
}
