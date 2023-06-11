export class LoanPropertyInfoModels {
    loanPropertyInfo:LoanPropertyInfo= new LoanPropertyInfo();
    newMortgageLoans:NewMortgageLoans[]=[new NewMortgageLoans()];
    rentalIncome : RentalIncome = new RentalIncome();
    giftsOrGrants:GiftsOrGrants[] = [new GiftsOrGrants()];
}
export class LoanPropertyInfo{
    personalInformationId: number =0;
    loanAmount:  number =0;
    loanPurpose: string='';
    occupancy: string='';
    isManufacturedHome: boolean=false;
    isMixedUseProperty: boolean=false;
    propertyAddress:PropertyAddress = new PropertyAddress()
}
export class PropertyAddress{
    personalInformationId:  number =0;
    street: string='';
    cityId:  number =0;
    stateId:  number =0;
    countryId:  number =0;
    zip:  number =0;
    numberOfUnits:  number =0;
        
}
export class NewMortgageLoans{
    personalInformationId:  number =0;
    creditorName: string='';
    lienType: string='';
    monthlyPayment:  number =0;
    loanAmount:  number =0;
    creditLimit:  number =0;
}
export class RentalIncome{
    personalInformationId:  number =0;
    monthlyRentalIncome:  number =0;
    netMonthlyRentalIncome:  number =0;
}
export class  GiftsOrGrants{
    personalInformationId:  number =0;
    assetTypeId:  number =0;
    isDeposited:  boolean=false;
    source: string='';
    marketValue:  number =0;
}
  