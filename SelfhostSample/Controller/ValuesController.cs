using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using WebApiUtils;

namespace SelfhostSample.Controller
{
    public class ValuesController:ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "111", "222" };
        }

        [CrossSite(Enable = false)]
        public async Task<List<string>> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            List<string> files = new List<string>();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            string root = System.Environment.CurrentDirectory;
            var path = Path.Combine(root, "App_Data");
           ;//指定要将文件存入的服务器物理位置  
            var provider = new CustomMultipartFormDataStreamProvider(path);
            try
            {
                // Read the form data.  

                await Request.Content.ReadAsMultipartAsync(provider);
               
                // This illustrates how to get the file names.  
                files.AddRange(provider.FileData.Select(file => Path.GetFileName(file.LocalFileName)));
            }
            catch
            {
                throw;
            }
            return files;
        }
    }
}