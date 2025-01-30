using Amazon.Lambda.Core;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Util;

namespace AWSImportFileLambda;

internal static class AwsS3BucketHandler
{
    public static async Task<bool> CreateBucketIfNotExistsAsync(
        ILambdaContext context, IAmazonS3 client, string bucketName)
    {
        var doesBucketExist = await AmazonS3Util.DoesS3BucketExistV2Async(client, bucketName);
        if (!doesBucketExist)
        {
            context.Logger.LogInformation("Bucket does not exist, creating bucker '{bucketName}'", bucketName);
            PutBucketRequest createBucketRequest = new()
            {
                BucketName = bucketName,
                UseClientRegion = true
            };
            await client.PutBucketAsync(createBucketRequest);
            return true;
        }
        
        return false;
    }

    public static async Task<bool> CopyS3FileAsync(
        ILambdaContext context,
        IAmazonS3 client,
        string sourceBucketName,
        string sourceKey,
        string destinationBucketName,
        string destinationKey)
    {
        var response = await client.CopyObjectAsync(
            new CopyObjectRequest
            {
                SourceBucket = sourceBucketName,
                SourceKey = sourceKey,
                DestinationBucket = destinationBucketName,
                DestinationKey = destinationKey
            });

        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            context.Logger.LogInformation(
                "Copied file '{sourceKey}' from bucket '{sourceBucketName}' to bucket '{destinationBucketName}'", 
                sourceKey, sourceBucketName, destinationBucketName);
            return true;
        }

        return false;
    }

    public static async Task<bool> DeleteS3FileAsync(
        ILambdaContext context,
        IAmazonS3 client,
        string bucketName,
        string objectKey)
    {
        var response = await client.DeleteObjectAsync(
            new DeleteObjectRequest
            {
                BucketName = bucketName,
                Key = objectKey
            });

        if (response.HttpStatusCode == System.Net.HttpStatusCode.OK)
        {
            context.Logger.LogInformation("Deleted file '{objectKey} from bucket '{bucketName}'", objectKey, bucketName);
            return true;
        }
        return false;
    }
}