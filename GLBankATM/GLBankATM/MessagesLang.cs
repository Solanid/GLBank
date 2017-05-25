using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLBankATM
{
    class MessagesLang
    {
        private static String[] menuPin = { "Change PIN", "Zmeniť PIN" , "PIN-Code ändern" };
        private static String[] menuMoney = { "Withdraw Money", "Vybrať Peniaze", "Geld abheben" };
        private static String[] menuBalance = { "Check Balance", "Zostatok na účte", "Kontostand" };
        private static String[] menuLanguage = { "Change Language", "Zmeniť Jazyk", "Änderung Sprache" };

        private static String[] messEnterPin = { "Enter PIN:", "Zadajde PIN:", "Geben Sie die PIN:" };
        private static String[] messBlockedCard = { "Your Card is BLOCKED!", "Vaša karta je zablokovaná!", "Ihre Karte ist BLOCKED!" };
        private static String[] messBalance = { "Your Balance is:", "Váš zostatok na účte je:", "Ihr Gleichgewicht ist" };
        private static String[] messBack = { "Back", "Spať", "zurück" };

        public static string getMessageMenuPin(Languages lang)
        {
            if (lang == Languages.ENG)
                return menuPin[0];
            else if (lang == Languages.SVK)
                return menuPin[1];
            else if (lang == Languages.DE)
                return menuPin[2];
            return null;
        }

        public static string getMessageMenuMoney(Languages lang)
        {
            if (lang == Languages.ENG)
                return menuMoney[0];
            else if (lang == Languages.SVK)
                return menuMoney[1];
            else if (lang == Languages.DE)
                return menuMoney[2];
            return null;
        }

        public static string getMessageMenuBalance(Languages lang)
        {
            if (lang == Languages.ENG)
                return menuBalance[0];
            else if (lang == Languages.SVK)
                return menuBalance[1];
            else if (lang == Languages.DE)
                return menuBalance[2];
            return null;
        }

        public static string getMessageMenuLanguage(Languages lang)
        {
            if (lang == Languages.ENG)
                return menuLanguage[0];
            else if (lang == Languages.SVK)
                return menuLanguage[1];
            else if (lang == Languages.DE)
                return menuLanguage[2];
            return null;
        }

        public static string getMessageEnterPin(Languages lang)
        {
            if (lang == Languages.ENG)
                return messEnterPin[0];
            else if (lang == Languages.SVK)
                return messEnterPin[1];
            else if (lang == Languages.DE)
                return messEnterPin[2];
            return null;
        }

        public static string getMessageBlockedCard(Languages lang)
        {
            if (lang == Languages.ENG)
                return messBlockedCard[0];
            else if (lang == Languages.SVK)
                return messBlockedCard[1];
            else if (lang == Languages.DE)
                return messBlockedCard[2];
            return null;
        }

        public static string getMessageBalance(Languages lang)
        {
            if (lang == Languages.ENG)
                return messBalance[0];
            else if (lang == Languages.SVK)
                return messBalance[1];
            else if (lang == Languages.DE)
                return messBalance[2];
            return null;
        }

        public static string getMessageBack(Languages lang)
        {
            if (lang == Languages.ENG)
                return messBack[0];
            else if (lang == Languages.SVK)
                return messBack[1];
            else if (lang == Languages.DE)
                return messBack[2];
            return null;
        }

    }
}
