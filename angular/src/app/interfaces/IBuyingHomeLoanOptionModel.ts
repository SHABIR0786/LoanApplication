export interface IBuyingHomeLoanOptionModel {
  id?: number;
  PropertyUse?: string;
  propertyType?: string;
  zipCode?: string;
  howLongPlan?: string;
  downPayment?: number;
  downPaymentPercent?: number;
  FirstTimeHomeBuying?: boolean;
  militarySevice?: boolean;
  important_to_you?: string;
  rateCredit?: string;
  workingWithLoanOfficer?: boolean;

  planToPurchase?: string;
  propertyLocated?: string;
  purchasePrice?: number;

  currentEmployed?: string;
  houseHoldIncome?: string;
  proofOfincome?: boolean;
  bankruptcyPastThreeYears?: boolean;
  foreclosurePastTwoYears?: boolean;
  LateMortgagePayments?: string;
  firstName?: string;
  lastName?: string;
  emailAddress?: string;
  phoneNumber?: string;
  refferedBy?: string;
}
