using System;
using Bottom_botV2.Utils;

namespace Bottom_botV2.Classes
{
    class RandomMessages
    {
        private static string[] listCharacters, listAtks, listEngrish;
        private static Noelzisses[] listNoelzisses;

        public RandomMessages() {
            listNoelzisses = Constants.kListResponseMessages;
            listCharacters = Constants.kListSmashCharacters;
            listAtks = Constants.kListSmashAttacks;
            listEngrish = Constants.kListEngrish;
        }

        public string GetNewMessage(string username)
        {
            Random randomizer = new Random();
            int indexMessage = randomizer.Next(0, listNoelzisses.Length);
            string newMessage = listNoelzisses[indexMessage].message;
            bool canEngrish = listNoelzisses[indexMessage].canRdmEngrish;

            if (canEngrish)
            {
                int checkEngrish = randomizer.Next(0, 4);       //Decides if the message will be modified based on a 25% random chance
                if(checkEngrish == 0)                           //25% chance happened
                {
                    int indexEngrish = randomizer.Next(0, listEngrish.Length);
                    string engrish = listEngrish[indexEngrish] + ", ";

                    newMessage = char.ToLowerInvariant(newMessage[0]) + newMessage.Substring(1);
                    newMessage = engrish + newMessage;
                }
            }

            if(newMessage.Contains("*CHAR*"))
            {
                int indexChar = randomizer.Next(0, listCharacters.Length);
                string selectedChar = listCharacters[indexChar];

                newMessage = newMessage.Replace("*CHAR*", selectedChar);
            }

            if (newMessage.Contains("*ATK*"))
            {
                int indexAtk = randomizer.Next(0, listAtks.Length);
                string selectedAtk = listAtks[indexAtk];

                newMessage = newMessage.Replace("*ATK*", selectedAtk);
            }

            if (newMessage.Contains("*USER*"))
            {
                newMessage = newMessage.Replace("*USER*", username);
            }

            return newMessage;
        }
    }
}
