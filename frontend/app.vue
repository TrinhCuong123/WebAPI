<template>
  <div>
    <NuxtRouteAnnouncer />
    <NuxtWelcome />
  </div>
</template>
<script setup>
import TempService from '~/services/temp.service';


console.log(1);
const { data: getListTemp } = await useAsyncData('getListTemp', () => TempService.list());
console.log(getListTemp);
</script>