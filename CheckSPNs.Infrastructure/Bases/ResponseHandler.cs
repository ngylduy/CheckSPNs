﻿using CheckSPNs.Infrastructure.Resources;

namespace CheckSPNs.Infrastructure.Bases;

public class ResponseHandler
{
    public Response<T> Deleted<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = Message == null ? SharedResourcesKeys.Deleted : Message
        };
    }
    public Response<T> Success<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.OK,
            Succeeded = true,
            Message = SharedResourcesKeys.Success,
            Meta = Meta
        };
    }
    public Response<T> Unauthorized<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized,
            Succeeded = true,
            Message = Message == null ? SharedResourcesKeys.UnAuthorized : Message
        };
    }
    public Response<T> BadRequest<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest,
            Succeeded = false,
            Message = Message == null ? SharedResourcesKeys.BadRequest : Message
        };
    }
    public Response<T> UnprocessableEntity<T>(string Message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.UnprocessableEntity,
            Succeeded = false,
            Message = Message == null ? SharedResourcesKeys.UnprocessableEntity : Message
        };
    }
    public Response<T> NotFound<T>(string message = null)
    {
        return new Response<T>()
        {
            StatusCode = System.Net.HttpStatusCode.NotFound,
            Succeeded = false,
            Message = message == null ? SharedResourcesKeys.NotFound : message
        };
    }
    public Response<T> Created<T>(T entity, object Meta = null)
    {
        return new Response<T>()
        {
            Data = entity,
            StatusCode = System.Net.HttpStatusCode.Created,
            Succeeded = true,
            Message = SharedResourcesKeys.Created,
            Meta = Meta
        };
    }
}
