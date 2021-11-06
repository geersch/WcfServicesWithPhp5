using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace CGeers.Wcf.Services
{
    [MessageContract]
    public class FileUploadReturnValue
    {
        [MessageBodyMember(Order = 1)]
        public bool UploadSucceeded { get; set; }
    }
}
