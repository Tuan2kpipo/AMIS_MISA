<template>
  <div class="amis__header">
    <div class="header__right">
      <div class="icon">
        <div class="icon icon__sx" @click="onClickBtnNav"></div>
      </div>
      <div class="branch__text">
        <span>Công ty cổ phần misa </span>
      </div>
      <div class="icon icon__center icon__prev"></div>

    </div>

    <div class="header__left">
      <Popper hover content="Thông báo">
        <div class="bell">
          <div class="icon__menu icon__bell">
            <div class="icon icon__bell--img"></div>
          </div>
        </div>
      </Popper>

      <div class="avt avt__icon"></div>

      <div class="info__text">
        <span>Nguyen Duc Tuan</span>
      </div>

      <div class="icon icon__prev"></div>
    </div>
  </div>
</template>

<script>
import Popper from "vue3-popper";

export default {
  name: "TheHeader",
  components: {
    Popper,
  },

  methods: {
    /**
     *Khi click vào btn ba gạch bên trái công ty cổ phần misa
     *Thực hiện việc ẩn hiện thanh navbar
     *Author: ND_Tuan (04/08/2022)
     */
    onClickBtnNav() {
      var x = document.querySelector(".navbar");
      if (x.style.display === "none") {
        x.style.display = "block";
      } else {
        x.style.display = "none";
      }
    },
  },
};
</script>

<style scoped>
@import url("../../styles/layout/TheHeader.css");
@import url("../../styles/icon/icon.css");

.display__none {
  display: none !important;
}

.icon__sx:hover {
  cursor: pointer;
}
.bell {
  display: flex;
  width: 45px;
  height: 48px;
  align-items: center;
  justify-content: center;
}
.icon__bell:hover {
  animation: color-me-in 1s linear 3;
}

@keyframes color-me-in {
  0% {
    transform: rotate(0deg);
  }

  10% {
    transform: rotate(30deg);
  }

  20% {
    transform: rotate(-60deg);
  }
  30% {
    transform: rotate(60deg);
  }

  40% {
    transform: rotate(-60deg);
  }
  50% {
    transform: rotate(30deg);
  }
}

:deep(.popper) {
  background: #000;
  padding: 4px 10px;
  color: #fff;
  font-size: 11px;
  text-transform: uppercase;
  border-radius: 4px;
  margin: -22px 0px 0px 60px !important;
}

:deep(.popper:hover),
:deep(.popper:hover > #arrow::before) {
  background: #000;
}

:deep(.popper > #arrow) {
  top: -4px;
  position: absolute;
  left: 0px;
  transform: translate(162px, 89px);
}

:deep(.inline-block) {
  border: none !important;
  margin: 0 !important;
}
</style>
