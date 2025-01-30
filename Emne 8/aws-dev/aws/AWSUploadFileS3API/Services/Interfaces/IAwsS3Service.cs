using System.Net;

namespace AWSUploadFileS3API.Services.Interfaces;

public interface IAwsS3Service
{
    Task<HttpStatusCode> UploadFileAsync(IFormFile file, string bucketName);
    Task<HttpStatusCode> DeleteFileAsync(string bucketName, string fileName);
    Task<HttpStatusCode> CreateBucketAsync(string bucketName);
    Task<HttpStatusCode> DeleteBucketAsync(string bucketName);
    
    Task<IEnumerable<string>> ListBucketFilesUriAsync(string bucketName);
}