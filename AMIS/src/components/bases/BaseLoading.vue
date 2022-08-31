<template>
  <div class="loading-bg" v-bind:class="{ loading__none: isShowLoading }">
    <!-- <div class="loading-ring">
      <div class="ring"></div>
      <span>LOADING...</span>
    </div> -->

    <div class="loading-modal"></div>
    <div class="loading">
      <div class="effect-1 effects"></div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AmisLoading",
  data() {
    return {
      // isShowLoading: false,
    };
  },

  props: {
    isShowLoading: Boolean,
  },
};
</script>

<style scoped>
.loading__none {
  display: none !important;
}
.loading-bg {
  display: flex;
  text-align: center;
  justify-content: center;
  align-items: center;
  min-height: 100vh;
  position: absolute;
  top: 0;
  z-index: 999;
  width: 100%;
}

.loading-modal {
  width: 100%;
  height: 100%;
  background: #fff;
  position: absolute;
  z-index: 9998;
  opacity: 0.2;
}

.loading {
  position: absolute;
  left: calc(50% - 27px);
  top: calc(50% - 27px);
  width: 50px;
  height: 50px;
  border-radius: 50%;
  box-sizing: border-box;
  border: 3px solid transparent;
  z-index: 9999;
}

.loading .effects {
  transition: all 0.3s ease;
}
.loading .effect-1 {
  animation: rotate 1s ease infinite;
}

.loading .effect-1,
.loading .effect-2 {
  position: absolute;
  width: 100%;
  height: 100%;
  border: none;
  box-sizing: border-box;
  background: transparent url(https://actappg2.misacdn.net/loading.svg)
    no-repeat center;
  background-size: 100%;
}
#loading-bg {
  width: 100%;
  height: 100%;
  display: none;
  position: absolute;
}
.loading-logo {
  position: absolute;
  left: calc(50% - 45px);
  top: 40%;
}
.loading {
  position: absolute;
  left: calc(50% - 27px);
  top: calc(50% - 27px);
  width: 50px;
  height: 50px;
  border-radius: 50%;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  border: 3px solid transparent;
  z-index: 9999;
}
.loading-modal {
  width: 100%;
  height: 100%;
  background: #fff;
  display: block;
  position: absolute;
  z-index: 9998;
  opacity: 0.2;
}
.loading .effect-1,
.loading .effect-2 {
  position: absolute;
  width: 100%;
  height: 100%;
  border: none;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
  background: transparent url(https://actappg2.misacdn.net/loading.svg)
    no-repeat center;
  background-size: 100%;
}
.loading .effect-1 {
  animation: rotate 1s ease infinite;
}
.loading .effect-2,
.loading .effect-3 {
  display: none;
}
.loading .effect-2 {
  animation: rotateOpacity 1s ease infinite 0.1s;
}
.loading .effect-3 {
  position: absolute;
  width: 100%;
  height: 100%;
  border: none;
  -webkit-animation: rotateOpacity 1s ease infinite 0.2s;
  animation: rotateOpacity 1s ease infinite 0.2s;
  border-radius: 50%;
  -webkit-box-sizing: border-box;
  box-sizing: border-box;
}
.loading .effects {
  transition: all 0.3s ease;
}
@keyframes rotate {
  0% {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  100% {
    -webkit-transform: rotate(1turn);
    transform: rotate(1turn);
  }
}
@keyframes rotateOpacity {
  0% {
    -webkit-transform: rotate(0deg);
    transform: rotate(0deg);
    opacity: 0.1;
  }
  100% {
    -webkit-transform: rotate(1turn);
    transform: rotate(1turn);
    opacity: 1;
  }
}
.apexcharts-toolbar {
  z-index: inherit !important;
}
.report-param .box-grid .grid-loading {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  max-height: 302px;
}
</style>