import { Recipe } from "@/types/recipe";

const api_url = process.env.API_URL;

export async function getAllRecipes() : Promise<Recipe[]> {
    const response = await fetch(`${api_url}/recipe`);

    if (!response.ok) {
        return Promise.reject(response.statusText);
    }

    return await response.json() as Recipe[];
}

export async function getRecipe(id: string, nationality: string) : Promise<Recipe> {
    const response = await fetch(`${api_url}/recipe/${nationality}/${id}`);

    if (!response.ok) {
        return Promise.reject(response.statusText)
    }

    return await response.json() as Recipe;
}