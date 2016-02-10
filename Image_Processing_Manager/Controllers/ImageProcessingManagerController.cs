using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Image_Processing_Manager.Controllers
{
    public class ImageProcessingManagerController : Controller
    {
        string uploadPath = "/Upload/";


        // GET: ImageProcessingManager
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImageProcessingManager/SameResolution
        [HttpGet]
        public ActionResult SameResolution()
        {
            return View();
        }


        // POST: ImageProcessingManager/SameResolution
        [HttpPost]
        public ActionResult SameResolution(HttpPostedFileBase[] MyImage)
        {
            // upload image file to server
            string fullImageName = "";
            string filePath = "";

            if (MyImage != null && MyImage[0] != null && MyImage[0].ContentLength > 0)
            {
                fullImageName = Guid.NewGuid().ToString() + Path.GetExtension(MyImage[0].FileName);
                filePath = Path.Combine(Server.MapPath(uploadPath), fullImageName);

                // Image compression and conversion
                var stream = new MemoryStream();
                MyImage[0].InputStream.CopyTo(stream);

                // Working Good
                Image original = Image.FromStream(stream);
                //var hres = original.HorizontalResolution;
                //var vres = original.VerticalResolution;
                original.Save(filePath);

                //// Working Good, You set the resolution
                //Bitmap bm = new Bitmap(stream);
                //bm.SetResolution(300, 300);
                //bm.Save(filePath);
            }

            return View();
        }
    }
}