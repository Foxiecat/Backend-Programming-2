using AWSUploadFileS3API.Services;
using AWSUploadFileS3API.Services.Interfaces;

namespace AWSUploadFileS3API.Endpoints;

public static class AWSS3UploadFileEndpoints
{
    public static void MapAWSS3UploadFileEndpoints(this WebApplication app)
    {
        RouteGroupBuilder awsGroup = app.MapGroup("/aws-s3");

        awsGroup.MapPost("/upload-file", UploadFile)
            .WithName("UploadFile")
            .WithOpenApi()
            .DisableAntiforgery();

        awsGroup.MapDelete("/delete-file", DeleteFile)
            .WithName("DeleteFile")
            .WithOpenApi();

        awsGroup.MapPost("/create-bucket", CreateBucket)
            .WithName("CreateBucket")
            .WithOpenApi();

        awsGroup.MapDelete("/delete-bucket", DeleteBucket)
            .WithName("DeleteBucket")
            .WithOpenApi();
    }

    private static async Task<IResult> UploadFile(
        IAwsS3Service awsS3Service,
        IFormFile file, 
        string bucketName)
    {
        var response = await awsS3Service.UploadFileAsync(file, bucketName);
        return Results.Ok(response);
    }

    private static async Task<IResult> DeleteFile(
        IAwsS3Service awsS3Service,
        string fileName,
        string bucketName)
    {
        var response = await awsS3Service.DeleteFileAsync(fileName, bucketName);
        return Results.Ok(response);
    }

    private static async Task<IResult> CreateBucket(IAwsS3Service awsS3Service, string bucketName)
    {
        var response = await awsS3Service.CreateBucketAsync(bucketName);
        return Results.Ok(response);
    }
    
    private static async Task<IResult> DeleteBucket(IAwsS3Service awsS3Service, string bucketName)
    {
        var response = await awsS3Service.DeleteBucketAsync(bucketName);
        return Results.Ok(response);
    }
}