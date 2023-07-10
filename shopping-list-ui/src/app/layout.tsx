import '../styles/global.css'
import styles from './layout.module.css';
import Head from 'next/head';
import Link from 'next/link';


export default function RootLayout({children, home }: {children: React.ReactNode, home?: any}) {
  return (
    <div className={styles.container}>
      <Head>Shopping List Creator</Head>
      <h1>Shopping List Creator</h1>
      <main>{children}</main>
      <div className={styles.backToHome}>
        <Link href="/">← Back to home</Link>
      </div>
    </div>
  )
}
