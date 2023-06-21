import { Component, OnInit } from "@angular/core";
import {Address, AlternateNames, BorrowModel, CreditList, Employment, GrossMonthlyIncome, IncomeOtherSource, PersonalInformation, Source} from './borrower-model';
import { LoanManagementService } from "@shared/service/loanmanagement.service";
import { BorrowService } from "app/services/borrow.service";
 

@Component({
  selector: "app-borrower-info",
  templateUrl: "./borrower-info.component.html",
  styleUrls: ["./borrower-info.component.css"],
})
export class BorrowerInfoComponent implements OnInit {
  borrowerInfo: BorrowModel= new BorrowModel();
  doNotApplyForaddress1:boolean = false;
  doNotApplyForaddress2:boolean = false;
  doNotApplyForEmp0:boolean = false;
  doNotApplyForEmp1:boolean = false;
  doNotApplyForEmp2:boolean = false;
  incomeFromOtherSources:boolean = false;
  countryList:any[]=[];
  stateList:any[]=[];
  cityList:any[]=[];
  constructor(private loanManagmentService: LoanManagementService, private borrowService:BorrowService) {
    this.borrowerInfo.personalInformation = new PersonalInformation();
    this.borrowerInfo.personalInformation.alternateNames = new AlternateNames();
    this.borrowerInfo.personalInformation.address = [];
    this.borrowerInfo.personalInformation.address.push(new Address());
    this.borrowerInfo.personalInformation.address.push(new Address());
    this.borrowerInfo.personalInformation.address.push(new Address());
    this.borrowerInfo.employment = [];
    this.borrowerInfo.employment.push(new Employment()); // employement
    this.borrowerInfo.employment[0].grossMonthlyIncome = new GrossMonthlyIncome();
    this.borrowerInfo.employment.push(new Employment()); //additional employement
    this.borrowerInfo.employment[1].grossMonthlyIncome = new GrossMonthlyIncome();
    this.borrowerInfo.employment.push(new Employment()); //current or previous employement
    this.borrowerInfo.employment[2].grossMonthlyIncome = new GrossMonthlyIncome();
    this.borrowerInfo.incomeOtherSources =[];
    this.borrowerInfo.incomeOtherSources.push(new IncomeOtherSource());
    // this.borrowerInfo.incomeOtherSources.push(new IncomeOtherSource());
    // this.borrowerInfo.incomeOtherSources.push(new IncomeOtherSource());
    this.borrowerInfo.incomeOtherSources[0].sources = [];
    this.borrowerInfo.incomeOtherSources[0].sources.push(new Source());
    //this.bindValues();
  }

  ngOnInit(): void {
    this.getCountries();
    this.getStates();
    this.getCities()
    this.creditClick();  
    this.borrowService.getAllCitizenshipType().subscribe(
      (res: any) => {
        console.log(res.result);
        //this.Custom = res.result.items;
      }
    );
    
  }
  
  creditClick(){
    debugger;
    if(this.borrowerInfo.personalInformation.creditValue == "1"){
      this.borrowerInfo.personalInformation.totalBorrowers = 1;
    }
    this.borrowerInfo.personalInformation.creditList=[];
    for(var i =0; i<this.borrowerInfo.personalInformation.totalBorrowers ; i++ ){
      this.borrowerInfo.personalInformation.creditList.push(new CreditList());
    }
  }
  addMoreIncomeSource(){
    this.borrowerInfo.incomeOtherSources[0].sources.push(new Source());
  }
  delMoreIncomeSource(){
    this.borrowerInfo.incomeOtherSources[0].sources.splice(-1);
  }
  nextBtnClick(){
    console.log(this.borrowerInfo);
    debugger;
    if(this.doNotApplyForaddress1){
      this.borrowerInfo.personalInformation.address[1] = new Address();
    }
    if(this.doNotApplyForaddress2){
      this.borrowerInfo.personalInformation.address[2] = new Address();
    }
    if(this.doNotApplyForEmp0){
      this.borrowerInfo.employment[0] = new Employment();
    }
    if(this.doNotApplyForEmp1){
      this.borrowerInfo.employment[1] = new Employment();
    }
    if(this.doNotApplyForEmp2){
      this.borrowerInfo.employment[2] = new Employment();
    }
    debugger
    this.borrowService.createMortgageLoanApplication(this.borrowerInfo).subscribe(
         (res: any) => {
        console.log(res.result);
        alert("data has inserted successfully");
      }
    );
  }
  getCountries()
  {
    debugger
    this.borrowService.getCountries().subscribe((data:any)=>{
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
    this.borrowService.getStates().subscribe((data:any)=>{
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
    this.borrowService.getCities().subscribe((data:any)=>{
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
  // bindValues() {
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  //   this.borrowerInfo.personalInformation.firstName = "fffff";
  // }
}

