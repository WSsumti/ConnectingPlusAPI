using ConnectingPlusAPI.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MimeTypes;
using System.Threading.Tasks;

namespace ConnectingPlusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        IWebHostEnvironment _environment;
        IMimetype _mime;
        public FilesController(IWebHostEnvironment environment, IMimetype mime)
        {
            _environment = environment;
            _mime = mime;
        }
        [HttpPost("{foldername}/{filename}/{type}")]
        public async Task<IActionResult> PostToCloud(string foldername, string filename, string type)
        {
            try
            {
                foldername = foldername.Replace("--", "\\");
                var request = HttpContext.Request;
                if (request.Form.Files.Count > 0)
                {
                    foreach (var file in request.Form.Files)
                    {
                        var filePath = Path.Combine(_environment.ContentRootPath, foldername);
                        var sourceFile = Path.Combine(filePath, file.FileName);
                        if (!Directory.Exists(filePath))
                            Directory.CreateDirectory(filePath);
                        
                        if (!System.IO.File.Exists(filePath))
                        {
                            using (var ms = new MemoryStream())
                            {
                                await file.CopyToAsync(ms);
                                if (type == "image")
                                    System.IO.File.WriteAllBytes(Path.Combine(filePath, filename + ".png"), ms.ToArray());
                                else
                                    System.IO.File.WriteAllBytes(Path.Combine(filePath, filename + ".mp4"), ms.ToArray());

                            }
                        }
                        
                    }
                }
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet("{foldername}/{filename}")]
        public async Task<IActionResult> GetFileByName(string filename, string foldername)
        {
            try
            {
                foldername = foldername.Replace("--", "\\");
                var path = Path.Combine(_environment.ContentRootPath, foldername);
                if (!Directory.Exists(path))
                    return null;
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), foldername ,filename);
                var ms = new MemoryStream();

                using (var file = new FileStream(filePath, FileMode.Open))
                {


                    await file.CopyToAsync(ms);
                    //FormFile res = new FormFile(ms, 0, ms.Length, foldername + "/" + filename, filename)
                    //{
                    //    Headers = new HeaderDictionary(),
                    //    ContentType = "/"
                    //};
                    //return res;

                    ms.Position = 0;
                    var ext = Path.GetExtension(filePath).ToLowerInvariant();
                    var a = File(ms, _mime.GetMimeType()[ext], filename);
                    return a;
                }
                
            }
            catch (Exception)
            {
                return null;
            }
            
        }
        [HttpGet("{foldername}")]
        public string[] GetAllFilePath(string foldername)
        {
            foldername = foldername.Replace("--", "\\");
            try
            {
                var path = Path.Combine(_environment.ContentRootPath, foldername);
                if (!Directory.Exists(path))
                    return null;
                string[] paths = Directory.GetFiles(path);
                return paths;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
