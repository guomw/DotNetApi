using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using ApiModel.Config;
using Microsoft.AspNetCore.Mvc;
using ApiModel;

namespace WebApi
{
    public class ApiAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Dictionary<string, object> prams = GetParams(context.HttpContext.Request);
            string requestSign = string.Empty;
            if (prams.ContainsKey("sign"))
                requestSign = prams["sign"].ToString();

            if (string.IsNullOrEmpty(requestSign))
            {
                //  return ApiStatusCode.未授权;
            }

            Dictionary<string, string> paramters = new Dictionary<string, string>();
            foreach (var item in prams)
            {
                if (item.Key != "sign" && !string.IsNullOrEmpty(item.Value.ToString()))
                {
                    paramters.Add(item.Key.ToLower(), WebUtility.UrlDecode(item.Value.ToString()));
                }
            }
            //string currentSign = SignatureHelper.BuildSign(paramters, ConstConfig.SECRET_KEY);
            //if (!requestSign.Equals(currentSign))
            //{
            //    // return ApiStatusCode.未授权;
            //    //filterContext.HttpContext.Response.StatusCode = (int)apiCode;
            //    context.Result = new JsonResult(new ResultModel(ApiStatusCode.未授权));
            //    return;
            //}

        }



        /// <summary>
        /// 获取 get/post 数据
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        private Dictionary<string, object> GetParams(HttpRequest Request)
        {
            Dictionary<string, object> p = new Dictionary<string, object>();
            if (Request.Method.ToLower() == "post") //post 数据请求
            {
                IFormCollection values = Request.Form;
                foreach (string m in values.Keys)
                {

                    p.Add(m, WebUtility.UrlDecode(values[m]));
                }
            }
            else  //get 数据请求
            {
                string url = Request.PathBase.ToUriComponent();
                if (url == null || url == "")
                    return p;
                int questionMarkIndex = url.IndexOf('?');
                if (questionMarkIndex == url.Length - 1)
                    return p;
                string ps = url.Substring(questionMarkIndex + 1);
                if (ps != null && !string.IsNullOrEmpty(ps))
                {
                    ps = WebUtility.UrlDecode(ps);
                    // 开始分析参数对   
                    Regex re = new Regex(@"(^|&)?(\w+)=([^&]+)(&|$)?", RegexOptions.Compiled);
                    MatchCollection mc = re.Matches(ps);
                    foreach (Match m in mc)
                    {
                        p.Add(m.Result("$2"), WebUtility.UrlDecode(m.Result("$3")));
                    }
                }
            }
            return p;
        }
    }
}
