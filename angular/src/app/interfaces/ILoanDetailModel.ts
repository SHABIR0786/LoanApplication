export interface ILoanDetailModel {
    id?: number;
    referredBy?: string;
    purposeOfLoan?: number;
    estimatedValue?: number;
    currentLoanAmount?: number;
    requestedLoanAmount?: number;
    estimatedPurchasePrice?: number;
    downPaymentAmount?: number;
    downPaymentPercentage?: number;
    sourceOfDownPayment?: number;

    refinancingCurrentHome?: boolean;
    yearAcquired?: string;
    originalPrice?: number;
    city?: string;
    stateId?: number;
    propertyTypeId?: number;
    propertyUseId?: number;
}
