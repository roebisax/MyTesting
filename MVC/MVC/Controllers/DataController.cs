using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MVC.Controllers
{

    public class ListExtensions
    {
    }

    public class DataController : ControllerBase
    {
        [HttpGet]
        //[Route("Zufall")]
        public ActionResult<User> Random()
        {

            return new User() { login = "ll", name = "nn", id=1 };
        }

        [HttpGet]
        //[Route("Zufall")]
        public int Index()
        {

            return 1;
        }
    }



    public class User : ModelBase
    {
        public string name { set; get; }

        public string login { set; get; }



    }

    public class ModelBase
    {
        internal int id { set; get; }
    }
}
