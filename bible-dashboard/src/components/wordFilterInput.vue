<script setup lang="ts">
const emit = defineEmits(['updateSearchTerm'])

const props = defineProps<{
  search: String
}>()
const emitSearchTerm = (event: any) => {
  emit('updateSearchTerm', event.target.value)
}

// const search: string = ''
</script>

<template>
  <div>
    <input
      :value="search"
      @input="emitSearchTerm"
      class="search-field"
      placeholder="Search for a word in the bible"
    />
  </div>
</template>

<style scoped>
.search-field {
  width: 100%;
  padding-left: 1rem;
  line-height: 3rem;
  font-size: 2rem;
}
</style>
