using System.Text;

namespace CaesarCipher
{
    internal class Program
    {
        static Dictionary<int, char> _alpahbetDict = new Dictionary<int, char>();
        static void Main(string[] args)
        {
            for (char c = 'A'; c <= 'Z'; c++)
                _alpahbetDict[c - 64] = c;

            Console.WriteLine("Type \"CRYPT\" to crypt a text OR \"DECRYPT\" to decrypt it.");

            while (true)
            {
                var command = Console.ReadLine().ToUpper();
                var response = string.Empty;
                var offset = -1;
                switch (command)
                {
                    case "CRYPT":
                        offset = 3;
                        response = $"Crypted text: ";
                        break;
                    case "DECRYPT":
                        offset = -3;
                        response = $"Decrypted text: ";
                        break;
                    case "STOP":
                        return;
                    default: 
                        response = "Invalid command";
                        break;
                }

                if (offset == -1)
                {
                    Console.WriteLine(response);
                    continue;
                }

                response += DoWork(offset);
                
                Console.WriteLine(response);

            }
           
        }

        public static string DoWork(int offset)
        {
            var textLetters = Console.ReadLine()?.ToUpper().Where(x => !char.IsWhiteSpace(x)).ToArray();
            var userResponseText = new StringBuilder();
            char currentChar;

            foreach (var letter in textLetters)
            {
                var key = ((letter - 64) + offset) % 26;

                key = key == 0 ? 26 : key;

                var success = _alpahbetDict.TryGetValue(key, out currentChar);

                userResponseText.Append(currentChar);
            }

            return userResponseText.ToString();
        }

    }
}