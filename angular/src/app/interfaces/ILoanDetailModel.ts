export interface ILoanDetailModel {
        id?: number;
    isWorkingWithOfficer?: boolean;
    loanOfficerId?: number;
    referredBy?: string;
    purposeOfLoan?: number;
    estimatedValue?: number;
    currentLoanAmount?: number;
    requestedLoanAmount?: number;
    estimatedPurchasePrice?: number;
    downPaymentAmount?: number;
    downPaymentPercentage?: number;
    sourceOfDownPayment?: number;
    giftAmount?: number;
    giftExplanation?: string;

    haveSecondMortgage?: boolean;
    secondMortgageAmount?: number;
    payLoanWithNewLoan?: boolean;

    startedLookingForNewHome?: boolean;
    refinancingCurrentHome?: boolean;
    yearAcquired?: string;
    originalPrice?: number;
    city?: string;
    stateId?: number;
    propertyTypeId?: number;
    propertyUseId?: number;

    loanOfficerName?: string;
    loanPurpose?: string;
    sourceOfDownPaymentName?: string;
    stateIdName?: string;
    propertyUseName?: string;
    propertyTypeName?: string;

}
