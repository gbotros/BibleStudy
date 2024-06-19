import type { BibleLoaderService } from '@/data/bibleLoader'
import { WordPiePerTestamentModel } from './wordPiePerTestamentModel'

export class WordPiePerTestamentFactory {
  constructor(private bibleLoaderService: BibleLoaderService) {}

  public getModelFor(word: string): WordPiePerTestamentModel {
    const summary = this.bibleLoaderService.getBibleSummary()
    const model = new WordPiePerTestamentModel()
    model.word = word
    model.countInBible = summary.words[word] ?? 0
    model.countInOldTestament = summary.oldTestamentSummary.words[word] ?? 0
    model.countInNewTestament = summary.newTestamentSummary.words[word] ?? 0

    return model
  }
}
