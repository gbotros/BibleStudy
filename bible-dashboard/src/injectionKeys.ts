import type { InjectionKey } from 'vue'
import type { BibleLoaderService } from './data/bibleLoader'
import type { WordPiePerTestamentFactory } from './wordPiePerTestament/wordPiePerTestamentFactory'
import type { WordPiePerBookFactory } from './wordPiePerBook/wordPiePerBookFactory'
import type { WordReferencesFactory } from './wordReferences/wordReferencesFactory'

export const BibleLoaderServiceKey = Symbol() as InjectionKey<BibleLoaderService>
export const WordPiePerTestamentFactoryKey = Symbol() as InjectionKey<WordPiePerTestamentFactory>
export const WordPiePerBookFactoryKey = Symbol() as InjectionKey<WordPiePerBookFactory>
export const WordReferencesFactoryKey = Symbol() as InjectionKey<WordReferencesFactory>
