<script setup lang="ts">
import { computed, ref } from 'vue'
import type { WordPiePerTestamentModel } from './wordPiePerTestamentModel'

const props = defineProps<{
  wordPiePerTestamentModel: WordPiePerTestamentModel
}>()

const options = ref({
  labels: ['Old Testament', 'New Testament'],
  legend: {
    show: false
    // position: 'bottom'
  },
  theme: {
    mode: 'dark',
    palette: 'palette1'
    // monochrome: {
    //   enabled: true,
    //   color: '#255aee',
    //   shadeTo: 'light',
    //   shadeIntensity: 0.65
    // }
  }
})

const series = computed(() => {
  return [
    props.wordPiePerTestamentModel.countInOldTestament,
    props.wordPiePerTestamentModel.countInNewTestament
  ]
})
</script>

<template>
  <div>
    <apexchart height="400px" type="pie" :options="options" :series="series"></apexchart>
  </div>

  <!-- 
  <h1>word: {{ wordPiePerTestamentModel.word }}</h1>
  <h1>word count in bible: {{ wordPiePerTestamentModel.countInBible }}</h1>
  <h1>word count in old testament: {{ wordPiePerTestamentModel.countInOldTestament }}</h1>
  <h1>word count in new testament: {{ wordPiePerTestamentModel.countInNewTestament }}</h1> 
  -->
</template>

<style scoped></style>
