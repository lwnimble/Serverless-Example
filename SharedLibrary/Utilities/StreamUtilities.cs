using Microsoft.Azure.Cosmos.Serialization.HybridRow;
using Newtonsoft.Json;

namespace SharedLibrary.Utilities
{
    public static class StreamUtilities
    {
        public static bool TryParseStream<T>(Stream stream, out T result)
        {
            bool success = true;
            var settings = new JsonSerializerSettings
            {
                Error = (sender, args) => { success = false; args.ErrorContext.Handled = true; },
                MissingMemberHandling = MissingMemberHandling.Error
            };

            using var streamReader = new StreamReader(stream);
            var content = streamReader.ReadToEnd();
            result = JsonConvert.DeserializeObject<T>(content, settings);
            return success;
        }
    }
}
