import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { Address, AlternateNames, BorrowModel, CreditList, Employment, GoogleAddress, GrossMonthlyIncome, IncomeOtherSource, PersonalInformation, Source } from './borrower-model';
import { LoanManagementService } from "@shared/service/loanmanagement.service";
import { BorrowService } from "app/services/borrow.service";
import { Router } from "@angular/router";
import { GooglePlaceDirective } from "ngx-google-places-autocomplete";
import { add } from "lodash";
import { NgForm } from "@angular/forms";
import { elementEventFullName } from "@angular/compiler/src/view_compiler/view_compiler";

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
    debugger
    var removearray=[];
    if(this.borrowerInfo.incomeOtherSources[0].sources.length > 0)
    {
      this.borrowerInfo.incomeOtherSources[0].sources.forEach((element:any,index)=>{
        if(element.flgDeletedRow == true)
        {
          removearray.push(index)
        }
        removearray.sort((a,b)=>{
          return b - a
        })
      })
      removearray.forEach((element:any)=>{
        this.borrowerInfo.incomeOtherSources[0].sources.splice(element,1)
      })
    }
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
    //this.borrowerInfo.personalInformation.yourInitials1 = f.toUpperCase() + l.toUpperCase();
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

  fixDecimals(event: any){
    var vals = event.target.value;
    var int:number = parseInt(vals);
    var dec = vals - int;
    if(dec > 0){
      event.target.value = int + dec;
    }else{
      event.target.value = int + ".00";
    }
  }

  scroll(event: any) {
    //up 38 down 40
    var curBox = event.currentTarget;
    if (event.keyCode === 40) {//down
        var curBox = event.currentTarget;
        var cellNo = event.currentTarget.offsetParent.cellIndex;
        var nextRow = curBox.parentElement.parentElement.nextElementSibling;
        if (nextRow) {
            var nextCell = nextRow.cells[cellNo].lastElementChild;
            //---Select text
            if (nextCell.type == 'number') {
                nextCell.type = 'text';
                nextCell.setSelectionRange(0, nextCell.value.length);
                nextCell.type = 'number';
            } else {
                nextCell.setSelectionRange(0, nextCell.value.length);
            }
            nextCell.focus();
        }

        event.preventDefault();
    } else if (event.keyCode === 38) { //up
        var curBox = event.currentTarget;
        var cellNo = event.currentTarget.offsetParent.cellIndex;
        var prvRow = curBox.parentElement.parentElement.previousElementSibling;
        if (prvRow) {
            var prvCell = prvRow.cells[cellNo].lastElementChild;
            if (prvCell.type == 'number') {
                prvCell.type = 'text';
                prvCell.setSelectionRange(0, prvCell.value.length);
                prvCell.type = 'number';
            } else {
                prvCell.setSelectionRange(0, prvCell.value.length);
            }
            prvCell.focus();
        }
        event.preventDefault();
    }
    else if (event.keyCode === 9) { //---do not enable save button on pressing tab
        return
    } else {
        return;
    }
}

 

  doNotApplyForAddress0F(value:any){
    if(value == true)
    {
      this.borrowerInfo.personalInformation.yourInitials1 = "";
    }
  }
  doNotApplyForaddress1F(value:any){
    if(value == true)
    {
      this.borrowerInfo.personalInformation.address[1].street="";
      this.borrowerInfo.personalInformation.address[1].unit="";
      this.borrowerInfo.personalInformation.address[1].cityId=0
      this.borrowerInfo.personalInformation.address[1].stateId=0;
      this.borrowerInfo.personalInformation.address[1].zip="";
      this.borrowerInfo.personalInformation.address[1].countryId=0;
      this.borrowerInfo.personalInformation.address[1].year = null;
      this.borrowerInfo.personalInformation.address[1].month = "";
      this.borrowerInfo.personalInformation.address[1].housingType ="";
      this.borrowerInfo.personalInformation.address[1].rent =0;
    }
  }
  doNotApplyForaddress2F(value:any){
    if(value == true)
    {
      this.borrowerInfo.personalInformation.address[2].street="";
      this.borrowerInfo.personalInformation.address[2].unit="";
      this.borrowerInfo.personalInformation.address[2].cityId=0
      this.borrowerInfo.personalInformation.address[2].stateId=0;
      this.borrowerInfo.personalInformation.address[2].zip="";
      this.borrowerInfo.personalInformation.address[2].countryId=0;
      this.borrowerInfo.personalInformation.address[2].year = null;
      this.borrowerInfo.personalInformation.address[2].month = "";
      this.borrowerInfo.personalInformation.address[2].housingType ="";
      this.borrowerInfo.personalInformation.address[2].rent =0;
    }
  }
  doNotApplyForEmp0F(value:any){
    if(value == true)
    {
      this.borrowerInfo.employment[0].name="";
      this.borrowerInfo.employment[0].phone="";
      this.borrowerInfo.employment[0].street=""
      this.borrowerInfo.employment[0].cityId=0;
      this.borrowerInfo.employment[0].unit="";
      this.borrowerInfo.employment[0].stateId=0;
      this.borrowerInfo.employment[0].zip = "";
      this.borrowerInfo.employment[0].countryId = 0;
      this.borrowerInfo.employment[0].position = "";
      this.borrowerInfo.employment[0].startDate = "";
      this.borrowerInfo.employment[0].workingYears = 0;
      this.borrowerInfo.employment[0].workingMonths = 0;
      this.borrowerInfo.employment[0].isEmployedBySomeone = false;
      this.borrowerInfo.employment[0].isSelfEmployed= false;
      this.borrowerInfo.employment[0].monthlyIncome = 0;
      this.borrowerInfo.employment[0].grossMonthlyIncome.baseIncome = 0;
      this.borrowerInfo.employment[0].grossMonthlyIncome.overtime = 0;
      this.borrowerInfo.employment[0].grossMonthlyIncome.bonus = 0;
      this.borrowerInfo.employment[0].grossMonthlyIncome.commission = 0;
      this.borrowerInfo.employment[0].grossMonthlyIncome.militaryEntitlements = 0;
      this.borrowerInfo.employment[0].grossMonthlyIncome.other = 0;
      this.borrowerInfo.employment[0].grossMonthlyIncome.total = 0;
      this.borrowerInfo.employment[0].isOwnershipLessThan25= false;
    }
  }
  doNotApplyForEmp1F(value:any){
    if(value == true)
    {
      this.borrowerInfo.employment[1].name="";
      // this.borrowerInfo.employment[0].phone="";
      this.borrowerInfo.employment[1].street=""
      this.borrowerInfo.employment[1].cityId=0;
      this.borrowerInfo.employment[1].unit="";
      this.borrowerInfo.employment[1].stateId=0;
      this.borrowerInfo.employment[1].zip = "";
      this.borrowerInfo.employment[1].countryId = 0;
      this.borrowerInfo.employment[1].position = "";
      this.borrowerInfo.employment[1].startDate = "";
      this.borrowerInfo.employment[1].workingYears = 0;
      this.borrowerInfo.employment[1].workingMonths = 0;
      this.borrowerInfo.employment[1].isEmployedBySomeone = false;
      this.borrowerInfo.employment[1].isSelfEmployed= false;
      this.borrowerInfo.employment[1].isOwnershipLessThan25= false;
      this.borrowerInfo.employment[1].monthlyIncome = 0;
      this.borrowerInfo.employment[1].grossMonthlyIncome.baseIncome = 0;
      this.borrowerInfo.employment[1].grossMonthlyIncome.overtime = 0;
      this.borrowerInfo.employment[1].grossMonthlyIncome.bonus = 0;
      this.borrowerInfo.employment[1].grossMonthlyIncome.commission = 0;
      this.borrowerInfo.employment[1].grossMonthlyIncome.militaryEntitlements = 0;
      this.borrowerInfo.employment[1].grossMonthlyIncome.other = 0;
      this.borrowerInfo.employment[1].grossMonthlyIncome.total = 0;
    }
  }
  doNotApplyForEmp2F(value:any){
    if(value == true)
    {
      this.borrowerInfo.employment[2].name="";
      this.borrowerInfo.employment[2].phone="";
      this.borrowerInfo.employment[2].street=""
      this.borrowerInfo.employment[2].cityId=0;
      this.borrowerInfo.employment[2].unit="";
      this.borrowerInfo.employment[2].stateId=0;
      this.borrowerInfo.employment[2].zip = "";
      this.borrowerInfo.employment[2].countryId = 0;
      this.borrowerInfo.employment[2].position = "";
      this.borrowerInfo.employment[2].startDate = "";
      this.borrowerInfo.employment[2].workingYears = 0;
      this.borrowerInfo.employment[2].workingMonths = 0;
      this.borrowerInfo.employment[2].isEmployedBySomeone = false;
      this.borrowerInfo.employment[2].isSelfEmployed= false;
      this.borrowerInfo.employment[2].isOwnershipLessThan25= false;
      this.borrowerInfo.employment[2].monthlyIncome = 0;
      this.borrowerInfo.employment[2].grossMonthlyIncome.baseIncome = 0;
      this.borrowerInfo.employment[2].grossMonthlyIncome.overtime = 0;
      this.borrowerInfo.employment[2].grossMonthlyIncome.bonus = 0;
      this.borrowerInfo.employment[2].grossMonthlyIncome.commission = 0;
      this.borrowerInfo.employment[2].grossMonthlyIncome.militaryEntitlements = 0;
      this.borrowerInfo.employment[2].grossMonthlyIncome.other = 0;
      this.borrowerInfo.employment[2].grossMonthlyIncome.total = 0;
    }
  }
  incomeFromOtherSourcesF(event:any){
    if(event == true){
       this.borrowerInfo.incomeOtherSources[0].sources=[];
    }
  }
  
  onKeydown(event: any, selectedDate:any ){
    let sDate:Date = new Date(selectedDate);
    console.log(sDate.getFullYear());
    const years = sDate.getFullYear();
    if(years <= 1900){
      
    }
  }

  onBlurDt(event: any){
    var sDate = new Date(event.target.value);
    var currentDate = new Date();
    if(sDate.getFullYear() <1900 || sDate.getDate() > currentDate.getDate() || this.isValidDate(sDate.getFullYear(), sDate.getMonth(), sDate.getDay())==false){
      event.target.value = currentDate.getDate().toString();
    }else{}

    if(Number.isNaN(sDate.getDate())){
      event.target.value = "";
    }
  }

  isValidDate(year, month, day) {
    var d = new Date(year, month, day);
    if (d.getFullYear() == year && d.getMonth() == month && d.getDate() == day) {
        return true;
    }
    return false;
}

  onSearchChange(searchValue: string) {

  }

}

