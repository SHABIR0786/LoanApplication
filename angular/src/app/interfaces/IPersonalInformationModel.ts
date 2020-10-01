import {IBorrowerModel} from './IBorrowerModel';

export interface IPersonalInformationModel {
    id?: number;
    isApplyingWithCoBorrower?: boolean;
    useIncomeOfPersonOtherThanBorrower?: boolean;
    agreePrivacyPolicy?: boolean;
    borrower?: IBorrowerModel;
    coBorrower?: IBorrowerModel;
}
