<template>
  <div class="card row justify-content-center">
    <div class="row">
      <div class="col-6 bg-primary">Img on this side</div>
      <div class="col-6">
        <h3>Recipe Name</h3>
        <p>This is the description of the recipe</p>
        <p>LABEL</p>
      </div>
    </div>
  </div>
</template>


<script>
export default {
  props: { recipe: { type: Object, required: true } },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
</style>