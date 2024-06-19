<script setup lang="ts">
import { inject, ref } from 'vue'
import {
  BibleLoaderServiceKey,
  WordPiePerBookFactoryKey,
  WordPiePerTestamentFactoryKey,
  WordReferencesFactoryKey
} from '@/injectionKeys'
import WordsFilter from '@/components/WordsFilter.vue'
import WordPiePerTestament from '@/wordPiePerTestament/wordPiePerTestament.vue'
import WordPiePerBook from '@/wordPiePerBook/wordPiePerBook.vue'
import WordFilterInput from '@/components/wordFilterInput.vue'
import WordReferences from '@/wordReferences/wordReferences.vue'
import { WordPiePerTestamentModel } from '@/wordPiePerTestament/wordPiePerTestamentModel'
import { WordPiePerBookModel } from '@/wordPiePerBook/wordPiePerBookModel'
import type { WordPiePerBookFactory } from '@/wordPiePerBook/wordPiePerBookFactory'
import type { WordReferencesFactory } from '@/wordReferences/wordReferencesFactory'
import { WordPiePerTestamentFactory } from '@/wordPiePerTestament/wordPiePerTestamentFactory'
import type { BibleLoaderService } from '@/data/bibleLoader'
import type { IVerse } from '@/data/iBible'

const wordPiePerTestamentFactory = inject(
  WordPiePerTestamentFactoryKey
) as WordPiePerTestamentFactory

const bibleLoaderService = inject(BibleLoaderServiceKey) as BibleLoaderService
const wordPiePerBookFactory = inject(WordPiePerBookFactoryKey) as WordPiePerBookFactory
const wordReferencesFactory = inject(WordReferencesFactoryKey) as WordReferencesFactory

// intialize
bibleLoaderService.getTheBible()
const searchTerm = ref('angel')
const selectedWord = ref('angel')
const vs: IVerse[] = []
const wordVerses = ref(vs)
const wordPiePerTestamentModel = ref(new WordPiePerTestamentModel())
const wordPiePerBookModel = ref(new WordPiePerBookModel())
updateFactories()

function searchTermUpdated(search: string): void {
  searchTerm.value = search
}

function wordSelected(word: string): void {
  selectedWord.value = word

  updateFactories()
}

function updateFactories(): void {
  wordPiePerTestamentModel.value = wordPiePerTestamentFactory.getModelFor(selectedWord.value)
  wordPiePerBookModel.value = wordPiePerBookFactory.getModelFor(selectedWord.value)
  wordVerses.value = wordReferencesFactory.getModelFor(selectedWord.value)
}
</script>

<template>
  <main>
    <div class="header">
      <h1>The Bible word analysis</h1>
    </div>
    <div class="filter-header">
      <WordFilterInput @update-search-term="searchTermUpdated" :search="searchTerm" />
    </div>

    <div class="words-list">
      <WordsFilter :search="searchTerm" @word-selected="wordSelected" />
    </div>

    <div class="selected-word">
      <h2>Selected word: {{ selectedWord }}</h2>
    </div>

    <div class="word-graphs">
      <div class="word-graph">
        <WordPiePerTestament :wordPiePerTestamentModel="wordPiePerTestamentModel" />
      </div>

      <div class="word-graph">
        <WordPiePerBook :wordPiePerBookModel="wordPiePerBookModel" />
      </div>
    </div>

    <div class="word-verses">
      <WordReferences :word-verses="wordVerses" />
    </div>
  </main>
</template>

<style scoped>
.header {
  margin-bottom: 10px;
}
.filter-header {
  margin-bottom: 10px;
}

.words-list {
  margin-bottom: 10px;
}
.selected-word {
  margin-bottom: 10px;
}
.word-graphs {
  display: flex;
  margin-bottom: 10px;
}

.word-graph {
  flex: 1 1 0;
}

.word-verses {
  margin-bottom: 10px;
}
</style>
