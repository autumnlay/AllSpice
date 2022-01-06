<template>
  <div
    class="
      home
      flex-grow-1
      d-flex
      flex-column
      align-items-center
      justify-content-center
    "
  >
    <Recipe :recipe="r" />
    <!-- <div v-for="r in recipe" :key="r.id">
    </div> -->
  </div>
</template>

<script>
export default {
  name: 'Home'
}
</script>

<style scoped lang="scss">
</style>
