import type { BibleLoaderService } from '@/data/bibleLoader'
import { WordPiePerBookModel } from './wordPiePerBookModel'
import type { IBookWordCount } from './IBookWordCount'

export class WordPiePerBookFactory {
  constructor(private bibleLoaderService: BibleLoaderService) {}

  public getModelFor(word: string): WordPiePerBookModel {
    const summary = this.bibleLoaderService.getBibleSummary()
    const model = new WordPiePerBookModel()
    model.word = word

    const wordBooks: IBookWordCount[] = []

    const oldTestamentBooks = Object.entries(summary.oldTestamentSummary.books)
    oldTestamentBooks.forEach((bookEntry) => {
      const bookName = bookEntry[0]
      const bookSummary = bookEntry[1]
      const wordBookCount = bookSummary.words[word]
      if (wordBookCount) wordBooks.push({ bookName: bookName, count: wordBookCount })
    })

    const newTestamentBooks = Object.entries(summary.newTestamentSummary.books)
    newTestamentBooks.forEach((bookEntry) => {
      const bookName = bookEntry[0]
      const bookSummary = bookEntry[1]
      const wordBookCount = bookSummary.words[word]
      if (wordBookCount) wordBooks.push({ bookName: bookName, count: wordBookCount })
    })

    wordBooks.sort((a, b) => b.count - a.count)
    model.books = wordBooks

    debugger
    return model
  }
}
