import {ILoanDetailModel} from './ILoanDetailModel';
import {IPersonalDetailModel} from './IPersonalDetailModel';

export interface ILoanApplicationModel {
    loanDetails?: ILoanDetailModel;
    personalDetails?: IPersonalDetailModel;
}
