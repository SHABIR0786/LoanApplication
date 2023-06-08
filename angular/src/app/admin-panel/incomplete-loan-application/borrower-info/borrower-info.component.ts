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

  }

  ngOnInit(): void {
    this.creditClick();
    // this.borrowService.getAllCitizenshipType().subscribe(
    //   (res: any) => {
    //     console.log(res.result);
    //     //this.Custom = res.result.items;
    //   }
    // );
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
    this.borrowService.createMortgageLoanApplication(this.borrowerInfo).subscribe(
         (res: any) => {
        console.log(res.result);
        alert("data has inserted successfully");
      }
    );
  }
}
