import Link from 'next/link'
import RootLayout from './layout'

export default function Home() {
  return (
   <RootLayout home>
    <div>
      <Link href='/recipe/create'>Create Recipe</Link>
      <Link href='/recipe/list'>List Recipes</Link>
    </div>
  </RootLayout>
  )
}
