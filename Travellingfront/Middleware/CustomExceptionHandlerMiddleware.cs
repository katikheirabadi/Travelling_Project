﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using TravellingCore.Exceptions;

namespace Travellingfront.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case ExistUserException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case RePaswordException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case DependencyException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case ExpiredException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ReapitException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break; 
                    case PassException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonSerializer.Serialize(new { message = error?.Message });
                await response.WriteAsync(result);
            }
        }
    }
}
