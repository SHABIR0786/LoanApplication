import {ILoanDetailModel} from './ILoanDetailModel';
import {IPersonalDetailModel} from './IPersonalDetailModel';
import {IAdditionalDetailModel} from './IAdditionalDetailModel';
import {IConsentDetailModel} from './IConsentDetailModel';
import {ICreditAuthAgreementModel} from './ICreditAuthAgreementModel';

export interface ILoanApplicationModel {
    loanDetails?: ILoanDetailModel;
    personalInformation?: IPersonalDetailModel;
    orderCredit?: ICreditAuthAgreementModel;
    additionalDetails?: IAdditionalDetailModel;
    eConsent?: IConsentDetailModel;
}
