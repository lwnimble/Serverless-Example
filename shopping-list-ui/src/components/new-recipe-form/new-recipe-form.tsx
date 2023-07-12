'use client'
import { postRecipe } from "@/api-clients/recipe-client"
import { useReducer } from "react"
import { NewRecipe } from "@/types/new-recipe"
import { RecipeFormFieldEvent } from "@/types/events/recipe-form-field-event";
import { AddIngredient } from "../add-ingredient/add-ingredient";
import { InputProps } from "@/types/props/input-props";
import { TextInput } from "../text-input/text-input";

const defaultFormData: NewRecipe = {
    name: "",
    description: "",
    nationality: "",
    url: "https://",
    ingredients: []
}

const formReducer = (state: NewRecipe, event: RecipeFormFieldEvent) : NewRecipe  => {
    let updated: NewRecipe;
    switch (event.type) {
        case "recipe-update":
            updated = {
                ...state,
                [event.name]: event.value
            };
            break;
        case "add-ingredient":
            updated = {
                ...state,
                ingredients: [...state.ingredients, event.value]
            } as NewRecipe ;
            break;
        case "reset":
            return defaultFormData;
        default:
            throw Error(`Unknown recipe event of ${event.type}`);
    };
    return updated;
}

export function NewRecipeForm() {
    const [formData, setFormData] = useReducer(formReducer, defaultFormData);

    const handleSubmit = async (event: any) => {
        event.preventDefault();
        await postRecipe(formData);
        setFormData({
            name: "",
            type: "reset"
        })
    };

    const handleChange = (event: React.ChangeEvent<any>) => {
        setFormData({
            type: "recipe-update",
            name: event.target.name,
            value: event.target.value
        });
    };
    
    return (
        <div className="wrapper">
            <form onSubmit={handleSubmit}>
                <fieldset>
                    <TextInput fieldProps={{
                        id: "name",
                        title: "Name",
                        changeEventHandler: handleChange,
                        value: formData.name
                        }}/>
                    <TextInput fieldProps={{
                        id: "description", 
                        title: "Description", 
                        changeEventHandler: handleChange,
                        value: formData.description
                        }}/>
                    <TextInput fieldProps={{
                        id: "nationality",
                        title: "Nationality",
                        changeEventHandler: handleChange,
                        value: formData.nationality
                        }}/>
                    <TextInput fieldProps={{
                        id: "url", 
                        title: "Url", 
                        changeEventHandler: handleChange,
                        value: formData.url
                        }}/>
                </fieldset>
                <AddIngredient recipeData={formData} setRecipeData={setFormData}/>
                <button type="submit">Save</button>
            </form>
        </div>
    )
}