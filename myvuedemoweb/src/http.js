import axios from 'axios';
axios.defaults.baseURL="http://localhost:5000/";
axios.defaults.timeout=10000;
axios.defaults.headers.post['Content-Type'] = 'application/json';
axios.defaults.headers.put['Content-Type'] = 'application/json';

// export function get_axios(url,params){
//   axios.get(url,{params:params})
// }

// GET
export function axios_get(url,params){
    return new Promise(
        (resolve,reject)=>{
            axios.get(url,{params:params})
            .then(res=>{
                console.log("封装信息的的res",res)
                resolve(res.data)
            }).catch(err=>{
                reject(err.data)
            })
        }
    )
}
// POST
export function axios_post(url,data){
    return new Promise(
        (resolve,reject)=>{
            console.log(data)
            axios.post(url,data)
            .then(res=>{
                console.log("封装信息的的res",res)
                resolve(res.data)
            }).catch(err=>{
                reject(err.data)
            })
        }
    )
}
// PUT
export function axios_put(url,data){
    return new Promise(
        (resolve,reject)=>{
            console.log(data)
            axios.put(url,data)
            .then(res=>{
                console.log("封装信息的的res",res)
                resolve(res.data)
            }).catch(err=>{
                reject(err.data)
            })
        }
    )
}

// DELETE
export function axios_delete(url,params){
    return new Promise(
        (resolve,reject)=>{
            axios.delete(url,{params:params})
            .then(res=>{
                console.log("封装信息的的res",res)
                resolve(res.data)
            }).catch(err=>{
                reject(err.data)
            })
        }
    )
}