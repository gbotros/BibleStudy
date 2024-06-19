<script setup lang="ts">
import type { IVerse } from '@/data/iBible'

defineProps<{
  wordVerses: IVerse[]
}>()
</script>

<template>
  <div>
    <div v-for="verse in wordVerses" :key="verse.text" class="verse-container">
      <div class="reference">{{ verse.bookName }} {{ verse.chapter }}:{{ verse.verse }}</div>
      <div class="text">{{ verse.text }}</div>
    </div>
  </div>
</template>

<style scoped>
.verse-container {
  border: 2px solid rgba(100, 100, 100, 1);
  padding: 5px;
  border-radius: 5px;
  margin-bottom: 5px;
}
.reference {
  font-weight: bold;
}

.text {
}
</style>
