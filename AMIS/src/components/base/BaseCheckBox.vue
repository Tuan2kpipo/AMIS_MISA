<template>
  <label :class="['m-checkbox-wrapper', className]">
    <input
      type="checkbox"
      class="m-checkbox"
      :name="name"
      :checked="checked"
      @change="$emit('change', $event)"
    />
    <span v-if="label">{{ label }}</span>
  </label>
</template>


<script>
export default {
  props: {
    label: {
      type: String,
      default: "",
    },
    name: {
      type: String,
      default: null,
    },
    className: {
      type: String,
      default: "",
    },
    checked: {
      type: Boolean,
      default: false,
    },
  },
};
</script>
<style  scoped>
.m-checkbox-wrapper {
  display: flex;
  gap: 10px;
  align-items: center;
  cursor: pointer;
}
</style>
