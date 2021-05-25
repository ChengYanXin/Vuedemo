<template>
  <div >
      客户名称：<input type="text" v-model="cname">
      客户电话：<input type="text" v-model="telephone" >
      客户性别：<input type="text" v-model="gender">
      客户邮箱：<input type="text" v-model="email">
    <button type="primary" @click="addItem()">添加数据</button>
    <router-link to="/customerIndex">返回上一级</router-link>
  </div>
</template>
<script>
import axios from 'axios'

export default {
    data:function(){
      return{
          cname:"",
          telephone:"",
          gender:"",
          email:""

      }
    },
    methods:{
        
        addItem(){         
            if(!this.cname){
                    alert('请输入相关信息！')
                    return false;
                }
            axios.post('http://localhost:5000/api/Customer/InsertRooms',{cname:this.cname,telephone:this.telephone,gender:this.gender,email:this.email})
            .then(res => {
                    alert("添加成功")
                    console.log(res)
                
                    

                
                
            })
            .catch(err => {
                console.log(err)
            })
        },        
        gotolink:function(){

            this.$router.replace('/customerIndex')
        }
    }

 }

    
</script>
