'use client'
import { postRecipe } from "@/api-clients/recipe-client"
import { Ingredient } from "@/types/ingredient"
import { useReducer } from "react"
import { TextInput, TextInputProps } from '../form-field/form-field';
import { PostRecipe } from "@/types/post-recipe"

type FormEvent = {
    name: string
    value: string | number | Ingredient
}

const newRecipe: PostRecipe = {
    name: "",
    description: "",
    nationality: "",
    url: "",
    ingredients: [
        {
            name: "apple",
            category: "fruit",
            quantity: 2
        }
    ],
}

const formReducer = (state: PostRecipe, event: FormEvent) => {
    return {
        ...state,
        [event.name]: event.value
    }
}

export function NewRecipeForm() {
    const [formData, setFormData] = useReducer(formReducer, newRecipe);

    const handleSubmit = async (event: any) => {
        event.preventDefault();
        await postRecipe(formData);
    };

    const handleChange = (event: React.ChangeEvent<any>) => {
        setFormData({
            name: event.target.name,
            value: event.target.value
        });
    };

    const nameInputProps: TextInputProps = {id: "name", title: "Name", changeEventHandler: handleChange};
    const descriptionInputProps: TextInputProps = {id: "description", title: "Description", changeEventHandler: handleChange};
    const nationalityInputProps: TextInputProps = {id: "nationality", title: "Nationality", changeEventHandler: handleChange};
    const urlInputProps: TextInputProps = {id: "url", title: "Url", changeEventHandler: handleChange};

    return (
        <div className="wrapper">
            <form onSubmit={handleSubmit}>
                <fieldset>
                    <TextInput fieldProps={nameInputProps}/>
                    <TextInput fieldProps={descriptionInputProps}/>
                    <TextInput fieldProps={nationalityInputProps}/>
                    <TextInput fieldProps={urlInputProps}/>
                </fieldset>
                <button type="submit">Save</button>
            </form>
        </div>
    )
}