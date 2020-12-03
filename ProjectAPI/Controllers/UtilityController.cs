using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        [HttpPost]
        [Route("uploadImages")]
        public IActionResult UploadImage()
        {
            var file = Request.Form.Files[0];
            var folderName = file.FileName.Split("|").ElementAt(0);
            var fileName = file.FileName.Split("|").ElementAt(1);
            var folderPath = Path.Combine("Images", folderName);
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderPath);
            //Create Folder 
            if (!Directory.Exists(pathToSave))
            {
                DirectoryInfo di = Directory.CreateDirectory(pathToSave);
            }
            var fullPath = Path.Combine(pathToSave, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            string imagePath = folderPath + "\\" + fileName;
            return Ok(new { imagePath });
        }

    }
}
