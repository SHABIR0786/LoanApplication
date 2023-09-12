import { Component, OnInit } from "@angular/core";
import { LoanPropertyInfoModels, NewMortgageLoans, GiftsOrGrants, RentalIncome } from "./loan-property-info-models"
import { LoanPropertyInfoService } from "./loan-property-info.service"
import { Router } from "@angular/router";
import { GoogleAddress } from "../borrower-info/borrower-model";
@Component({
  selector: "app-loan-property-info",
  templateUrl: "./loan-property-info.component.html",
  styleUrls: ["./loan-property-info.component.css"],
})
export class LoanPropertyInfoComponent implements OnInit {
  flgOtherNewMortgageLoans: boolean = false;
  flgRentalIncome: boolean = false;
  flgGiftsorGrants: boolean = false;
  rentalIncomeModel: RentalIncome = new RentalIncome()
  loanPropertyInfoModel: LoanPropertyInfoModels = new LoanPropertyInfoModels()
  cityList: any[] = [];
  countryList: any[] = [];
  stateList: any[] = [];
  giftTypeList: any[] = [];
  removeOtherNewMortgageLoansIndex:any[]=[]
  removeGiftsorGrantsIndex:any[]=[]

  options: any = {
    componentRestrictions: { country: 'US' }
  }

  constructor(private loanPropertyInfoService: LoanPropertyInfoService, private router: Router) { }

  ngOnInit(): void {

    this.getCities();
    this.getCountries();
    this.getStates();
    if (localStorage.flgOtherNewMortgageLoans != undefined && localStorage.flgOtherNewMortgageLoans != '') {
      this.flgOtherNewMortgageLoans = JSON.parse(localStorage.getItem('flgOtherNewMortgageLoans'));
    }
    if (localStorage.flgGiftsorGrants != undefined && localStorage.flgGiftsorGrants != '') {
      this.flgGiftsorGrants = JSON.parse(localStorage.getItem('flgGiftsorGrants'));
    }
    if (localStorage.flgRentalIncome != undefined && localStorage.flgRentalIncome != '') {
      this.flgRentalIncome = JSON.parse(localStorage.getItem('flgRentalIncome'));
    }
    if (localStorage.loanPropertyInfoModel != undefined && localStorage.loanPropertyInfoModel != '') {
      this.loanPropertyInfoModel = JSON.parse(localStorage.getItem('loanPropertyInfoModel'));
    }
    if (this.loanPropertyInfoModel.rentalIncome == null) {
      this.loanPropertyInfoModel.rentalIncome = new RentalIncome();
    }
    if (this.loanPropertyInfoModel.giftsOrGrants.length == 0) {
      this.loanPropertyInfoModel.giftsOrGrants.push(new GiftsOrGrants())
    }
    if (this.loanPropertyInfoModel.newMortgageLoans.length == 0) {
      this.loanPropertyInfoModel.newMortgageLoans.push(new NewMortgageLoans());
    }
    //----Get Gift Types
    this.loanPropertyInfoService.getLoanPropertyGiftTypes().subscribe((data: any) => {
      this.countryList = []
      if (data.success == true && data.result.length > 0) {
        data.result.forEach((element: any) => {
          this.giftTypeList.push({ loanPropertyGiftType1: element.loanPropertyGiftType1, id: element.id })
        })
      }
    })
  }
  getCountries() {

    this.loanPropertyInfoService.getCountries().subscribe((data: any) => {

      this.countryList = []
      if (data.success == true && data.result.length > 0) {
        data.result.forEach((element: any) => {

          this.countryList.push({ countryName: element.countryName, id: element.id })
        })
      }
    })
  }
  getStates() {

    this.loanPropertyInfoService.getStates().subscribe((data: any) => {

      this.stateList = []
      if (data.success == true && data.result.length > 0) {
        data.result.forEach((element: any) => {

          this.stateList.push({ stateName: element.stateName, id: element.id })
        })
      }
    })
  }
  getCities() {
    this.loanPropertyInfoService.getCities().subscribe((data: any) => {

      this.cityList = []
      if (data.success == true && data.result.length > 0) {
        data.result.forEach((element: any) => {

          this.cityList.push({ cityName: element.cityName, id: element.id })
        })
      }
    })
  }
  addMortgageLoanList() {

    this.loanPropertyInfoModel.newMortgageLoans.push(new NewMortgageLoans())
  }
  removeMortgageLoanList() {

    var mortgageFinancialLength = this.loanPropertyInfoModel.newMortgageLoans.length;
    // if (mortgageFinancialLength == 1) {
    //   return;
    // }
    if(mortgageFinancialLength > 0)
    {
      this.removeOtherNewMortgageLoansIndex.sort((a,b)=>{
        return b-a;
      })
      this.removeOtherNewMortgageLoansIndex.forEach((element:any)=>{
        this.loanPropertyInfoModel.newMortgageLoans.splice(element,1)
      })
      this.removeOtherNewMortgageLoansIndex=[]
    }

  }
  addGiftsOrGrants() {

    this.loanPropertyInfoModel.giftsOrGrants.push(new GiftsOrGrants())
  }
  removeGiftsOrGrants() {
    var mortgageFinancialLength = this.loanPropertyInfoModel.giftsOrGrants.length;
    if(mortgageFinancialLength > 0)
    {
      this.removeGiftsorGrantsIndex.sort((a,b)=>{
        return b-a;
      })
      this.removeGiftsorGrantsIndex.forEach((element:any)=>{
        this.loanPropertyInfoModel.giftsOrGrants.splice(element,1)
      })
      this.removeGiftsorGrantsIndex=[]
    }

  }


  create() {
    debugger
    if (this.flgOtherNewMortgageLoans == true) {
      this.loanPropertyInfoModel.newMortgageLoans = [];
    }
    if (this.flgRentalIncome == true) {
      this.loanPropertyInfoModel.rentalIncome = null;
    }
    if (this.flgGiftsorGrants == true) {
      this.loanPropertyInfoModel.giftsOrGrants = [];
    }
    var obj = this.loanPropertyInfoModel;
    localStorage.removeItem("loanPropertyInfoModel")
    localStorage.removeItem("flgOtherNewMortgageLoans")
    localStorage.removeItem("flgRentalIncome")
    localStorage.removeItem("flgGiftsorGrants")
    localStorage.setItem("loanPropertyInfoModel", JSON.stringify(obj))
    localStorage.setItem("flgOtherNewMortgageLoans", JSON.stringify(this.flgOtherNewMortgageLoans))
    localStorage.setItem("flgRentalIncome", JSON.stringify(this.flgRentalIncome))
    localStorage.setItem("flgGiftsorGrants", JSON.stringify(this.flgGiftsorGrants))
    this.loanPropertyInfoService.create(obj).subscribe((data: any) => {
      if (data.success == true) {
        alert("Data inserted successfully");
        this.router.navigateByUrl('app/admin/incomplete-loan-application/declarations');
      }
    })
  }



  public handleAddressChange(place: google.maps.places.Place, fldIndex: number) {

    let COMPONENT_TEMPLATE: any;
    let Address_01: GoogleAddress = new GoogleAddress();

    COMPONENT_TEMPLATE = { street_number: 'short_name' };
    Address_01.addressLine1 = this.getAddrComponent(place, COMPONENT_TEMPLATE);

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


    const cityID = this.cityList.find(city => city.cityName === Address_01.city);
    this.loanPropertyInfoModel.loanPropertyInfo.propertyAddress.cityId = cityID.id;

    const stateID = this.stateList.find(state => state.stateName === Address_01.state);
    const CountryID = this.countryList.find(country => country.countryName === Address_01.countryShort);
    this.loanPropertyInfoModel.loanPropertyInfo.propertyAddress.street = Address_01.addressLine1 + " " + Address_01.addressLine2;
    this.loanPropertyInfoModel.loanPropertyInfo.propertyAddress.zip = Address_01.postalCode;
    //this.loanPropertyInfoModel.loanPropertyInfo.propertyAddress.cityId = this.cityList.find(city => city.cityName === Address_01.city);
    this.loanPropertyInfoModel.loanPropertyInfo.propertyAddress.stateId = stateID.id;
    this.loanPropertyInfoModel.loanPropertyInfo.propertyAddress.countryId = CountryID.id;
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
  flgOtherNewMortgageLoansF(event: any) {
    if (event == true) {
      this.loanPropertyInfoModel.newMortgageLoans = []
    }

  }
  removeOtherNewMortgageLoansF(index:any,event:any){
    debugger
    if(event.target.checked == true){
      this.removeOtherNewMortgageLoansIndex.push(index)
    }
    else
    {
      var remove =this.removeOtherNewMortgageLoansIndex.findIndex((s:any)=>s == index)
      this.removeOtherNewMortgageLoansIndex.splice(remove,1)
    }
   
  }
  flgRentalIncomeF(event: any) {
    if (event == true) {
      this.loanPropertyInfoModel.rentalIncome =new RentalIncome()
    }

  }
  flgGiftsorGrantsF(event: any) {
    if (event == true) {
      this.loanPropertyInfoModel.giftsOrGrants =[]
    }

  }
  removeGiftsorGrantsF(index:any,event:any){
    debugger
    if(event.target.checked == true){
      this.removeGiftsorGrantsIndex.push(index)
    }
    else
    {
      var remove =this.removeGiftsorGrantsIndex.findIndex((s:any)=>s == index)
      this.removeGiftsorGrantsIndex.splice(remove,1)
    }
   
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

}
