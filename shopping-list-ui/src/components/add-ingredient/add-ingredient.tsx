import { Ingredient } from "@/types/ingredient";
import { RecipeFormFieldEvent } from "@/types/events/recipe-form-field-event";
import { Dispatch, useReducer } from 'react';
import { TextInput } from "../text-input/text-input";
import { NumberInput } from "../number-input/number-input";
import { NewRecipe } from "@/types/new-recipe";


const newIngredient: Ingredient = {
    name: "",
    category: "",
    quantity: 1
}

const ingredientReducer = (state: Ingredient, event: RecipeFormFieldEvent) => {
    if (event.type === "reset") {
        return newIngredient;
    }
    return {
        ...state,
        [event.name]: event.value
    }
}

export function AddIngredient({ recipeData, setRecipeData }:{recipeData: NewRecipe, setRecipeData:  Dispatch<RecipeFormFieldEvent>}) {
    const [ingredientData, setIngredientData] = useReducer(ingredientReducer, newIngredient);

    const handleChange = (event: React.ChangeEvent<any>) => {
        setIngredientData({
            type: "add-ingredient",
            name: event.target.name.split("-")[1], // gets name that matches the type
            value: event.target.value
        });
    };

    const handleClick = () => {
        setRecipeData({
            type: "add-ingredient",
            name: "ingredient",
            value: ingredientData
        })
        setIngredientData({
            name: "",
            type: "reset"
        })
    }

    return (
        <fieldset>
            <div>
                <p>Add Ingredients</p>
                <TextInput fieldProps={{
                    id: "ingredient-name",
                    title: "Ingredient Name",
                    value: ingredientData.name,
                    changeEventHandler: handleChange
                }} 
                />
                <NumberInput fieldProps={{
                    id: "ingredient-quantity",
                    title: "Qty",
                    minValue: 1,
                    value: ingredientData.quantity,
                    changeEventHandler: handleChange
                }}
                />
                <TextInput fieldProps={{
                    id: "ingredient-category",
                    title: "Category",
                    value: ingredientData.category,
                    changeEventHandler: handleChange
                }}/>
                <button onClick={handleClick} type="button" id="add-ingredient">Add Ingredient</button>
            </div>
            <div>
                {recipeData.ingredients.map((ingredient) => (
                    <p key={ingredient.name.toString()}>{`${ingredient.name.toString()}: ${ingredient.quantity.toString()}`}</p>
                ))}
            </div>
        </fieldset>
    )
}