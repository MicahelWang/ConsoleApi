using System.Collections.Generic;
using System.Web.Http;

namespace OwinSelfhostSample.Controller
{
    public class ValuesController:ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "111", "222" };
        }
    }
}