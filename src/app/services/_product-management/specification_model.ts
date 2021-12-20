import { Identification } from "./identification_model";

export interface Specification{
    id: string;
    // productid: string;
    // categoryid: string;
    name: string;
    identification: Identification[];
}