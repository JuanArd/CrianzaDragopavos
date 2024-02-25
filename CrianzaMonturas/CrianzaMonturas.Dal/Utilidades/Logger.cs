using System.Reflection;

namespace CrianzaMonturas.Dal.Utilidades
{
    public static class Logger
    {
        private static string ObtenerNombreArchivo()
        {
            var proyecto = Assembly.GetEntryAssembly()?.GetName().Name ?? "Desconocido";
            var nombreProyecto = string.Join("_", proyecto!.Split(Path.GetInvalidFileNameChars()));
            var fecha = DateTime.Now.ToString("yyyy-MM-dd");

            return $"C:\\Log\\{nombreProyecto}\\log_{fecha}.log";

        }

        public static void WriteLog(string message)
        {
            using (var writer = new StreamWriter(ObtenerNombreArchivo(), true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] - {message}");
            }
        }

    }
}
