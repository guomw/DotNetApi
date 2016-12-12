using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiModel;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    /// <summary>
    /// Class SystemController.
    /// </summary>
    /// <seealso cref="WebApi.Controllers.BasicController" />
    public class SystemController : BasicController
    {
        // GET: /<controller>/
        [ApiAuthorize]        
        public IActionResult Index()
        {
            return ViewResult();
        }
    }
}
