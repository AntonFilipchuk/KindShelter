import { IPet } from "./IPet";

export interface IPetPagination
{
    pageIndex: number;
    pageSize: number;
    count: number;
    data: IPet[];
}