export class DemographicInfoModels {
    id: number;
    creationTime: Date;
    creatorUserId: number;
    lastModificationTime: Date;
    lastModifierUserId: number;
    isDeleted: boolean;
    deleterUserId: number;
    deletionTime: Date;
    isHispanicOrLatino: boolean ;
    isMexican: boolean ;
    isPuertoRican: boolean ;
    isCuban: boolean ;
    isOtherHispanicOrLatino: boolean ;
    origin: string;
    isNotHispanicOrLatino: boolean ;
    canNotProvideEthnicInfo: boolean ;
    isAmericanIndianOrAlaskaNative: boolean ;
    nameOfEnrolledOrPrincipalTribe: string;
    isAsian: boolean ;
    isAsianIndian: boolean ;
    isChinese: boolean ;
    isFilipino: boolean ;
    isJapanese: boolean ;
    isKorean: boolean ;
    isVietnamese: boolean ;
    isOtherAsian: boolean ;
    otherAsianRace: string;
    isBlackOrAfricanAmerican: boolean;
    isNativeHawaiianOrOtherPacificIslander: boolean;
    isNativeHawaiian: boolean ;
    isGuamanianOrChamorro: boolean ;
    isSamoan: boolean;
    isOtherPacificIslander: boolean ;
    otherPacificIslanderRace: string;
    isWhite: boolean ;
    canNotProvideRaceInfo: boolean ;
    isMale: boolean ;
    isFemale: boolean ;
    canNotProvideSexInfo: boolean ;
    demographicInfoSource: string;
    personalInformationId: number;
    demographicInfoByFinancialInstitution: DemographicInfoByFinancialInstitution = new DemographicInfoByFinancialInstitution()

}
export class DemographicInfoByFinancialInstitution {
    id: number;
    creationTime: Date;
    creatorUserId: number;
    lastModificationTime: Date;
    lastModifierUserId: number;
    isDeleted: boolean;
    deleterUserId: number;
    deletionTime: Date;
    isEthnicityByObservation: boolean ;
    isGenderByObservation: boolean ;
    isRaceByObservation: boolean ;
    personalInformationId: number;
}