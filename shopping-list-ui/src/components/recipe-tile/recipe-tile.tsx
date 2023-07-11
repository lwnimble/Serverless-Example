import { Recipe } from "@/types/recipe";
import Link from "next/link";

export function RecipeTile(  { recipe }: {recipe: Recipe}) {
    return (
    <div className="tile">
        <Link 
            href={{
                pathname: `/recipe/${recipe.id}`,
                query: {
                    recipeId: `${recipe.id}`,
                    nationality: `${recipe.nationality}`
                }}}
            >
                {recipe.name}
            </Link>
        <p>Nationality: {recipe.nationality}</p>
        <p>{recipe.description}</p>
    </div>
    );
}