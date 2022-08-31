// const { defineConfig } = require('@vue/cli-service')
// module.exports = defineConfig({
//   transpileDependencies: true
// })

module.exports={
  devServer: {
    headers: { "Access-Control-Allow-Origin": "*" },
    proxy: "http://localhost:5262/",
  },
};
