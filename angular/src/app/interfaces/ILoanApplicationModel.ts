import {ILoanDetailModel} from './ILoanDetailModel';
import {IPersonalDetailModel} from './IPersonalDetailModel';
import {IAdditionalDetailModel} from './IAdditionalDetailModel';
import {IConsentDetailModel} from './IConsentDetailModel';
import {ICreditAuthAgreementModel} from './ICreditAuthAgreementModel';
import {IExpenseModel} from './IExpenseModel';
import {IEmploymentIncomeModel} from './IEmploymentIncomeModel';

export interface ILoanApplicationModel {
    loanDetails?: ILoanDetailModel;
    personalInformation?: IPersonalDetailModel;
    expenses?: IExpenseModel;
    employmentIncome?: IEmploymentIncomeModel;
    orderCredit?: ICreditAuthAgreementModel;
    additionalDetails?: IAdditionalDetailModel;
    eConsent?: IConsentDetailModel;
}
