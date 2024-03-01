using System.Reflection;

namespace CrianzaMonturas.Dal.Utilidades
{
    public static class Logger
    {
        private static string _path = ObtenerNombreArchivo();

        private static string ObtenerNombreArchivo()
        {
            var proyecto = Assembly.GetEntryAssembly()?.GetName().Name ?? "Desconocido";
            var nombreProyecto = string.Join("_", proyecto!.Split(Path.GetInvalidFileNameChars())).Split('.')[0];
            var fecha = DateTime.Now.ToString("yyyy-MM-dd");

            return $"C:\\Log\\{nombreProyecto}\\log_{fecha}.log";

        }

        public static void WriteLog(string message)
        {
            var directoryPath = Path.GetDirectoryName(_path);
            if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath!);

            using (var writer = new StreamWriter(_path, true))
            {
                writer.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] - {message}");
            }
        }

    }
}
