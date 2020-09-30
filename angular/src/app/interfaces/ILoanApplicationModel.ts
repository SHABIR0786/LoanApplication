import {ILoanDetailModel} from './ILoanDetailModel';
import {IPersonalDetailModel} from './IPersonalDetailModel';
import {IAdditionalDetailModel} from './IAdditionalDetailModel';
import {IConsentDetailModel} from './IConsentDetailModel';
import {ICreditAuthAgreementModel} from './ICreditAuthAgreementModel';
import {IExpenseModel} from './IExpenseModel';
import {IEmploymentIncomeModel} from './IEmploymentIncomeModel';
import {IDeclarationModel} from './IDeclarationModel';
import { IDeclarationBorrowereDemographicsInformationModel } from './IDeclarationBorrowereDemographicsInformationModel';

export interface ILoanApplicationModel {
    additionalDetails?: IAdditionalDetailModel;
    loanDetails?: ILoanDetailModel;
    personalDetail?: IPersonalDetailModel;
    expenses?: IExpenseModel;
    employmentIncome?: IEmploymentIncomeModel;
    orderCredit?: ICreditAuthAgreementModel;   
    eConsent?: IConsentDetailModel;
    declaration?: IDeclarationModel;
    IDeclarationBorrowereDemographicsInformationModel? : IDeclarationBorrowereDemographicsInformationModel;
}
