<script setup lang="ts">
import { computed, ref } from 'vue'
import type { WordPiePerBookModel } from './wordPiePerBookModel'

const props = defineProps<{
  wordPiePerBookModel: WordPiePerBookModel
}>()

const options = computed(() => {
  return {
    labels: props.wordPiePerBookModel.books.map((b) => b.bookName),
    legend: {
      show: false
      // position: 'bottom'
    },
    theme: {
      mode: 'dark',
      palette: 'palette1'
    }
  }
})

const series = computed(() => {
  const values = props.wordPiePerBookModel.books.map((b) => b.count)
  return values
})
</script>

<template>
  <div>
    <apexchart height="400px" type="pie" :options="options" :series="series"></apexchart>
  </div>
</template>

<style scoped></style>
