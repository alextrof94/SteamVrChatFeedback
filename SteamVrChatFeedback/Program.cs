using Microsoft.Win32;
using System.IO.Pipes;

namespace SteamVrChatFeedback
{
    internal static class Program
    {
        public static Dictionary<string, string> uriSchemeConfiguration = new System.Collections.Generic.Dictionary<string, string>() {
            { "UriScheme", "chatfeedback" },
            { "AppName", "SteamVrChatFeedback" }
        };

        private static readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private static Form1 mainForm;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argsIn)
        {
            bool createdNew;
            // Create a mutex to check if the application is already running
            using (Mutex mutex = new Mutex(true, uriSchemeConfiguration.GetValueOrDefault("AppName"), out createdNew))
            {
                if (createdNew)
                {
                    Application.ApplicationExit += (sender, e) => {
                        cancellationTokenSource.Cancel();
                    };

                    Task.Run(() => StartNamedPipeServer(cancellationTokenSource.Token));
                    // If this is the first instance, start your application
                    AssociateAppInRegister();
                    ApplicationConfiguration.Initialize();
                    Application.Run(mainForm = new Form1(argsIn));
                }
                else
                {
                    // If another instance is running, send the URI data to it
                    SendUriDataToExistingInstance(argsIn);
                }
            }
        }

        static async Task StartNamedPipeServer(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // Create a named pipe server to listen for data
                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(uriSchemeConfiguration.GetValueOrDefault("AppName"), PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous))
                {
                    try
                    {
                        await pipeServer.WaitForConnectionAsync(cancellationToken);

                        // Check for cancellation
                        if (cancellationToken.IsCancellationRequested)
                        {
                            return; // Exit the method if cancellation is requested
                        }

                        // Read data from the pipe asynchronously
                        using (StreamReader reader = new StreamReader(pipeServer))
                        {
                            string uriData = await reader.ReadToEndAsync();

                            // Handle the received data as needed
                            HandleReceivedData(uriData);
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        // Handle cancellation gracefully
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine("Failed to read from named pipe: " + ex.Message);
                    }
                }
            }
        }

        private static void HandleReceivedData(string uriData)
        {
            List<string> arguments = new List<string>(uriData.Split(' '));
            mainForm.GotNewArguments(arguments);
        }

        static void SendUriDataToExistingInstance(string[] args)
        {
            // Create a named pipe client to communicate with the existing instance
            using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", uriSchemeConfiguration.GetValueOrDefault("AppName"), PipeDirection.Out))
            using (StreamWriter writer = new StreamWriter(pipeClient))
            {
                try
                {
                    pipeClient.Connect();
                    writer.WriteLine(args.Length > 0 ? args[0] : "");
                    writer.Flush();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to send URI data to existing instance: " + ex.Message, "VrScreamer");
                }
            }
            Application.Exit();
        }

        private static void AssociateAppInRegister()
        {
            using (var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes", true))
            {
                string path = System.Reflection.Assembly.GetEntryAssembly().Location;
                path = path.Substring(0, path.LastIndexOf(".")) + ".exe";

                string keyName = uriSchemeConfiguration.GetValueOrDefault("UriScheme");

                bool needToAssociate = false;

                if (!key.GetSubKeyNames().Contains(keyName))
                    needToAssociate = true;

                if (!needToAssociate)
                {
                    string existingValue = (string)key.OpenSubKey($"{keyName}\\shell\\open\\command").GetValue(null, "");

                    if (existingValue != $"\"{path}\" \"%1\"")
                        needToAssociate = true;
                }

                if (needToAssociate)
                {
                    key.CreateSubKey(keyName).SetValue(null, "URL:" + keyName);
                    key.CreateSubKey(keyName).SetValue("URL Protocol", "");
                    key.CreateSubKey($"{keyName}\\shell\\open\\command").SetValue(
                        null,
                        $"\"{path}\" \"%1\"");
                }
            }
        }
    }
}