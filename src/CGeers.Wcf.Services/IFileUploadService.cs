using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;

namespace CGeers.Wcf.Services
{
    [ServiceContract]
    public interface IFileUploadService
    {
        [OperationContract]
        bool Upload(Stream stream);

        [OperationContract]
        FileUploadReturnValue UploadWithMessageContract(FileUploadInputParameter file);
    }
}
