import {IBorrowerModel} from './IBorrowerModel';
import {IAddressModel} from './IAddressModel';

export interface IPersonalInformationModel {
    id?: number;
    isApplyingWithCoBorrower?: boolean;
    useIncomeOfPersonOtherThanBorrower?: boolean;
    agreePrivacyPolicy?: boolean;
    borrower?: IBorrowerModel;
    coBorrower?: IBorrowerModel;
    residentialAddress?: IAddressModel;
    previousAddress?: IAddressModel;
    mailingAddress?: IAddressModel;
    isMailingAddressSameAsResidential?: boolean;
}
