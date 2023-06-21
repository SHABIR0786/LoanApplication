import { Component, OnInit } from "@angular/core";
import {LoanOriginatorInfoModels} from "./loan-originator-info-models";
import {LoanOriginatorInfoService} from "./loan-originator-info.service";
@Component({
  selector: "app-loan-originator-information",
  templateUrl: "./loan-originator-information.component.html",
  styleUrls: ["./loan-originator-information.component.css"],
})
export class LoanOriginatorInformationComponent implements OnInit {
  loanOriginatorInfoModels:LoanOriginatorInfoModels =  new LoanOriginatorInfoModels();
  constructor(private loanOriginatorInfoService:LoanOriginatorInfoService) {}

  ngOnInit(): void {}
  create()
  {
    this.loanOriginatorInfoService.create(this.loanOriginatorInfoModels).subscribe((data:any)=>{
      debugger
      if(data.success == true)
      {
        alert("Data inserted successfully")
      }
      
    })
  }
}
