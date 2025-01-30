using System.Net;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;
using AWSUploadFileS3API.Configuraton;
using AWSUploadFileS3API.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace AWSUploadFileS3API.Services;

public class AwsS3ClientService(IAmazonS3 client, IOptions<AwsS3Settings> config) : IAwsS3Service
{
    public async Task<HttpStatusCode> UploadFileAsync(IFormFile file, string bucketName)
    {
        bool doesBucketExists = await AmazonS3Util.DoesS3BucketExistV2Async(client, bucketName);

        if (!doesBucketExists)
        {
            PutBucketRequest createBucketRequest = new()
            {
                BucketName = bucketName,
                UseClientRegion = true
            };
            await client.PutBucketAsync(createBucketRequest);
        }

        PutObjectRequest objectRequest = new()
        {
            BucketName = bucketName,
            Key = file.FileName,
            InputStream = file.OpenReadStream(),
            StorageClass = S3StorageClass.Standard
        };
        
        PutObjectResponse? response = await client.PutObjectAsync(objectRequest);
        return response.HttpStatusCode;
    }

    public async Task<HttpStatusCode> DeleteFileAsync(string fileName, string bucketName)
    {
        DeleteObjectRequest deleteObjectRequest = new()
        {
            BucketName = bucketName,
            Key = fileName,
        };

        var response = await client.DeleteObjectAsync(deleteObjectRequest);
        return response.HttpStatusCode;
    }

    public async Task<HttpStatusCode> CreateBucketAsync(string bucketName)
    {
        PutBucketRequest createBucketRequest = new()
        {
            BucketName = bucketName,
            UseClientRegion = true
        };
        
        var response = await client.PutBucketAsync(createBucketRequest);
        return response.HttpStatusCode;
    }

    public async Task<HttpStatusCode> DeleteBucketAsync(string bucketName)
    {
        DeleteBucketRequest deleteBucketRequest = new()
        {
            BucketName = bucketName
        };
        
        var response = await client.DeleteBucketAsync(deleteBucketRequest);
        return response.HttpStatusCode;
    }

    public async Task<IEnumerable<string>> ListBucketFilesUriAsync(string bucketName)
    {
        var response = await client.ListObjectsV2Async(new ListObjectsV2Request
        {
            BucketName = bucketName,
            Prefix = ""
        });

        throw new NotImplementedException();
    }
}