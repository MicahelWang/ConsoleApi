using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApiUtils
{
    public class CustomMultipartFormDataStreamProvider : MultipartFormDataStreamProvider
    {
        public CustomMultipartFormDataStreamProvider(string path) : base(path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            var fileName= headers.ContentDisposition.FileName.Replace("\"", string.Empty);
            var name = headers.ContentDisposition.Name.Replace("\"", string.Empty);
            var type ="."+ fileName.Split('.').Last();
            //return name+".apk";
            return fileName;
        }
        
    }
}