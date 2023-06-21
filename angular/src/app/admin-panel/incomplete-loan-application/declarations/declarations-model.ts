export class DeclarationsModel {
    id: number;
    creationTime: Date;
    creatorUserId: number;
    lastModificationTime: Date;
    lastModifierUserId: number;
    isDeleted: boolean;
    deleterUserId: number;
    deletionTime: Date;
    declarationQuestionId: number=0;
    answer: string='';
    personalInformationId: number=0;
}
