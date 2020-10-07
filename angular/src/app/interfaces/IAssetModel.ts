export class IAssetModel {
    id?: number;
    AssetTypeId?: number;

    name?: string;
    bankName?: string;
    description?: string;
    accountNumber?: string;
    cashValue?: number;
    address?: string;
    address2?: string;
    city?: string;
    stateId?: number;
    zipCode?: string;

    propertyStatusId?: number;
    propertyUsedAsId?: number;
    propertyTypeId?: number;
    presentMarketValue?: number;
    outstandingMortgageBalance?: number;
    monthlyMortgagePayment?: number;
    purchasePrice?: number;
    grossRentalIncome?: number;
    otherIncome?: number;

    stockAndBonds?: any[];
}
