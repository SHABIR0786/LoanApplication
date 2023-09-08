import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { Address, AlternateNames, BorrowModel, CreditList, Employment, GoogleAddress, GrossMonthlyIncome, IncomeOtherSource, PersonalInformation, Source } from './borrower-model';
import { LoanManagementService } from "@shared/service/loanmanagement.service";
import { BorrowService } from "app/services/borrow.service";
import { Router } from "@angular/router";
import { GooglePlaceDirective } from "ngx-google-places-autocomplete";
import { add } from "lodash";
import { NgForm } from "@angular/forms";

``
@Component({
  selector: "app-borrower-info",
  templateUrl: "./borrower-info.component.html",
  styleUrls: ["./borrower-info.component.css"],
})
export class BorrowerInfoComponent implements OnInit {

  @ViewChild("creditItemsStreet") placesRef : GooglePlaceDirective;
  @ViewChild("street1") street1 : GooglePlaceDirective;


  options: any = {
    componentRestrictions: { country: 'US' }
  }
  
  borrowerInfo: BorrowModel = new BorrowModel();
  doNotApplyForAddress0: boolean = false;
  doNotApplyForaddress1: boolean = false;
  doNotApplyForaddress2: boolean = false;
  doNotApplyForEmp0: boolean = false;
  doNotApplyForEmp1: boolean = false;
  doNotApplyForEmp2: boolean = false;
  incomeFromOtherSources: boolean = false;
  yearList:any[]=[];
  monthList:any[]=[];
  browerList:any[]=[];
  countryList: any[] = [];
  stateList: any[] = [];
  cityList: any[] = [];
  citizenshipType:any[]=[];
  maritalStatusList:any[]=[];
  incomeTypeList:any[]=[];
  currentDate:Date = new Date();
  BorrowerName:any;

  constructor(private loanManagmentService: LoanManagementService, private borrowService: BorrowService, private router: Router) {
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
    this.borrowerInfo.incomeOtherSources = [];
    this.borrowerInfo.incomeOtherSources.push(new IncomeOtherSource());
    // this.borrowerInfo.incomeOtherSources.push(new IncomeOtherSource());
    // this.borrowerInfo.incomeOtherSources.push(new IncomeOtherSource());
    this.borrowerInfo.incomeOtherSources[0].sources = [];
    this.borrowerInfo.incomeOtherSources[0].sources.push(new Source());
    //this.bindValues();
  }

  ngOnInit(): void {    
    this.monthYearList();
    this.getCountries();
    this.getStates();
    this.getCities()
    this.creditClick();
    this.borrowerInfo.personalInformation.address[0] = new Address();
    this.borrowService.getAllCitizenshipType().subscribe(
      (res: any) => {
        console.log(res.result);
        this.citizenshipType = []
        if (res.success == true && res.result.length > 0) {
          res.result.forEach((element: any) => {
          this.citizenshipType.push({ citizenshipType1: element.citizenshipType1, id: element.id })
        })
      }
        //this.Custom = res.result.items;
      }
    );

    
    //---Get Marital Statuses
    this.borrowService.getAllMaritalStatus().subscribe(
      (res:any)=>{
        this.maritalStatusList=[];
        if(res.success ==true && res.result.length>0){
          res.result.forEach((element:any)=>{
            this.maritalStatusList.push({maritialStatus1:element.maritialStatus1, id:element.id})
          })
        }
      }
    )
    //--- Get IncomeType
    this.borrowService.getIncomeTypes().subscribe(
      (res:any)=>{
        this.incomeTypeList=[];
        if(res.success ==true && res.result.length>0){
          res.result.forEach((element:any)=>{
            this.incomeTypeList.push({incomeType:element.incomeType, id:element.id})
          })
        }
      }
    )
    if (localStorage.borrowerInfo != undefined && localStorage.borrowerInfo != '') {
      this.borrowerInfo = JSON.parse(localStorage.getItem('borrowerInfo'));
    }
    if(localStorage.doNotApplyForaddress1 != undefined)
    {
      this.doNotApplyForaddress1 = JSON.parse(localStorage.getItem('doNotApplyForaddress1'));
    }
    if(localStorage.doNotApplyForaddress2 != undefined)
    {
      this.doNotApplyForaddress2 = JSON.parse(localStorage.getItem('doNotApplyForaddress2'));
    }
    if(localStorage.doNotApplyForEmp0 != undefined)
    {
      this.doNotApplyForEmp0 = JSON.parse(localStorage.getItem('doNotApplyForEmp0'));
    }
    if(localStorage.doNotApplyForEmp1 != undefined)
    {
      this.doNotApplyForEmp1 = JSON.parse(localStorage.getItem('doNotApplyForEmp1'));
    }
    if(localStorage.doNotApplyForEmp2 != undefined)
    {
      this.doNotApplyForEmp2 = JSON.parse(localStorage.getItem('doNotApplyForEmp2'));
    }
    if(localStorage.doNotApplyForAddress0 != undefined)
    {
      this.doNotApplyForAddress0 = JSON.parse(localStorage.getItem('doNotApplyForAddress0'));
    }
    if(localStorage.incomeFromOtherSources != undefined)
    {
      this.incomeFromOtherSources = JSON.parse(localStorage.getItem('incomeFromOtherSources'));
    }
  }
  monthYearList()
  {
    this.yearList = [];
    this.monthList=[];
    this.browerList=[];
    for(var i= 1 ; i<=100 ; i = i + 1)
    {
      this.yearList.push({id:i,label:i});
    } 
    for(var i= 1 ; i<=12 ; i = i + 1)
    {
      this.monthList.push({id:i,label:i});
    }
    for(var i= 2 ; i<=12 ; i = i + 1)
    {
      this.browerList.push({id:i,label:i});
    }
    this.borrowerInfo.personalInformation.totalBorrowers=2
    // this.borrowerInfo.personalInformation.creditValue = "2";
    
  }
  creditClick() {
   debugger
    if (this.borrowerInfo.personalInformation.creditValue == "1") {
      this.borrowerInfo.personalInformation.totalBorrowers = 2;
    }

    this.borrowerInfo.personalInformation.creditList = [];
    for (var i = 0; i < this.borrowerInfo.personalInformation.totalBorrowers -1; i++) {
      this.borrowerInfo.personalInformation.creditList.push(new CreditList());
    }
  }
  addMoreIncomeSource() {
    this.borrowerInfo.incomeOtherSources[0].sources.push(new Source());
  }
  delMoreIncomeSource() {
    this.borrowerInfo.incomeOtherSources[0].sources.splice(-1);
  }
  
  nextBtnClick() {
    if (this.doNotApplyForaddress1) {
      this.borrowerInfo.personalInformation.address[1] = new Address();
    }
    if (this.doNotApplyForaddress2) {
      this.borrowerInfo.personalInformation.address[2] = new Address();
    }
    if (this.doNotApplyForEmp0) {
      this.borrowerInfo.employment[0]=new Employment();
      this.borrowerInfo.employment[0].grossMonthlyIncome = new GrossMonthlyIncome();
    }
    if (this.doNotApplyForEmp1) {
      this.borrowerInfo.employment[1]=new Employment();
      this.borrowerInfo.employment[1].grossMonthlyIncome = new GrossMonthlyIncome();
    }
    
    if (this.doNotApplyForEmp2) {
      this.borrowerInfo.employment[2]=new Employment();
      this.borrowerInfo.employment[2].grossMonthlyIncome = new GrossMonthlyIncome();
    }
   
    localStorage.setItem("borrowerInfo", JSON.stringify(this.borrowerInfo))
    localStorage.setItem("doNotApplyForaddress1", JSON.stringify(this.doNotApplyForaddress1))
    localStorage.setItem("doNotApplyForaddress2", JSON.stringify(this.doNotApplyForaddress2))
    localStorage.setItem("doNotApplyForEmp0", JSON.stringify(this.doNotApplyForEmp0))
    localStorage.setItem("doNotApplyForEmp1", JSON.stringify(this.doNotApplyForEmp1))
    localStorage.setItem("doNotApplyForEmp2", JSON.stringify(this.doNotApplyForEmp2))
    localStorage.setItem("doNotApplyForAddress0", JSON.stringify(this.doNotApplyForAddress0))
    localStorage.setItem("incomeFromOtherSources", JSON.stringify(this.incomeFromOtherSources))
    this.borrowService.createMortgageLoanApplication(this.borrowerInfo).subscribe(
      (res: any) => {
        if(res.success == true)
        {
          alert("Data has inserted successfully");
          //this.router.navigateByUrl('app/admin/incomplete-loan-application/financial-info-assets-liabilities');
        }
      
      }
    );
  }

  // nextBtnClick(ngForm:NgForm) {
  //   if (this.doNotApplyForaddress1) {
  //     this.borrowerInfo.personalInformation.address[1] = new Address();
  //   }
  //   if (this.doNotApplyForaddress2) {
  //     this.borrowerInfo.personalInformation.address[2] = new Address();
  //   }
  //   if (this.doNotApplyForEmp0) {
  //     this.borrowerInfo.employment[0] = new Employment();
  //   }
  //   if (this.doNotApplyForEmp1) {
  //     this.borrowerInfo.employment[1] = new Employment();
  //   }
  //   if (this.doNotApplyForEmp2) {
  //     this.borrowerInfo.employment[2] = new Employment();
  //   }
    
  //   localStorage.setItem("borrowerInfo", JSON.stringify(this.borrowerInfo))
  //   localStorage.setItem("doNotApplyForaddress1", JSON.stringify(this.doNotApplyForaddress1))
  //   localStorage.setItem("doNotApplyForaddress2", JSON.stringify(this.doNotApplyForaddress2))
  //   localStorage.setItem("doNotApplyForEmp0", JSON.stringify(this.doNotApplyForEmp0))
  //   localStorage.setItem("doNotApplyForEmp1", JSON.stringify(this.doNotApplyForEmp1))
  //   localStorage.setItem("doNotApplyForEmp2", JSON.stringify(this.doNotApplyForEmp2))
  //   localStorage.setItem("doNotApplyForAddress0", JSON.stringify(this.doNotApplyForAddress0))
  //   localStorage.setItem("incomeFromOtherSources", JSON.stringify(this.incomeFromOtherSources))
  //   this.borrowService.createMortgageLoanApplication(this.borrowerInfo).subscribe(
  //     (res: any) => {
  //       if(res.success == true)
  //       {
  //         alert("Data has inserted successfully");
  //         this.router.navigateByUrl('app/admin/incomplete-loan-application/financial-info-assets-liabilities');
  //       }
      
  //     }
  //   );
  // }

  getCountries() {
    this.borrowService.getCountries().subscribe((data: any) => {
      this.countryList = []
      if (data.success == true && data.result.length > 0) {
        data.result.forEach((element: any) => {
          this.countryList.push({ countryName: element.countryName, id: element.id })
        })
      }
    })
  }

  // getCountries() {
  //   this.borrowService.getCountries().subscribe((data: any) => {
  //     this.countryList = []
  //     if (data.success == true && data.result.length > 0) {
  //       data.result.forEach((element: any) => {
  //         this.countryList.push({ countryName: element.countryName, id: element.id })
  //       })
  //     }
  //   })
  // }
  getStates() {
    this.borrowService.getStates().subscribe((data: any) => {
      this.stateList = []
      if (data.success == true && data.result.length > 0) {
        data.result.forEach((element: any) => {
          this.stateList.push({ stateName: element.stateName, id: element.id })
        })
      }
    })
  }
  getCities() {
    
    this.borrowService.getCities().subscribe((data: any) => {
      
      this.cityList = []
      if (data.success == true && data.result.length > 0) {
        data.result.forEach((element: any) => {
          
          this.cityList.push({ cityName: element.cityName, id: element.id })
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
  getInitials(){
    var f = this.borrowerInfo.personalInformation.firstName.charAt(0)
    var l = this.borrowerInfo.personalInformation.lastName.charAt(0)
    this.borrowerInfo.personalInformation.yourInitials = f.toUpperCase() + l.toUpperCase()
  }

  public handleAddressChange(place: google.maps.places.Place, fldIndex:number) {
   
     let COMPONENT_TEMPLATE :any;
     let Address_01: GoogleAddress = new GoogleAddress(); 

    COMPONENT_TEMPLATE = { street_number: 'short_name' }; 
    Address_01.addressLine1 = this.getAddrComponent(place,COMPONENT_TEMPLATE);

    COMPONENT_TEMPLATE = { route: 'long_name' }; //street
    Address_01.addressLine2 = this.getAddrComponent(place, COMPONENT_TEMPLATE);

    COMPONENT_TEMPLATE = { locality: 'long_name' };
    Address_01.city = this.getAddrComponent(place, COMPONENT_TEMPLATE);

    COMPONENT_TEMPLATE = { administrative_area_level_1: 'short_name' },
    Address_01.state = this.getAddrComponent(place, COMPONENT_TEMPLATE);

    COMPONENT_TEMPLATE = { country: 'long_name' },
    Address_01.countryShort = this.getAddrComponent(place, COMPONENT_TEMPLATE);

    COMPONENT_TEMPLATE = { postal_code: 'long_name' },
    Address_01.postalCode = this.getAddrComponent(place, COMPONENT_TEMPLATE);

    console.log(Address_01);


    const stateID = this.stateList.find(state => state.stateName === Address_01.state);
    const CountryID = this.countryList.find(country => country.countryName === Address_01.countryShort);

    this.borrowerInfo.personalInformation.address[fldIndex].street = Address_01.addressLine1 + " " +  Address_01.addressLine2  ;
    this.borrowerInfo.personalInformation.address[fldIndex].zip = Address_01.postalCode;
    this.borrowerInfo.personalInformation.address[fldIndex].stateId = stateID.id;
    this.borrowerInfo.personalInformation.address[fldIndex].countryId = CountryID.id;

    
    const cityID = this.cityList.find(city => city.cityName === Address_01.city);
    this.borrowerInfo.personalInformation.address[fldIndex].cityId = cityID.id;


  }


  handleEmploymentChange(place: google.maps.places.Place, fldIndex:number) {
   
    let COMPONENT_TEMPLATE :any;
    let Address_01: GoogleAddress = new GoogleAddress(); 

   COMPONENT_TEMPLATE = { street_number: 'short_name' }; 
   Address_01.addressLine1 = this.getAddrComponent(place,COMPONENT_TEMPLATE);

   COMPONENT_TEMPLATE = { route: 'long_name' }; //street
   Address_01.addressLine2 = this.getAddrComponent(place, COMPONENT_TEMPLATE);

   COMPONENT_TEMPLATE = { locality: 'long_name' };
   Address_01.city = this.getAddrComponent(place, COMPONENT_TEMPLATE);

   COMPONENT_TEMPLATE = { administrative_area_level_1: 'short_name' },
   Address_01.state = this.getAddrComponent(place, COMPONENT_TEMPLATE);

   COMPONENT_TEMPLATE = { country: 'long_name' },
   Address_01.countryShort = this.getAddrComponent(place, COMPONENT_TEMPLATE);

   COMPONENT_TEMPLATE = { postal_code: 'long_name' },
   Address_01.postalCode = this.getAddrComponent(place, COMPONENT_TEMPLATE);

   const stateID = this.stateList.find(state => state.stateName === Address_01.state);
   const CountryID = this.countryList.find(country => country.countryName === Address_01.countryShort);

   this.borrowerInfo.employment[fldIndex].street = Address_01.addressLine1 + " " +  Address_01.addressLine2  ;
   this.borrowerInfo.employment[fldIndex].zip = Address_01.postalCode;
   this.borrowerInfo.employment[fldIndex].cityId = this.cityList.find(city => city.cityName === Address_01.city);
   this.borrowerInfo.employment[fldIndex].stateId = stateID.id;
   this.borrowerInfo.employment[fldIndex].countryId = CountryID.id;

   const cityID = this.cityList.find(city => city.cityName === Address_01.city);
   this.borrowerInfo.employment[fldIndex].cityId = cityID.id;

   
 }

  getAddrComponent(place, componentTemplate) {
    let result;
  
    for (let i = 0; i < place.address_components.length; i++) {
      const addressType = place.address_components[i].types[0];
      if (componentTemplate[addressType]) {
        result = place.address_components[i][componentTemplate[addressType]];        
        return result;
      }
    }
    return;
  }

  selectNumber(event){
    event.target.select();
  }

}

