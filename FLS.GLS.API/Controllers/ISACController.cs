using Domain.Entities;
using FluentFTP;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.IO;
using System.Net;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace FLS.GLS.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ISACController : ControllerBase
    {
        //[HttpPost("uploadFile")]
        //public IActionResult UploadFile([FromForm] FileUploadRequest uploadRequest)
        //{
        //    //var path = "/tst/";

        //    //using var con = new FtpClient("192.168.105.12", "ftpu", "cse");
        //    //con.Connect();

        //    //var items = con.GetListing(path);
        //    //foreach (FtpListItem item in items)
        //    //{

        //    //    if (item.Type == FtpObjectType.File)
        //    //    {
        //    //        Console.WriteLine($"f {item.Name}");
        //    //    }
        //    //    else if (item.Type == FtpObjectType.Directory)
        //    //    {
        //    //        Console.WriteLine($"d {item.Name}");
        //    //    }
        //    //    else
        //    //    {
        //    //        Console.WriteLine($"{item.Name}");
        //    //    }
        //    //}

        //    // Validate credentials

        //    // FTP configuration
        //    //string ftpServer = "192.168.102.120";
        //    //string ftpUsername = uploadRequest.LoginId;
        //    //string ftpPassword = uploadRequest.Password;

        //    //// Upload file to FTP site
        //    //using (var ftpClient = new FtpClient(ftpServer, ftpUsername, ftpPassword))
        //    //{
        //    //    ftpClient.Connect();

        //    //    // Set the current directory on the FTP server
        //    //    ftpClient.SetWorkingDirectory("/");

        //    //    // Upload the file to the FTP server
        //    //    using (var fileStream = uploadRequest.UploadFile.OpenReadStream())
        //    //    {
        //    //        //ftpClient.UploadStream(fileStream, Path.GetFileName(uploadRequest.UploadFile.FileName));
        //    //        ftpClient.UploadStream(fileStream, "/news/test/");

        //    //    }

        //    //    // Disconnect from the FTP server
        //    //    ftpClient.Disconnect();
        //    //}

        //    ////////////////////////////////////////
        //    //if (uploadRequest.UploadFile == null || uploadRequest.UploadFile.Length == 0)
        //    //{
        //    //    return BadRequest("No file selected.");
        //    //}

        //    //string ftpServerUrl = "ftp://192.168.105.12";
        //    //string remotePath = "/tst/";

        //    //string filePath = Path.GetTempFileName(); 
        //    //using (var stream = new FileStream(filePath, FileMode.Create))
        //    //{
        //    //    uploadRequest.UploadFile.CopyTo(stream);
        //    //}

        //    //UploadFileToFtp(filePath, ftpServerUrl, uploadRequest.LoginId, uploadRequest.Password, remotePath);


        //    //////////////////////////////////////////////////////
        //    ///

        //    // Get the file name from the IFormFile object
        //    string fileName = uploadRequest.UploadFile.FileName;

        //    // Create the FTP request
        //    FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + uploadRequest.UploadPath + "/" + fileName);
        //    request.Method = WebRequestMethods.Ftp.UploadFile;
        //    request.Credentials = new NetworkCredential(uploadRequest.LoginId, uploadRequest.Password);

        //    // Read the file into a byte array
        //    byte[] fileContents;
        //    using (var ms = new MemoryStream())
        //    {
        //        uploadRequest.UploadFile.CopyToAsync(ms);
        //        fileContents = ms.ToArray();
        //    }

        //    // Write the file contents to the FTP server
        //    using (Stream requestStream = request.GetRequestStream())
        //    {
        //        requestStream.Write(fileContents, 0, fileContents.Length);
        //    }

        //    // Get the FTP response
        //    using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        //    {
        //        Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
        //    }

        //    //return Ok("File uploaded successfully");
        //    return Ok(DateTime.Now.ToString("yyyyMMddHHmm"));
        //}


    }
}
