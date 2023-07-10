import { FormField, FormFieldProps } from "@/components/form-field/form-field";

const recipeNameProps: FormFieldProps = {id: "testId", title: "Recipe Name"};

export default function NewRecipe() {
    return (
            <form>
                <FormField fieldProps={recipeNameProps}/>
                <button type="submit">Submit</button>
            </form>
    )
}