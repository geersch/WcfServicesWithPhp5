using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.IO;

namespace CGeers.Wcf.Services
{
    [MessageContract]
    public class FileUploadInputParameter
    {
        [MessageHeader(MustUnderstand = true)]
        public string FileName { get; set; }

        [MessageHeader(MustUnderstand = true)]
        public int FileSize { get; set; }

        [MessageBodyMember(Order = 1)]
        public Stream Stream { get; set; }
    }
}
