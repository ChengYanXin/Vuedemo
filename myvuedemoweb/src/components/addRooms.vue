<template>
  <div >
      房间楼层：<input type="text" v-model="rfloor">
      所属楼栋：<input type="text" v-model="bid" >
      房间面积：<input type="text" v-model="rarea">
    <button type="primary" @click="addItem()">添加数据</button>
    <router-link to="/roomIndex">返回上一级</router-link>
  </div>
</template>
<script>
import axios from 'axios'

export default {
    data:function(){
      return{
          rfloor:"",
          bid:"",
          rarea:""

      }
    },
    methods:{
        addItem(){         
          if(!this.rfloor)
          {
            alert("请输入相关信息！");
            return false;
          }
            axios.post('http://localhost:5000/api/room/InsertRooms',{rfloor:this.rfloor,bid:this.bid,rarea:this.rarea})
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
