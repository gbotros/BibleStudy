export interface IBibleSummary extends ISummary {
  name: string
  words: { [word: string]: number }
  oldTestamentSummary: ITestamentSummary
  newTestamentSummary: ITestamentSummary
}

export interface ITestamentSummary {
  name: string
  words: { [word: string]: number }
  books: { [bookName: string]: ISummary }
}

export interface ISummary {
  name: string
  words: { [word: string]: number }
}
