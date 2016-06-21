using System.Collections.Generic;
using System.Web.Http;

namespace SelfhostSample.Controller
{
    public class ValuesController:ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "111", "222" };
        }
    }
}