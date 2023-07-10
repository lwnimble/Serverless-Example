import { Ingredient } from "./ingredient";

export type Recipe = {
    id : string
    url : string
    name: string
    description: string
    nationality: string
    ingredients: Ingredient[]
};