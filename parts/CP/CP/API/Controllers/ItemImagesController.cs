using CP.Data;
using CP.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace CP.API.Controllers
{
    public class ImageDataFormatter : MediaTypeFormatter
    {
        public ImageDataFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("multipart/form-data"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(ImageUploadRequest);
        }

        public override bool CanWriteType(Type type)
        {
            return false;
        }

        public async override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            return await base.ReadFromStreamAsync(type, readStream, content, formatterLogger);
        }


    }


    public class ImageUploadRequest
    {
        public string FileName { get; set; }
        public string MediaType { get; set; }
        public byte[] Buffer { get; set; }

        public ImageUploadRequest(string fileName, string mediaType, byte[] imagebuffer)
        {
            FileName = fileName;
            MediaType = mediaType;
            Buffer = imagebuffer;
        }
    }

    public class ItemImagesController : ApiController
    {
        [Route("api/itemimages")]
        public async Task<HttpResponseMessage> PostItemImages()
        {
            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            await Request.Content.ReadAsMultipartAsync(provider);
            var files = HttpContext.Current.Request.Files;
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

       
        
    }
}
