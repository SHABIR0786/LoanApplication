import {IBorrowerModel} from './IBorrowerModel';

export interface IPersonalDetailModel {
    id?: number;
    isApplyingWithCoBorrower?: boolean;
    useIncomeOfPersonOtherThanBorrower?: boolean;
    agreePrivacyPolicy?: boolean;
    borrower?: IBorrowerModel;
    coBorrower?: IBorrowerModel;
}
