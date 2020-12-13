using System;
using Bottom_botV2.Utils;

namespace Bottom_botV2.Classes
{
    class RandomMessages
    {
        private static string[] listMessages, listCharacters;

        public RandomMessages() {
            listMessages = Constants.kListResponseMessages;
            listCharacters = Constants.kListSmashCharacters;
        }

        public string GetNewMessage(string username)
        {
            Random randomizer = new Random();
            int indexMessage = randomizer.Next(0, listMessages.Length);
            string newMessage = listMessages[indexMessage];

            if(newMessage.Contains("*CHAR*"))
            {
                int indexChar = randomizer.Next(0, listCharacters.Length);
                string selectedChar = listCharacters[indexChar];

                newMessage = newMessage.Replace("*CHAR*", selectedChar);
            }

            if(newMessage.Contains("*USER*"))
            {
                newMessage = newMessage.Replace("*USER*", username);
            }

            return newMessage;
        }
    }
}
