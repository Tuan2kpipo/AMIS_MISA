<template>
  <div class="amis">
    <TheNavbar></TheNavbar>

    <MainContain class="main__content">
      <TheHeader></TheHeader>
      <TheContent></TheContent>
    </MainContain>
  </div>
</template>

<script>
import TheNavbar from "./components/layout/TheNavBar.vue";
import TheHeader from "./components/layout/TheHeader.vue";
import TheContent from "./components/layout/TheContent.vue";

export default {
  name: "App",
  components: {
    TheNavbar,
    TheHeader,
    TheContent,
  },
};
</script>

<style >
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: Misa Fonts Regular !important;
  font-size: 13px;
  margin: 0;
  color: #000000;
  box-sizing: border-box;
}

@font-face {
  font-family: Misa Fonts Regular;
  src: url(/src/assets/fonts/notosans-regular.2cb88a13.woff2);
}

@font-face {
  font-family: Misa Fonts Bold;
  src: url(/src/assets/fonts/notosans-bold.3ede5aff.woff2);
}

@font-face {
  font-family: Misa Fonts Italic;
  src: url(/src/assets/fonts/notosans-italic.1c1aaac9.woff2);
}
#app {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

.amis {
  display: flex;
}

.main__content {
  /* width: calc(100% - 178px); */
  flex: 1;
  min-height: 0;
  min-width: 0;
  position: relative;
}

.amis {
  position: relative;
  width: 100%;
  height: 100vh;
}

.el-pagination.is-background .btn-next:disabled,
.el-pagination.is-background .btn-prev:disabled {
  color: #000 !important;
  background-color: #fff !important;
}

.el-pagination.is-background .btn-next,
.el-pagination.is-background .btn-prev,
.el-pagination.is-background .el-pager li {
  margin: 0 4px;
  background-color: #fff !important;
  color: #000 !important;
  min-width: 32px;
  border-radius: 2px;
}

.el-pagination.is-background .el-pager li:not(.is-disabled).is-active {
  border: 1px solid #e0e0e0;
  color: #000 !important;
  font-weight: 700 !important;
}
</style>
