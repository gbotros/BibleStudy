<script setup lang="ts">
import { ref, computed, inject } from 'vue'
import { BibleLoaderService } from '@/data/bibleLoader'
import { BibleLoaderServiceKey } from '@/injectionKeys'

const wordDisplayLimit = 30 // max 30 word will be displayed on screen

const bibleLoaderService = inject(BibleLoaderServiceKey) as BibleLoaderService

const wordsAsArray = Object.keys(bibleLoaderService.getBibleSummary().words)
const words = ref(wordsAsArray)

const props = defineProps<{
  search: String
}>()

const filteredWords = computed(() => {
  const wordsStartWithSearchTerm = words.value
    .filter((word) => word.startsWith(props.search.toLowerCase()))
    .slice(0, wordDisplayLimit)

  if (wordsStartWithSearchTerm.length == 1) emit('wordSelected', wordsStartWithSearchTerm[0])
  return wordsStartWithSearchTerm
})

const emit = defineEmits(['wordSelected'])

const emitWordSelected = (word: string) => {
  emit('wordSelected', word)
}
</script>

<template>
  <div class="wrap">
    <span v-for="word in filteredWords" :key="word" class="word" @click="emitWordSelected(word)">
      {{ word }}
    </span>
  </div>
</template>

<style scoped>
.wrap {
  display: flex;
  flex-wrap: wrap;
}

.word {
  flex: 1;
  text-align: center;
  margin: 2px;
  padding: 3px;
  border: 1px;
  border-radius: 5px;
  border-style: solid;
  border-color: var(--vt-c-white);
  background-color: var(--vt-c-black);
  cursor: pointer;
}

.word:hover {
  border-color: var(--vt-c-black-mute);
  color: var(--vt-c-black);
  background-color: var(--vt-c-white);
}
</style>
