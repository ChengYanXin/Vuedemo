<template>
  <div class="build-list-pad">
     <router-link to="/">楼栋信息</router-link>&nbsp;&nbsp;
     <router-link to="/customerIndex">客户信息</router-link>&nbsp;&nbsp;

      <table>
            <el-input type="text" v-model="searchText" placeholder="请输入楼层，比如：6层"></el-input>
            <el-button type="primary"  @click="SearchRooms">查询</el-button>
            <el-button @click="gotolink" class="btn btn-success">添加房间信息</el-button>
            <router-link></router-link>
              <tr>
                  <td>
                      <p>房间编号</p>
                  </td>
                  <td>
                      <p>楼层</p>
                  </td>
                  <td>
                      <p>所属楼栋</p>
                  </td>
                  <td>
                      <p>房间面积</p>
                  </td>
                  <td>
                      <p>操作</p>
                  </td>
              </tr>

            <tr v-for="ro in rooms">
              <td class="room-info">
                <p class="r-rid">{{ro.rid}}</p>
              </td>
              <td>
                <p class="r-rfloor">{{ro.rfloor}}</p>
              </td>
              <td>
               <p class="r-bid">{{ro.bid}}</p>
              </td>
            <td>
                <p class="r-rarea">{{ro.rarea}}</p>
            </td>
            <td>
                <el-button @click.prevent="remove(ro.rid)" class="btn btn-success">删除</el-button>
            </td>
            </tr>
          </table>
        </div>
    </el-container>
  </el-container>
</template>


<script>
import axios from 'axios';

export default {

  data:function(){
      return{
    rooms:{
        rid:[],
        rfloor:[],
        bid:[],
        rarea:[]
    },
    searchText:""
    }
  },
  mounted(){
      this.getRoom();
      this.SearchRooms();
      this.remove();
  },
  methods:{
    getRoom:function(FuncsearchRoom){
      var that=this;
      axios.get("http://localhost:5000/api/room/Getrooms").then(function(res){
        that.rooms=res.data;

        if(FuncsearchRoom!=null)
        {
            FuncsearchRoom();
        }
      })
    },
    SearchRooms:function(){
            this.getRoom(this.searchByText)
    },
    searchByText(){
        if(this.searchText!="")
        {           
             this.rooms=this.rooms.filter(c=>c.rfloor.includes(this.searchText));
        }
    },
    gotolink:function(){
        this.$router.replace('/addRooms')
    },
    remove(index){
         var context = this;
        axios.delete('http://localhost:5000/api/room/DelRooms?id='+index)
        .then(res => {
            alert("删除成功");
           context.getRoom();
        })
        .catch(err => {
            console.error(err); 
        })
    }
  }

}
</script>
<style type="text/css">
			/*表格样式*/			
			table {
				width: 90%;
				background: #ccc;
				margin: 10px auto;
				border-collapse: collapse;/*border-collapse:collapse合并内外边距(去除表格单元格默认的2个像素内外边距*/	
			}				
			th,td {
				height: 25px;
				line-height: 25px;
				text-align: center;
				border: 1px solid #ccc;
			}		
			th {
				background: #eee;
				font-weight: normal;
			}		
			tr {
				background: #fff;
			}		
			tr:hover {
				background :#eee;
			}		
			td a {
				color: #06f;
				text-decoration: none;
			}		
			td a:hover {
				color: #06f;
				text-decoration: underline;
			}
		</style>