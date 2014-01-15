using CloudStorageSample.Utils;
using Microsoft.WindowsAzure.StorageClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace CloudStorageSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CloudBlobContainer blobContainer = 
                CloudStorageHelper.GetCloudBlobContainer("client-images");

            List<string> blobs = new List<string>();
            foreach (var blobItem in blobContainer.ListBlobs())
                blobs.Add(blobItem.Uri.ToString());

            return View(blobs);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult Index_Post(HttpPostedFileBase fileBase)
        {
            if (fileBase.ContentLength > 0)
            {
                CloudBlobContainer blobContainer = 
                    CloudStorageHelper.GetCloudBlobContainer("client-images");
                
                CloudBlob blob = blobContainer.GetBlobReference(fileBase.FileName);
                blob.UploadFromStream(fileBase.InputStream);
            }

            return RedirectToAction("Index");
        }   
    }
}