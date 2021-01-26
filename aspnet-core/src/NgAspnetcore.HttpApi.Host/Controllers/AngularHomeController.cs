using System;
using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;
namespace NgAspnetcore.HttpApi.Host.Controllers
{
    public class AngularHomeController : AbpController
    {
        public ActionResult Index()
        {
            return File("index.html", "text/html");
        }
        [Route("/downlog/{key}")]
        [HttpGet]
        public ActionResult DownloadLog([FromRoute] string key)
        {
            // TODO replace this code with public private key exchange code infrastructure 
            if (key == "QSDFQSDFE1324103KX71WMPUX739f20c9f8ef4ABCSKFSQSDFQSDMKQSDIANV942")
            {
                using (var streamZip = new MemoryStream())
                {
                    var di = new DirectoryInfo("./Logs");
                    var logFiles = di.EnumerateFiles();
                    using (var zip = new ZipArchive(streamZip, ZipArchiveMode.Create, true))

                        foreach (var file in logFiles)
                        {
                            using (var stream = new FileStream(file.FullName, FileMode.Open, FileAccess.Read,
                                FileShare.Delete | FileShare.ReadWrite))
                            {
                                var zipArchiveEntry = zip.CreateEntry(Path.GetFileName(file.FullName),
                                    CompressionLevel.Optimal);
                                using (var destination1 = zipArchiveEntry.Open())
                                {
                                    stream.CopyTo(destination1);
                                }
                            }
                        }
                    streamZip.Flush();
                    streamZip.Seek(0, SeekOrigin.Begin);
                    streamZip.Dispose();
                    return File(streamZip.ToArray(), "application/zip", "log" + DateTime.Now.ToString("yyyy-MM-dd--hh-mm") + ".zip");
                }
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
