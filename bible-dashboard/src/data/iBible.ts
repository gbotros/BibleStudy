export interface IBible {
  books: { [bookName: string]: IBook }
}
export interface IBook {
  bookName: string
  chapters: { [chapterNumber: number]: IChapter }
}
export interface IChapter {
  chapter: number
  verses: { [verseNumber: number]: IVerse }
}
export interface IVerse {
  bookName: string
  chapter: number
  verse: number
  text: string
}
