using Amazon.S3;
using AWSUploadFileS3API.Configuraton;
using AWSUploadFileS3API.Endpoints;
using AWSUploadFileS3API.Services;
using AWSUploadFileS3API.Services.Interfaces;
using Scalar.AspNetCore;

namespace AWSUploadFileS3API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAWSService<IAmazonS3>();
        builder.Services.AddScoped<IAwsS3Service, AwsS3ClientService>();
        
        builder.Services.Configure<AwsS3Settings>(builder.Configuration.GetSection("AwsS3Settings"));

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.MapScalarApiReference();
        }

        app.MapAWSS3UploadFileEndpoints();
        
        app.UseHttpsRedirection();
        app.Run();
    }
}