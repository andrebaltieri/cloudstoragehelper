using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;

namespace CloudStorageSample.Utils
{
    public static class CloudStorageHelper
    {
        public static CloudBlobContainer GetCloudBlobContainer(string container, bool createContainerIfNotExists = false)
        {
            CloudStorageAccount storageAccount =
                CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=[ACCOUNTNAME];AccountKey=[ACCOUNTKEY]");

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer blobContainer = blobClient.GetContainerReference(container);
            
            if (blobContainer.CreateIfNotExist())
            {
                if (createContainerIfNotExists)
                    blobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });
                else
                    return null;
            }

            return blobContainer;
        }
    }
}

