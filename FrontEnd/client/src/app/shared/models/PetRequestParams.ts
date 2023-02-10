export class PetRequestParams {
    pageIndex: number = 1;
    pageSize: number = 15;
    breedId: number | undefined = undefined;
    animalsId: number | undefined = undefined;
    sort: string | undefined = undefined;
    search: string | undefined = undefined;
}