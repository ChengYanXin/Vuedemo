<template>
  <div class="build-list-pad" style="width:100%">
     <router-link to="/roomIndex">房间信息</router-link>&nbsp;&nbsp;
     <router-link to="/customerIndex">客户信息</router-link>&nbsp;&nbsp;
      <table style="width:">
            <el-input type="text" v-model="searchText" placeholder="请输入姓名"></el-input>
            <el-button type="primary"  @click="SearchBuildings">查询</el-button>
            <el-button @click="gotolink" class="btn btn-success">添加信息</el-button>
              <tr>
                  <td>
                      <p>楼栋编号</p>
                  </td>
                  <td>
                      <p>楼栋名称</p>
                  </td>
                  <td>
                      <p>楼栋层高</p>
                  </td>
                  <td>
                      <p>楼栋地址</p>
                  </td>
                  <td>
                      <p>操作</p>
                  </td>
              </tr>

            <tr v-for="bu in builds">
              <td class="bulid-info">
                <p class="b-bid">{{bu.bid}}</p>
              </td>
              <td>
                <p class="b-bname">{{bu.bname}}</p>
              </td>
              <td>
               <p class="b-bfloorheight">{{bu.bfloorheight}}</p>
              </td>
            <td>
                <p class="b-blocation">{{bu.blocation}}</p>
            </td>
            <td>
                <el-button @click.prevent="remove(bu.bid)" class="btn btn-success">删除</el-button>
            </td>
            </tr>
          </table>
        </div>
    </el-container>
  </el-container>
</template>
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


<script>
import axios from 'axios';

export default {

  data:function(){
      return{
    builds:{
        bid:[],
        bname:[],
        bfloorheight:[],
        blocation:[]
    },
    searchText:""
    }
  },
  mounted(){
      this.getbuild();
      this.SearchBuildings();
      this.remove();
  },
  methods:{
    getbuild:function(FuncsearchBuild){
      var that=this;
      axios.get("http://localhost:5000/api/build/GetBuildings").then(function(res){
        that.builds=res.data;

        if(FuncsearchBuild!=null)
        {
            FuncsearchBuild();
        }
      })
    },
    SearchBuildings:function(){
            this.getbuild(this.searchByText)
    },
    searchByText(){
        if(this.searchText!="")
        {           
             this.builds=this.builds.filter(c=>c.bname.includes(this.searchText));
        }
    },
    gotolink:function(){
        this.$router.replace('/addInfo')
    },
    remove(index){
         var context = this;
        axios.delete('http://localhost:5000/api/build/DelBuildings?id='+index)
        .then(res => {
           alert("删除成功");
           context.getbuild();
        })
        .catch(err => {
            console.error(err); 
        })
    }
  }

}
</script>