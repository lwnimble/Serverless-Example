import { getAllRecipes } from "@/api-clients/recipe-client";
import RootLayout from "@/app/layout";
import { RecipeTile } from "@/components/recipe-tile/recipe-tile";

export default async function RecipeList() {
    const recipes = await getAllRecipes();
    return (
        <RootLayout>
            <div> 
                <h1>Recipes</h1>
                {recipes.map((recipe) => (
                    <RecipeTile key={recipe.id} recipe={recipe}/>
                ))}
            </div>
        </RootLayout>
    )
}

