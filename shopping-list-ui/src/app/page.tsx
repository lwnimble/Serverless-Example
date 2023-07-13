import Link from 'next/link'

export default function Home() {
  return (
    <div>
      <p><Link href='/recipe/create'>Create Recipe</Link></p>
      <p><Link href='/recipe/list'>List Recipes</Link></p>    
    </div>
  )
}
