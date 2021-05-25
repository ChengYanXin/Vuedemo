<template>
  <div class="build-list-pad">
    <router-link to="/">楼栋信息</router-link>&nbsp;&nbsp;
     <router-link to="/roomIndex">房间信息</router-link>&nbsp;&nbsp;
      <table>
            <el-input type="text" v-model="searchText" placeholder="请输入客户姓名"></el-input>
            <el-button type="primary"  @click="SearchCustomer">查询</el-button>
            <el-button @click="gotolink" class="btn btn-success">添加客户信息</el-button>
            <router-link></router-link>
              <tr>
                  <td>
                      <p>客户编号</p>
                  </td>
                  <td>
                      <p>客户姓名</p>
                  </td>
                  <td>
                      <p>客户电话</p>
                  </td>
                  <td>
                      <p>性别</p>
                  </td>
                     <td>
                      <p>邮箱</p>
                  </td
                  <td>
                      <p>操作</p>
                  </td>
              </tr>

            <tr v-for="cu in customers">
              <td class="room-info">
                <p class="c-rid">{{cu.cid}}</p>
              </td>
              <td>
                <p class="c-cname">{{cu.cname}}</p>
              </td>
              <td>
               <p class="c-telephone">{{cu.telephone}}</p>
              </td>
            <td>
                <p class="c-gender">{{cu.gender}}</p>
            </td>
            <td>
                <p class="c-email">{{cu.email}}</p>
            </td>
            <td>
                <el-button @click.prevent="remove(cu.cid)" class="btn btn-success">删除</el-button>
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
    customers:{
        cid:[],
        cname:[],
        telephone:[],
        gender:[],
        email:[]
    },
    searchText:""
    }
  },
  mounted(){
      this.getCustomer();
      this.SearchCustomer();
      this.remove();
  },
  methods:{
    getCustomer:function(FuncsearchCustomer){
      var that=this;
      axios.get("http://localhost:5000/api/Customer/Getcustomers").then(function(res){
        that.customers=res.data;

        if(FuncsearchCustomer!=null)
        {
            FuncsearchCustomer();
        }
      })
    },
    SearchCustomer:function(){
            this.getCustomer(this.searchByText)
    },
    searchByText(){
        if(this.searchText!="")
        {           
             this.customers=this.customers.filter(c=>c.cname.includes(this.searchText));
        }
    },
    gotolink:function(){
        this.$router.replace('/addcustomer')
    },
    remove(index){
         var context = this;
        axios.delete('http://localhost:5000/api/Customer/DelCustomerS?id='+index)
        .then(res => {
           alert("删除成功");
           context.getCustomer();
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