using Microsoft.AspNetCore.Http;
using System.Diagnostics;

namespace SharedLibrary.Utilities
{
    public static class RequestValidationUtilities
    {
        public static bool ValidateRequest<T>(HttpRequest request, out T item) where T : class
        {
            bool valid = request.Headers.ContentLength != 0;

            valid = StreamUtilities.TryParseStream<T>(request.Body, out item);

            return valid;
        }
    }
}
