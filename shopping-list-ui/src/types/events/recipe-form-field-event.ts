import { RecipeUpdateType } from "@/enums/recipe-update-type"
import { Ingredient } from "../ingredient"

export type RecipeFormFieldEvent = {
    type: RecipeUpdateType
    name: string
    value?: string | number | Ingredient
}