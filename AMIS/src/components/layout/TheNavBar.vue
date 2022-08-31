<template>
  <div class="navbar">
    <div class="logo__amis">
      <div class="icon amis__icon"></div>
      <div class="amis__logo"></div>
    </div>

    <div class="amis__menu moon-fes-sidebar">
      <Popper arrow hover content="Tổng quan">
        <router-link
          class="menu__items"
          active-class="menu-item active_item"
          to="/cus"
          exact
        >
          <div class="item__icon icon__dashboard"></div>
          <div class="item__text">Tổng quan</div>
        </router-link>
      </Popper>

      <Popper arrow hover content="Tiền mặt">
        <router-link
          class="menu__items"
          active-class="menu-item active_item"
          to="/empl"
        >
          <div class="item__icon icon__sidebar--bank"></div>
          <div class="item__text">Tiền mặt</div>
        </router-link>
      </Popper>

      <Popper arrow hover content="Tiền gửi">
        <router-link class="menu__items" to="/cus">
          <div class="item__icon icon__sidebar--cash"></div>
          <div class="item__text">Tiền gửi</div>
        </router-link>
      </Popper>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__shopping"></div>
        <div class="item__text">Mua hàng</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sale"></div>
        <div class="item__text">Bán hàng</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--invoice"></div>
        <div class="item__text">Quản lý hóa đơn</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--stock"></div>
        <div class="item__text">Kho</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--tools"></div>
        <div class="item__text">Công cụ dụng cụ</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--fixed"></div>
        <div class="item__text">Tài sản cố định</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--stock"></div>
        <div class="item__text">Thuế</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--tax"></div>
        <div class="item__text">Gía thành</div>
      </router-link>

      <!-- <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--general"></div>
        <div class="item__text">Tiền lương</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--report"></div>
        <div class="item__text">Báo cáo</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--price"></div>
        <div class="item__text">Tổng hợp</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--general"></div>
        <div class="item__text">Ngân sách</div>
      </router-link>

      <router-link class="menu__items" to="/empl">
        <div class="item__icon icon__sidebar--report"></div>
        <div class="item__text">Phân tích tài chính</div>
      </router-link> -->
    </div>

    <div class="full__license">
      <div
        class="license__info icon__license--top license__info--lst"
        @click="clickIconLicense"
      >
        <div class="icon__license">
          <div class="first__line"></div>
          <div class="second__line"></div>
        </div>
      </div>

      <div>
        <div class="license__content license__lst">
          <div class="license__title">Gói Ultimate</div>
          <div class="license__sub">
            Hạn dùng :
            <span>31/08/2030</span>
          </div>
          <div class="license__about">Gia hạn ngay!</div>
          <div class="license__about">Thông tin gói</div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import Popper from "vue3-popper";

export default {
  name: "TheNavbar",
  components: {
    Popper,
  },

  data() {
    return {
      items: [
        { icon: "icon__dashboard", text: "Tổng quan", torouter: "dashboard" },
        { icon: "icon__sidebar--bank", text: "Tiền mặt", torouter: "bank" },
        { icon: "icon__sidebar--cash", text: "Tiền gửi", torouter: "cash" },
        { icon: "icon__shopping", text: "Mua hàng", torouter: "shopping" },
        { icon: "icon__sale", text: "Bán hàng", torouter: "sale" },
        {
          icon: "icon__sidebar--invoice",
          text: "Quản lý hóa đơn",
          torouter: "invoice",
        },
        { icon: "icon__sidebar--stock", text: "Kho", torouter: "stock" },
        {
          icon: "icon__sidebar--tools",
          text: "Công cụ dụng cụ",
          torouter: "tools",
        },
        {
          icon: "icon__sidebar--fixed",
          text: "Tài sản cố định",
          torouter: "fixed",
        },
        { icon: "icon__sidebar--tax", text: "Thuế", torouter: "tax" },
        { icon: "icon__sidebar--price", text: "Giá thành", torouter: "price" },
        {
          icon: "icon__sidebar--general",
          text: "Tổng hợp",
          torouter: "general",
        },
        {
          icon: "icon__sidebar--budget",
          text: "Ngân sách",
          torouter: "budget",
        },
        { icon: "icon__sidebar--report", text: "Báo cáo", torouter: "report" },
        {
          icon: "icon__sidebar--finance",
          text: "Phân tích tài chính",
          torouter: "finance",
        },
      ],
    };
  },

  methods: {
    clickIconLicense() {
      document.querySelector(".full__license").addEventListener("click", () => {
        document
          .querySelector(".full__license")
          .classList.toggle("full__license--size");
        document
          .querySelector(".icon__license")
          .classList.toggle("icon__license--bot");
      });
    },
  },
};
</script>

<style scoped>
@import url("../../styles/layout/TheNavBar.css");
@import url("../../styles/icon/icon.css");

.inline-block {
  display: block;
}
.moon-fes-sidebar:before {
  content: "";
  position: absolute;
  top: 48px;
  left: 0;
  width: 100%;
  height: calc(100vh - 48px);
  opacity: 0.6;
  background: url("../../assets/img/bg_trung_thu.00497630.png") no-repeat bottom;
  background-size: contain;
  background-color: rgb(57, 58, 61);
}
:deep(.popper) {
  background: #000;
  padding: 4px 10px;
  color: #fff;
  font-size: 11px;
  text-transform: uppercase;
  border-radius: 4px;
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
