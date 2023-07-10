import { getRecipe } from "@/api-clients/recipe-client";
import { Recipe } from "@/types/recipe";
import { GetServerSideProps } from "next";


export default async function RecipePage( { searchParams }: {recipeId: string, nationality: string } ) {    
    const recipeId = searchParams.recipeId;
    const nationality = searchParams.nationality;
    const recipe = await getRecipe(recipeId, nationality);
    return (
        <div>            
            <a href={recipe.url}>{recipe.name}</a>
            <div>
                <ul>
                    {recipe.ingredients.map((ingredient) => (
                        <li key={ingredient.id}>{ingredient.name}  qty: {ingredient.quantity}</li>
                    ))}
                </ul>
            </div>
        </div>
    )
}