<template>
  <div >
      楼栋名称：<input type="text" v-model="bulidName">
      楼栋层高：<input type="text" v-model="buildHigh" >
      楼栋地址：<input type="text" v-model="buildAddres">
    <button type="primary" @click="addItem()">添加数据</button>
       <router-link to="/">返回上一级</router-link>
  </div>
</template>
<script>
import axios from 'axios'

export default {
    data:function(){
      return{
          bulidName:"",
          buildHigh:"",
          buildAddres:""

      }
    },
    methods:{
        addItem(){         
          if(!this.bulidName)
          {
            alert("请输入相关信息！");
            return false;
          }
            axios.post('http://localhost:5000/api/build/Insertbuild',{bulidName:this.bulidName,buildHigh:this.buildHigh,buildAddres:this.buildAddres})
            .then(res => {
                    alert("添加成功")             
                    console.log(res)

                
                
            })
            .catch(err => {
                console.log(err)
            })
        },        
        gotolink:function(){

            this.$router.replace('/')
        }
    }

 }

    
</script>
