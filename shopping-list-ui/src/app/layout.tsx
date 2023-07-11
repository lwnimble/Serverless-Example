import '../styles/global.css'
import styles from './layout.module.css';
import Link from 'next/link';


export default function RootLayout({children, home }: {children: React.ReactNode, home?: any}) {
  return (
    <html>
      <body>
        <header>
          <title>Shopping List Creator</title>
        </header>
        <div className={styles.container}>
          <h1>Shopping List Creator</h1>
          <main>{children}</main>
          <div className={styles.backToHome}>
            <Link href="/">← Back to home</Link>
          </div>
        </div>
      </body>
    </html>
  )
}
