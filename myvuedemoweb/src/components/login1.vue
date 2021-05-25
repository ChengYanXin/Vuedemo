<template>  
    <el-table
      :data="builds"
      style="width:100%">   

      <el-table-column
        prop="bid"
        label="日期"
        width="180">
      </el-table-column>
      <el-table-column
        prop="bname"
        label="姓名"
        width="180">
      </el-table-column>
      <el-table-column
        prop="bfloorheight"
        label="地址">
      </el-table-column>
      <el-table-column
      label="操作">
      <el-button>删除</el-button>
      </el-table-column>
    </el-table>
</template>
<script>
import axios from 'axios'

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
  }, methods:{
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
    }
  }
}
</script>

