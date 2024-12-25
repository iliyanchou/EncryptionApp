namespace Crypt
{
    class Program
    {
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            CenterText("Welcome to EncryptionApp");
            CenterText("Press any key to continue....");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            bool ischoiceInvalid = true;
            string choice = "";
            while (ischoiceInvalid)
            {
                Console.Write("Do you want to crypth or decrypth a message? C/D : ");
                choice = Console.ReadLine().ToUpper();
                if (choice == "C" || choice == "D")
                {
                    ischoiceInvalid = false;
                }
                else
                {
                    Console.WriteLine("You have entered an invalid choice!");
                    ischoiceInvalid = true;
                }
            }
            bool isKeyInvalid = true;

            while (isKeyInvalid)
            {
                Console.Write("Insert a encryption key: ");
                string key = Console.ReadLine();
                char[] keyChars = key.ToCharArray();
                if (keyChars.Length == 0)
                {
                    isKeyInvalid = true;
                }
                else
                {
                    isKeyInvalid = false;

                int[] asciKey = new int[keyChars.Length];
                for (int i = 0; i < keyChars.Length; i++)
                {
                    asciKey[i] = (int)keyChars[i];
                }
                int keyValue = 0;
                foreach (int element in asciKey)
                {
                    keyValue += element;
                }
                    if (choice == "C")
                    {
                        Console.WriteLine("Insert message to encrypth: ");
                        string message = Console.ReadLine();
                        char[] messageChars = message.ToCharArray();
                        int[] asciMessage = new int[messageChars.Length];
                        for (int i = 0; i < asciMessage.Length; i++)
                        {
                            asciMessage[i] = (int)(messageChars[i]);
                        }
                        for (int i = 0; i < asciMessage.Length; i++)
                        {
                            asciMessage[i] *= keyValue;
                            asciMessage[i] += asciKey[0];
                            asciMessage[i] -= asciKey[asciKey.Length - 1];
                        }
                        Console.WriteLine("Your encrypted message is : ");
                        foreach (int element in asciMessage)
                        {
                            Console.Write(element + "-");
                        }
                    }
                    else if (choice == "D")
                    {
                     
                        Console.WriteLine("Insert message to decrypth: ");
                        string message = Console.ReadLine();
                        char[] inputMessage = message.ToCharArray();
                        int countdash = 0;
                        for (int i = 0; i < inputMessage.Length; i++)
                        {
                            if (inputMessage[i] == '-')
                            {
                                countdash++;
                            }
                        }
                        int[] Decmessage = new int[inputMessage.Length - countdash];
                        string term = "";
                        for (int i = 0, j = 0; i < inputMessage.Length && j < Decmessage.Length; i++)
                        {
                            if (inputMessage[i] != '-')
                            {
                                term = term + inputMessage[i];
                            }
                            else if (inputMessage[i] == '-')
                            {
                                Decmessage[j] = int.Parse(term);
                                j++;
                                term = "";
                            }
                        }
                        for (int i = 0; i < Decmessage.Length; i++)
                        {
                            Decmessage[i] += asciKey[asciKey.Length - 1];
                            Decmessage[i] -= asciKey[0];
                            Decmessage[i] /= keyValue;
                        }
                        Console.WriteLine("You decrypted message is : ");
                        for (int i = 0; i < Decmessage.Length; i++)
                        {
                            Console.Write((char)Decmessage[i]);
                        }
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Thank you for using me!");
            Console.WriteLine("Press any key to close...");
            Console.ReadKey();



            static void CenterText(string text)
            {
                int windowWidth = Console.WindowWidth;
                int windowCenter = windowWidth / 2;
                int textWidth = text.Length;
                int textCenter = textWidth / 2;
                int textIncrement = windowCenter - textCenter;
                int spaces = windowCenter + textIncrement;
                spaces /= 2;
                spaces = (int)Math.Floor((decimal)spaces);
                for (int i = 0; i < spaces; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(text);
                Console.WriteLine();



            }
        }
    }
}
