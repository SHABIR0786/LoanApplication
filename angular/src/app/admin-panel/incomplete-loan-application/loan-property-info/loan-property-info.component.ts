import { Component, OnInit } from "@angular/core";
import {LoanPropertyInfoModels,NewMortgageLoans,GiftsOrGrants} from "./loan-property-info-models"
import {LoanPropertyInfoService} from "./loan-property-info.service"
@Component({
  selector: "app-loan-property-info",
  templateUrl: "./loan-property-info.component.html",
  styleUrls: ["./loan-property-info.component.css"],
})
export class LoanPropertyInfoComponent implements OnInit {
  flgOtherNewMortgageLoans:boolean=false;
  flgRentalIncome:boolean=false;
  flgGiftsorGrants :boolean=false;
  loanPropertyInfoModel:LoanPropertyInfoModels = new LoanPropertyInfoModels()
  cityList:any[]=[];
  countryList:any[]=[];
  stateList:any[]=[];
  constructor(private loanPropertyInfoService:LoanPropertyInfoService) {}

  ngOnInit(): void {
    debugger
    this.getCities();
    this.getCountries();
    this.getStates();
  }
  getCountries()
  {
    debugger
    this.loanPropertyInfoService.getCountries().subscribe((data:any)=>{
      debugger
      this.countryList=[]
      if(data.success == true && data.result.length > 0)
      {
        data.result.forEach((element:any)=>{
          debugger
          this.countryList.push({countryName:element.countryName,id:element.id})
        })
      }
    })
  }
  getStates(  )
  {
    debugger
    this.loanPropertyInfoService.getStates().subscribe((data:any)=>{
      debugger
      this.stateList=[]
      if(data.success == true && data.result.length > 0)
      {
        data.result.forEach((element:any)=>{
          debugger
          this.stateList.push({stateName:element.stateName,id:element.id})
        })
      }
    })
  }
  getCities()
  {debugger
    this.loanPropertyInfoService.getCities().subscribe((data:any)=>{
      debugger
      this.cityList=[]
       if(data.success == true && data.result.length > 0)
      {
        data.result.forEach((element:any)=>{
          debugger
          this.cityList.push({cityName:element.cityName,id:element.id})
        })
      }
    })
  }
  addMortgageLoanList()
  {
    debugger
    this.loanPropertyInfoModel.newMortgageLoans.push(new NewMortgageLoans())
  }
  removeMortgageLoanList(){
    debugger
    var mortgageFinancialLength =this.loanPropertyInfoModel.newMortgageLoans.length;
    if(mortgageFinancialLength == 1)
    {
      return;
    }
    else
    {
      this.loanPropertyInfoModel.newMortgageLoans.splice(1,mortgageFinancialLength)
    }
    
  }
  addGiftsOrGrants()
  {
    debugger
    this.loanPropertyInfoModel.giftsOrGrants.push(new GiftsOrGrants())
  }
  removeGiftsOrGrants(){
    debugger
    var mortgageFinancialLength =this.loanPropertyInfoModel.giftsOrGrants.length;
    if(mortgageFinancialLength == 1)
    {
      return;
    }
    else
    {
      this.loanPropertyInfoModel.giftsOrGrants.splice(1,mortgageFinancialLength)
    }
    
  }
  create()
  {
    if(this.flgOtherNewMortgageLoans == true)
    {
      this.loanPropertyInfoModel.newMortgageLoans=[];
    }
    if(this.flgRentalIncome == true)
    {
      this.loanPropertyInfoModel.rentalIncome=null;
    }
    if(this.flgGiftsorGrants == true)
    {
      this.loanPropertyInfoModel.giftsOrGrants=[];
    }
    var obj=this.loanPropertyInfoModel;
    this.loanPropertyInfoService.create(obj).subscribe((data:any)=>{
      if(data.success == true)
      {
        alert("Data inserted successfully")
      }
    })
  }
}
