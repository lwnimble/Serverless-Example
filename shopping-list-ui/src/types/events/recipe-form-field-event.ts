import { Ingredient } from "../ingredient"

export type RecipeFormFieldEvent = {
    type: string
    name: string
    value?: string | number | Ingredient
}