/*using Firebase.Service.Interfaces;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebase.Service.Services
{
    public class FirebaseStorageService : IFirebaseStorageService
    {
        //Bring this to appsetting.json
        private static string bucket = "swpbackup-71685.appspot.com";

        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var cancellation = new CancellationTokenSource();
            var task = new FirebaseStorage(bucket)
                        .Child("course_displayed_images")
                        .Child(fileName)
                        .PutAsync(fileStream, cancellation.Token);

            // await the task to wait until upload completes and get the download url
            var downloadUrl = await task;
            return downloadUrl;
        }
    }
}
*/