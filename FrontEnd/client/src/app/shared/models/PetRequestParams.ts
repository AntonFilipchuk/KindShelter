export class PetRequestParams {
    pageIndex: number = 1;
    pageSize: number = 3;
    breedId?: number = undefined;
    animalsId?: number = undefined;
    sort?: string = undefined;
    search?: string = undefined;
    vaccinationStatus?: boolean = undefined;
}