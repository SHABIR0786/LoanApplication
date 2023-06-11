export class FinancialInfoRealEstate {
financialInformationType: string='';
personalInformationId: number=0;
street: string='';
unit: string='';
cityId:  number=0;
stateId:  number=0;
countryId:  number=0;
zip:string='';
propertyValue:  number=0;
intendedOccupancy: string='';
monthlyInsurance:  number=0;
monthlyRentalIncome:  number=0;
netMonthlyRentalIncome:  number=0;
flgMortgageLoanNotApply:boolean=false;
flgApplicableNotApply:boolean=false;
flgMortgageLoan2NotApply:boolean=false;
mortgageLoanOnProperty: MortgageLoanOnProperty[]=[new MortgageLoanOnProperty()]

}
export class MortgageLoanOnProperty{
    creditorName: string='';
    accountNumber: string='';
    monthlyMortagagePayment: number=0;
    unpaidBalance: number=0;
    type: string='';
    creditLimit: number=0;
    isPaidBeforeClosing: boolean=false;
}
