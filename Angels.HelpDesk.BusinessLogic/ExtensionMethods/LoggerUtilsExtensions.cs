using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Angels.HelpDesk.BusinessLogic.ExtensionMethods
{
    public static class LoggerUtilsExtensions
    {
        public static void LogDebugSerializer<T>(this ILogger logger, T message)
        {
            logger.LogDebug($"El objeto de tipo <{typeof(T).Name}> con contenido: {JsonSerializer.Serialize(message)}");
        }

        public static void LogDebugInMethod(this ILogger logger, string method)
        {
            logger.LogDebug($"Ingresamos al metodo: {method}");
        }

        public static void LogDebugInMethod(this ILogger logger, string method, params object[] parameters)
        {
            logger.LogDebug($"Ingresamos al metodo: {method} con los siguientes parametros");

            foreach (var parameter in parameters)
                logger.LogDebug($"Parametro:  {JsonSerializer.Serialize(parameter)}");
        }

        public static void LogDebugOutMethod(this ILogger logger, string method)
        {
            logger.LogDebug($"Salimos del metodo: {method}");
        }
    }
}
