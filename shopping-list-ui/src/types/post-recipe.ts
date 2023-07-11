import { Ingredient } from "./ingredient";

export type PostRecipe = {
    url : string
    name: string
    description: string
    nationality: string
    ingredients: Ingredient[]
};