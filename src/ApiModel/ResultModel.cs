using ApiModel.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace ApiModel
{
    /// <summary>
    /// 接口返回实体对象
    /// </summary>
    public class ResultModel
    {

        private string _statusText = "";
        private object _data = null;

        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 状态描述
        /// </summary>
        public string statusText { get { return _statusText; } set { _statusText = value; } }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get { return _data; } set { _data = value; } }
        /// <summary>
        /// 
        /// </summary>
        public ResultModel()
        {
            this.status = (int)ApiStatusCode.OK;
            this.statusText = GetEnumDescription<ApiStatusCode>(ApiStatusCode.OK.ToString());
            this.data = new object();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        public ResultModel(ApiStatusCode statusCode)
        {
            this.status = (int)statusCode;
            this.statusText = GetEnumDescription<ApiStatusCode>(statusCode.ToString());
            this.data = new object();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="description"></param>
        public ResultModel(ApiStatusCode statusCode, string description)
        {
            this.status = (int)statusCode;
            this.statusText = description;
            this.data = new object();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="description"></param>
        /// <param name="obj"></param>
        public ResultModel(ApiStatusCode statusCode, string description, object obj)
        {
            this.status = (int)statusCode;
            this.statusText = description;
            this.data = obj;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="obj"></param>
        public ResultModel(ApiStatusCode statusCode, object obj)
        {
            this.status = (int)statusCode;
            this.statusText = GetEnumDescription<ApiStatusCode>(statusCode.ToString());
            this.data = obj;
        }

        /// <summary>
        /// 获取枚举的注释
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        private  string GetEnumDescription<T>(string value) where T : new()
        {
            Type t = typeof(T);
            foreach (System.Reflection.MemberInfo mInfo in t.GetMembers())
            {
                
                if (mInfo.Name == value)
                {                    
                    foreach (Attribute attr in mInfo.GetCustomAttributes())
                    {
                        if (attr.GetType() == typeof(System.ComponentModel.DescriptionAttribute))
                        {
                            return ((System.ComponentModel.DescriptionAttribute)attr).Description;
                        }
                    }
                }
            }
            return "";
        }

    }
}
