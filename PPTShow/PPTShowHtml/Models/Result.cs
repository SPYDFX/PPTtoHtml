using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPTShowHtml.Models
{
    public class Result<T>
    {
        public string msg { get; set; }
        public bool success { get; set; }
        public T data { get; set; }
    }


    public class BaseResult
    {
        public string msg { get; set; }
        public bool success { get; set; }
    }
    public class PersonRsult : BaseResult
    {

    }

}