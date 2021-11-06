using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace CGeers.Wcf.Services
{
    public class FileUploadService : IFileUploadService
    {
        private void SaveFile(string filename, Stream stream)
        {
            const int bufferSize = 2048;
            byte[] buffer = new byte[bufferSize];
            using (FileStream outputStream = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                int bytesRead = stream.Read(buffer, 0, bufferSize);
                while (bytesRead > 0)
                {
                    outputStream.Write(buffer, 0, bytesRead);
                    bytesRead = stream.Read(buffer, 0, bufferSize);
                }
                outputStream.Close();
            }
        }

        public bool Upload(Stream stream)
        {
            try
            {
                var filename = String.Format("{0}.dat", Guid.NewGuid());

                SaveFile(filename, stream);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }        

        public FileUploadReturnValue UploadWithMessageContract(FileUploadInputParameter file)
        {
            try
            {
                SaveFile(file.FileName, file.Stream);

                return new FileUploadReturnValue { UploadSucceeded = true };
            }
            catch (Exception)
            {
                return new FileUploadReturnValue { UploadSucceeded = false };
            }
        }
    }
}
