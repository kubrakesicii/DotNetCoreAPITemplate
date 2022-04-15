using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace API.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ImageHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ImageHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            List<string> imagePaths = new List<string>();
            try
            {
                if (httpContext.Request.Form.Files.Count() > 0)
                {
                    try
                    {
                        //httpContext.Request.Form.Files -> IFormFile türünde
                        foreach (var formFile in httpContext.Request.Form.Files)
                        {
                            var extension = Path.GetExtension(formFile.FileName);
                            var imageName = Guid.NewGuid() + extension;

                            var path = "";
                            var location = "";
                            path = Path.Combine("/Images/", imageName);
                            location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", imageName);

                            using (var fileStream = new FileStream(location, FileMode.Create))
                            {
                                await formFile.CopyToAsync(fileStream);
                            }

                            imagePaths.Add(path);                           
                        }

                        httpContext.Items["ImagePaths"] = imagePaths;
                        await _next(httpContext);
                    }
                    catch (Exception e)
                    {

                    }
                }
                else
                {
                    httpContext.Items["ImagePaths"] = imagePaths;
                    await _next(httpContext);
                }
            }
            catch (Exception e)
            {
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ImageHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseImageHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ImageHandlerMiddleware>();
        }
    }
}
