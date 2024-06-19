import bibleSummary from '@/data/bibleSummary.json'
import bibleIndex from '@/data/bibleIndex.json'
import theBible from '@/data/theBible.json'
import type { IBibleSummary } from './iBibleSummary'
import type { IBible, IBook, IChapter, IVerse } from './iBible'
import { MetaBibleBooks } from './bibleBookMeta'

export class BibleLoaderService {
  public getBibleSummary(): IBibleSummary {
    const data: IBibleSummary = bibleSummary
    return data
  }

  public getWordReferencesSummary(): { [word: string]: string[] } {
    const data: { [word: string]: string[] } = bibleIndex.wordsReferences
    return data
  }

  // todo: cache
  public getTheBible(): IBible {
    const rawVerses: IVerse[] = theBible
    const bible: IBible = this.buildEmptyBible()

    rawVerses.forEach((verse) => {
      bible.books[verse.bookName].chapters[verse.chapter].verses[verse.verse] = verse
    })

    return bible
  }

  private buildEmptyBible(): IBible {
    const bible: IBible = { books: {} }
    MetaBibleBooks.forEach((metaBook) => {
      bible.books[metaBook.name] = { bookName: metaBook.name, chapters: {} }

      for (let i = 1; i <= metaBook.chaptersCount; i++) {
        bible.books[metaBook.name].chapters[i] = { chapter: i, verses: {} }
      }
    })

    return bible
  }
}
