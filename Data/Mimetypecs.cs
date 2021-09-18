using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Data
{
    public class Mimetypecs : IMimetype
    {
        public IDictionary<string, string> GetMimeType()
        {
            return new Dictionary<string, string>
            {
                {".txt","text/plain"},
                {".pdf","application/pdf"},
                {".png","image/png" },
                {".jpg","image/jpeg" },
                {"jpeg","image/jpeg" },
                {".mp4","video/mp4" },
                {".flv", "video/x-flv" },
                {".m3u8","application/x-mpegURL" },
                {".ts","video/MP2T" },
                {".3gp","video/3gpp" },
                {".mov","video/quicktime" },
                {".avi","video/x-msvideo" },
                {".wmv","video/x-ms-wmv" },
            };
        }
    }
}
