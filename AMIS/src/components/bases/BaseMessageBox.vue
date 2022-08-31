<template>
  <div>
    <div class="Msg-warring">
      <div class="msgBox">
        <div class="msgBox-detail">
          <div class="msgBox-iconErr"></div>
          <div class="msgBox-content">{{message}}</div>
        </div>
        <div class="msgBox-button">
          <button @click="CloseMsg">Đóng</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
    export default{
        name: "MessageBox",
        props: ['isValidate','message'],
        methods:{
            CloseMsg(){
                this.$emit("CloseMsgBox",false)
            }
        }

    }

</script>
<style scoped>
.Msg-warring{
    position: absolute;
    width: 100vw;
    height: 100vh;
    background-color: rgb(0,0,0,0.3);
    display: flex;
    align-items: center;
    z-index: 1001;
    top: 0;
}

.msgBox {
    margin: 0 auto;
    width: 444px;
    height: 182px;
    background-color: #ffff;
    border-radius: 4px;
}
.msgBox-detail {
    padding-top: 32px;
    display: flex;
    margin-right: 32px;
    margin-left: 32px;
    align-items: center;
    width: 380px;
    padding-bottom: 13px;
    border-bottom: 1px solid #b8bcc3;
}
.msgBox-iconErr {
    background: url("../../assets/img/Sprites.64af8f61.svg") no-repeat -745px -456px;
    width: 48px;
    height: 48px;
}
.msgBox-content{
    margin-left: 20px;
    color: #111;
}

.msgBox-button{
    width: 100px;
    margin: 0 auto;
    display: flex;
    justify-content: center;
}
.msgBox-button button{
    margin-top: 21px;
    background-color: #2ca01c;
    border: none;
    color: white;
    padding: 8px 16px;
    border-radius: 2px;
    font-size: 13px;
    cursor: pointer;
}
.msgBox-button button:hover{
    background-color: #35bf22;
}
</style>
