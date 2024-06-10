using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class FileUploadRequest
    {
        public IFormFile UploadFile { get; set; }
        public string UploadPath { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
    }
}
