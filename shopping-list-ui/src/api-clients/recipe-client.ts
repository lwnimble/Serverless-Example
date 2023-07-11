import { PostRecipe } from "@/types/post-recipe";
import { Recipe } from "@/types/recipe";

const api_url = process.env.NEXT_PUBLIC_API_URL;

export async function getAllRecipes() : Promise<Recipe[]> {
    const response = await fetch(`${api_url}/recipe`, {cache: "no-cache"} );

    if (!response.ok) {
        return Promise.reject(response.statusText);
    }

    var json = await response.json() as Recipe[];
    console.log(json);
    return json as Recipe[];
}

export async function getRecipe(id: string, nationality: string) : Promise<Recipe> {
    const response = await fetch(`${api_url}/recipe/${nationality}/${id}`);

    if (!response.ok) {
        return Promise.reject(response.statusText);
    }

    return await response.json() as Recipe;
}

export async function postRecipe(recipe: PostRecipe) : Promise<Recipe> {
    const response = await fetch(`${api_url}/recipe`, {
        method: "POST",
        body: JSON.stringify(recipe),
        headers: {
            "Content-Type": "application/json"
        }
    })

    if (!response.ok) {
        return Promise.reject(response.statusText);
    }

    return await response.json() as Recipe;
}