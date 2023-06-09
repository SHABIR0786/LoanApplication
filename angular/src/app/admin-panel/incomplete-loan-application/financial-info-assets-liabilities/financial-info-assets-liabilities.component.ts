import { Component, OnInit } from "@angular/core";
import{FinancialInfoAssetsLiabilitiesModels,MortgageFinancialAssets,MortgageFinancialOtherAssets,MortgageFinancialLiabilities,MortgageFinancialOtherLaibilities} from './financial-info-assets-liabilities-models';
import {FinancialInfoAssetsLiabilitiesService} from './financial-info-assets-liabilities.service';
@Component({
  selector: "app-financial-info-assets-liabilities",
  templateUrl: "./financial-info-assets-liabilities.component.html",
  styleUrls: ["./financial-info-assets-liabilities.component.css"],
})
export class FinancialInfoAssetsLiabilitiesComponent implements OnInit {
  constructor(private financialInfoService:FinancialInfoAssetsLiabilitiesService) {}
  flgMortgageFinancialOtherAssets:boolean=false;
  flgMortgageFinancialLiabilities:boolean=false;
  flgMortgageFinancialOtherLaibilities:boolean=false;
  totalMortgageFinancialAssets:number;
  totalMortgageFinancialOtherAssets:number;
  totalMortgageFinancialOtherLaibilities:number;
  mortgageFinancialAssets:MortgageFinancialAssets= new MortgageFinancialAssets();
  mortgageFinancialOtherAssets:MortgageFinancialOtherAssets= new MortgageFinancialOtherAssets();
  mortgageFinancialLiabilities:MortgageFinancialLiabilities = new MortgageFinancialLiabilities();
  mortgageFinancialOtherLaibilities:MortgageFinancialOtherLaibilities = new MortgageFinancialOtherLaibilities()
  financialInfoAssetsLiabilitiesModels:FinancialInfoAssetsLiabilitiesModels = new FinancialInfoAssetsLiabilitiesModels();
  ngOnInit(): void {
    // this.getAllMortgageApplicationAssetandLiability()
  }

  addMortgageFinancialAssets()
  {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.push(new MortgageFinancialAssets())
  }
  removeMortgageFinancialAssets(){
    debugger
    var mortgageFinancialAssetsLength = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.length;
    if(mortgageFinancialAssetsLength == 1)
    {
      return;
    }
    else
    {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.splice(1,mortgageFinancialAssetsLength)
    }
    
  }
  

  
  addMortgageFinancialOtherAssets()
  {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets.push(new MortgageFinancialOtherAssets())
  }
  removeMortgageFinancialOtherAssets(){
    debugger
    var mortgageFinancialOtherAssets = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets.length;
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets.splice(1,mortgageFinancialOtherAssets)
  }


  addMortgageFinancialLiabilities()
  {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.push(new MortgageFinancialLiabilities())
  }
  removeMortgageFinancialLiabilities(){
    debugger
    var mortgageFinancialLiabilitiesLength = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.length;
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.splice(1,mortgageFinancialLiabilitiesLength)
  }


  addMortgageFinancialOtherLaibilities()
  {
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities.push(new MortgageFinancialOtherLaibilities())
  }
  removeMortgageFinancialOtherLaibilities(){
    debugger
    var mortgageFinancialOtherLaibilitiesLength = this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities.length;
    this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities.splice(1,mortgageFinancialOtherLaibilitiesLength)
  }
  submitFinancialAssetsLiabilities()
  {
    debugger
    if(this.flgMortgageFinancialOtherAssets == true)
    {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets = [];
    }
    if(this.flgMortgageFinancialLiabilities == true)
    {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities = [];
    }
    if(this.flgMortgageFinancialOtherLaibilities == true)
    {
      this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherLaibilities = [];
    }
    debugger
    this.financialInfoService.createFinancialInfoAssetsLiabilities(this.financialInfoAssetsLiabilitiesModels).subscribe(data=>{
debugger
    })

  }

  getTotalMortgageFinancialAssets()
  {
    debugger
    
    this.totalMortgageFinancialAssets =this.financialInfoAssetsLiabilitiesModels.mortgageFinancialAssets.reduce((sum, current)=> sum + current.cashMarketValue,0)
  }
  getTotalMortgageFinancialOtherAssets()
  {
    debugger
    this.totalMortgageFinancialOtherAssets =this.financialInfoAssetsLiabilitiesModels.mortgageFinancialOtherAssets.reduce((sum, current)=> sum + current.cashMarketValue,0)
  }
  getTotalMortgageFinancialOtherLaibilities()
  {
    debugger
    this.totalMortgageFinancialOtherLaibilities =this.financialInfoAssetsLiabilitiesModels.mortgageFinancialLiabilities.reduce((sum, current)=> sum + current.monthlyPayment,0)
  }
  getAllMortgageApplicationAssetandLiability(){
    debugger
    var obj={
      Sorting:"",
      SkipCount:0,
      MaxResultCount:10
    }
    debugger
    this.financialInfoService.getAllFinancialInfoAssetsLiabilities(obj).subscribe(data=>{
      debugger
    })
  }
  // nextBtnClick(){
  //   console.log(this.borrowerInfo);
  //   this.borrowService.createMortgageLoanApplication(this.borrowerInfo).subscribe(
  //        (res: any) => {
  //       console.log(res.result);
  //       alert("data has inserted successfully");
  //     }
  //   );
  // }
}
