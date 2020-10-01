import { Address } from 'cluster';
import { List } from 'lodash';
import {IBorrowerModel} from './IBorrowerModel';
import {IAddressModel} from './IAddressModel';
export interface IPersonalInformationModel {
    id?: number;
    isApplyingWithCoBorrower?: boolean;
    useIncomeOfPersonOtherThanBorrower?: boolean;
    agreePrivacyPolicy?: boolean;
    borrower?: IBorrowerModel;
    coBorrower?: IBorrowerModel;
    addresses?:IAddressModel[];
   
}
