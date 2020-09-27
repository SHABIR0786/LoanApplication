import {IBorrowerModel} from './IBorrowerModel';

export interface IPersonalDetailModel {
    id?: number;
    isApplyingWithCoBorrower?: boolean;
    useIncomeOfPersonOtherThanBorrower?: boolean;
    borrower?: IBorrowerModel;
    coBorrower?: IBorrowerModel;
}
