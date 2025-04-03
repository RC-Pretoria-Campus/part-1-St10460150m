using System.Speech.Synthesis;
using System.Threading;
using System;


namespace Chatbot.apk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Display ASCII Art Logo
            Console.Clear();
            Console.WriteLine(@"
  ██████╗██╗   ██╗██████╗ ███████╗███████╗███████╗
 ██╔════╝██║   ██║██╔══██╗██╔════╝██╔════╝██╔════╝
 ██║     ██║   ██║██████╔╝█████╗  █████╗  ███████╗
 ██║     ██║   ██║██╔══██╗██╔══╝  ██╔══╝  ╚════██║
 ╚██████╗╚██████╔╝██████╔╝███████╗███████╗███████║
  ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝╚══════╝╚══════╝

       CYBERSECURITY AWARENESS BOT
");
            Console.ResetColor();

            // Voice greeting
            PlayVoiceGreeting();

            Console.ResetColor();

            // Ask for the user's name
            string userName = "";
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter your name: ");
                Console.ResetColor();
                userName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(userName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Chatbot: Please enter a valid name.");
                    Console.ResetColor();
                }
            }

            // Display a welcome message with ASCII art
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n**************************************");
            Console.WriteLine("*  WELCOME TO THE CHATBOT, " + userName.ToUpper() + "!  *");
            Console.WriteLine("**************************************\n");
            Console.ResetColor();
            SimulateTyping("I'm here to assist you. How can I help today?\n");

            // Basic response system
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("You: ");
                Console.ResetColor();
                string userInput = Console.ReadLine().Trim().ToLower();

                Console.ForegroundColor = ConsoleColor.Cyan;

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    SimulateTyping("Chatbot: Please enter a valid question.\n");
                }
                else if (userInput == "how are you?")
                {
                    SimulateTyping("Chatbot: I'm just a bot, but I'm here to help you stay safe online!\n");
                }
                else if (userInput == "what's your purpose?")
                {
                    SimulateTyping("Chatbot: My purpose is to provide cybersecurity awareness and tips to keep you safe.\n");
                }
                else if (userInput == "what can I ask you about?")
                {
                    SimulateTyping("Chatbot: You can ask me about password safety, phishing, and safe browsing.\n");
                }
                else if (userInput == "password safety")
                {
                    SimulateTyping("Chatbot: Always use a strong password with a mix of letters, numbers, and symbols. Enable two-factor authentication where possible!\n");
                }
                else if (userInput == "phishing")
                {
                    SimulateTyping("Chatbot: Be cautious of emails and messages asking for personal details. Verify links before clicking!\n");
                }
                else if (userInput == "safe browsing")
                {
                    SimulateTyping("Chatbot: Always check for HTTPS in URLs, avoid downloading files from unknown sources, and keep your software updated.\n");
                }
                else if (userInput == "exit")
                {
                    SimulateTyping("Chatbot: Goodbye! Stay safe online.\n");
                    break;
                }
                else
                {
                    SimulateTyping("Chatbot: I didn't quite understand that. Could you rephrase?\n");
                }
                Console.ResetColor();
            }
        }

        static void PlayVoiceGreeting()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Volume = 100;
            synth.Rate = 0;

            string greetingMessage = "Hello! Welcome to the CyberGuardBot. How can I assist you today?";
            Console.WriteLine(greetingMessage);
            synth.Speak(greetingMessage);
        }

        static void SimulateTyping(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
        }
    }
}
