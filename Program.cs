namespace ProfitCalculatorApp
{
    internal static class Program
    {
        /// <summary>
        /// Application startup begins here. WinForms uses a single STA thread
        /// because the UI message loop and controls depend on that model.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // This applies the default WinForms configuration for a modern .NET app,
            // including startup settings like DPI behavior.
            ApplicationConfiguration.Initialize();
            // HomeForm acts as the landing screen and the main coordinator for the app.
            Application.Run(new HomeForm());
        }
    }
}
