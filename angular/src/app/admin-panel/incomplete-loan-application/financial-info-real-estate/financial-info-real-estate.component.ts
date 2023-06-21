import { Component, OnInit } from "@angular/core";
import {FinancialInfoRealEstate,MortgageLoanOnProperty} from "./financial-info-real-estate-model";
import {FinancialInfoRealEstateService} from "./financial-info-real-estate.service"
@Component({
  selector: "app-financial-info-real-estate",
  templateUrl: "./financial-info-real-estate.component.html",
  styleUrls: ["./financial-info-real-estate.component.css"],
})
export class FinancialInfoRealEstateComponent implements OnInit {
  objFinancialInfoRealState :FinancialInfoRealEstate = new FinancialInfoRealEstate()
  financialInfoRealState:FinancialInfoRealEstate[]=[new FinancialInfoRealEstate()]
  constructor(private financialInfoRealEstateService:FinancialInfoRealEstateService) {}
  cityList:any[]=[]
  countryList:any[]=[]
  stateList:any[]=[]
  objMortgageLoanProperty:MortgageLoanOnProperty = new MortgageLoanOnProperty()
  ngOnInit(): void {
    debugger
    // this.financialInfoRealState.push(this.objFinancialInfoRealState)
    this.getCities();
    this.getCountries();
    this.getStates();
  }
  getCountries()
  {
    debugger
    this.financialInfoRealEstateService.getCountries().subscribe((data:any)=>{
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
    this.financialInfoRealEstateService.getStates().subscribe((data:any)=>{
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
    this.financialInfoRealEstateService.getCities().subscribe((data:any)=>{
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
  addMortgageLoanList(index:any)
  {
    debugger
    this.financialInfoRealState[index].mortgageLoanOnProperty.push(new MortgageLoanOnProperty())
  }
  removeMortgageLoanList(index:any){
    debugger
    var indexList:any[]=[]
    if(this.financialInfoRealState[index].mortgageLoanOnProperty.length > 0)
    {
      debugger
      this.financialInfoRealState[index].mortgageLoanOnProperty.forEach((element:any,index:any)=>{
        if(element.isPaidBeforeClosing == true)
        {
          indexList.push({index:index})
        }
      })
      if(indexList.length > 0)
      {
        debugger
        indexList.sort((a:any,b:any)=>{
          return b.index - a.index
        })
        debugger
        indexList.forEach((element:any)=>{
          debugger
          this.financialInfoRealState[index].mortgageLoanOnProperty.splice(element.index,1)
        })
      }
      else
      {
        var mortgageFinancialLength = this.financialInfoRealState[index].mortgageLoanOnProperty.length;
        if(mortgageFinancialLength == 1)
        {
          return;
        }
        else
        {
          var obj= mortgageFinancialLength - 1;
          this.financialInfoRealState[index].mortgageLoanOnProperty.splice(obj,1)
        }
      }
    
    }
    // isPaidBeforeClosing
    
    
  }
  create()
  {
    debugger
    var obj=this.financialInfoRealState
    this.financialInfoRealEstateService.create(obj).subscribe((data:any)=>{
      debugger
      if(data.success == true)
      {
        alert("Data added successfully");
      }
    })
  }
  addMoreProperty()
  {
    this.financialInfoRealState.push(this.objFinancialInfoRealState);
  }
  changeCheckBox(index:any){
    debugger
    if(this.financialInfoRealState[index].flgApplicableNotApply ==false)
    {
      this.financialInfoRealState[index].flgApplicableNotApply =true; 
    }
    else
    {
      this.financialInfoRealState[index].flgApplicableNotApply =false; 
    }
    this.financialInfoRealState[0].flgApplicableNotApply=false;
    
  }
}
