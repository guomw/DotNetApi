using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ApiModel;
using ApiModel.Config;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    /// <summary>
    /// Class BasicController.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class BasicController : Controller
    {
        /// <summary>
        /// Gets or sets the serializer setting.
        /// </summary>
        /// <value>The serializer setting.</value>
        private JsonSerializerSettings serializerSetting { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicController"/> class.
        /// </summary>
        public BasicController()
        {
            serializerSetting = new JsonSerializerSettings();
            serializerSetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// Views the result.
        /// </summary>
        /// <returns>JsonResult.</returns>
        public JsonResult ViewResult()
        {
            return new JsonResult(new ResultModel(), serializerSetting);
        }
        /// <summary>
        /// Views the result.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult ViewResult(ApiStatusCode statusCode)
        {
            return new JsonResult(new ResultModel(statusCode), serializerSetting);
        }

        /// <summary>
        /// Views the result.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="description">The description.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult ViewResult(ApiStatusCode statusCode, string description)
        {
            return new JsonResult(new ResultModel(statusCode, description), serializerSetting);
        }
        /// <summary>
        /// Views the result.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="data">The data.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult ViewResult(ApiStatusCode statusCode, object data)
        {
            return new JsonResult(new ResultModel(statusCode, data), serializerSetting);
        }

        /// <summary>
        /// Views the result.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="description">The description.</param>
        /// <param name="data">The data.</param>
        /// <returns>JsonResult.</returns>
        public JsonResult ViewResult(ApiStatusCode statusCode, string description, object data)
        {
            return new JsonResult(new ResultModel(statusCode, description, data), serializerSetting);
        }

    }
}
