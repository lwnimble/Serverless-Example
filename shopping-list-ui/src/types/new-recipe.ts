import { Ingredient } from "./ingredient";

export type NewRecipe = {
    url : string
    name: string
    description: string
    nationality: string
    ingredients: Ingredient[]
};