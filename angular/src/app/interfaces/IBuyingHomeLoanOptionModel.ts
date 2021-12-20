export interface IBuyingHomeLoanOptionModel {
  id?: number;
  PropertyUse?: string;
  propertyType?: string;
  zipCode?: string;
  FirstTimeHomeBuying?: boolean;
  planToPurchase?: string;
  propertyLocated?: string;
  purchasePrice?: number;
  downPayment?: number;
  downPaymentPercent?: number;
  currentEmployed?: string;
  houseHoldIncome?: string;
  proofOfincome?: boolean;
  militarySevice?: boolean;
  bankruptcyPastThreeYears?: boolean;
  foreclosurePastTwoYears?: boolean;
  LateMortgagePayments?: string;
  rateCredit?: string;
  firstName?: string;
  lastName?: string;
  emailAddress?: string;
  phoneNumber?: string;
  refferedBy?: string;
}
