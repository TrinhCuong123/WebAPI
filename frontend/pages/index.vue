<script setup>
import TempService from '~/services/temp.service';
const { data: items, error } = await useAsyncData('tempData',() => TempService.list());

if (error) {
  console.error('Error fetching data:', error);
}
</script>

<template>
  <div>
    <ul v-if="items">
      <li v-for="item in items" :key="item.id">{{ item.name }}</li>
    </ul>
    <p v-else>Loading...</p>
  </div>
</template>
