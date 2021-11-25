using System.Text;

namespace MyConsoleApplicationBase64
{
    public class TheApp
    {

        /// <summary>
        /// ClearScreen
        /// </summary>
        void ClearScreen()
        {
            Console.Clear();
        }

        /// <summary>
        /// ScreenOutput
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="foregroundColor"></param>
        /// <param name="backgroundColor"></param>
        void ScreenOutput(int x, int y, string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(text);
            Console.ResetColor();
        }
        void ScreenOutput(int x, int y, string text, ConsoleColor foregroundColor)
        {
            ScreenOutput(x, y, text, foregroundColor, ConsoleColor.Black);
        }
        void ScreenOutput(int x, int y, string text)
        {
            ScreenOutput(x, y, text, ConsoleColor.Gray);
        }
        void ScreenOutputWL(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        void ScreenOutputWL(string text, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        void ScreenOutputWL(string text)
        {
            Console.WriteLine(text);
            Console.ResetColor();
        }
        void ScreenOutput(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Write(text);
            Console.ResetColor();
        }
        void ScreenOutput(string text, ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.Write(text);
            Console.ResetColor();
        }
        void ScreenOutput(string text)
        {
            Console.Write(text);
            Console.ResetColor();
        }

        /// <summary>
        /// Run
        /// </summary>
        /// <param name="args"></param>
        public void Run(string[] args)
        {
            string config_type;
#if DEBUG
            config_type = "Debug";
#else
            config_type = "Release";
#endif
            ClearScreen();
            ScreenOutputWL($"Program {System.Reflection.Assembly.GetExecutingAssembly().GetName().Name} {config_type} Version {System.Reflection.Assembly.GetExecutingAssembly().GetName().Version}\n", ConsoleColor.Cyan);

            // Encoding
            string? password;
            ScreenOutputWL("Type in a password (any string) and press Return:");
            password = Console.ReadLine();
            if (String.IsNullOrEmpty(password))
                password = "MyPassword";
            ScreenOutput($"password: ", ConsoleColor.White);
            ScreenOutputWL($"{password}", ConsoleColor.DarkRed);

            byte[] plainTextBytes = System.Text.Encoding.UTF8.GetBytes(password);
            ScreenOutput($"password as byte[]: ", ConsoleColor.White);
            ScreenOutputWL($"{ByteArrayToHexString(plainTextBytes)}", ConsoleColor.Magenta);

            string passwordAsBase64 = System.Convert.ToBase64String(plainTextBytes);
            ScreenOutput($"passwordAsBase64 (password as Base64): ", ConsoleColor.White);
            ScreenOutputWL($"{passwordAsBase64}", ConsoleColor.Red);

            // Normal
            byte[] encodedTextBytes = Convert.FromBase64String(passwordAsBase64);
            ScreenOutput($"passwordAsBase64 as byte[]: ", ConsoleColor.White);
            ScreenOutputWL($"{ByteArrayToHexString(encodedTextBytes)}", ConsoleColor.Magenta);

            string plainText = Encoding.UTF8.GetString(encodedTextBytes);
            ScreenOutput($"plainText: ", ConsoleColor.White);
            ScreenOutputWL($"{plainText}", ConsoleColor.DarkRed);


            ScreenOutputWL("\npress any key to exit", ConsoleColor.Green);
            Console.ReadKey();
        }

        /// <summary>
        /// ByteArrayToHexString
        /// </summary>
        /// <param name="ba"></param>
        /// <param name="withDashes"></param>
        /// <returns></returns>
        public string ByteArrayToHexString(byte[] ba, bool withDashes = true)
        {
            if (!withDashes)
                return BitConverter.ToString(ba).Replace("-", "");
            else
                return BitConverter.ToString(ba).Replace("-", "-");
        }
    }
}
