using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLBankATM
{
    class MessagesLang
    {
        private static String[] menuPin = { "Change PIN", "Zmeniť PIN" , "PIN-Code ändern", "PINの変更" };
        private static String[] menuMoney = { "Withdraw Money", "Vybrať Peniaze", "Geld abheben", "お金を引き出す" };
        private static String[] menuBalance = { "Check Balance", "Zostatok na účte", "Kontostand", "残高の確認" };
        private static String[] menuLanguage = { "Change Language", "Zmeniť Jazyk", "Änderung Sprache", "言語を変えてください" };

        private static String[] messEnterPin = { "Enter PIN:", "Zadajde PIN:", "Geben Sie die PIN:", "PINを入力：" };
        private static String[] messBlockedCard = { "Your Card is BLOCKED!", "Vaša karta je zablokovaná!", "Ihre Karte ist BLOCKED!", "あなたのカードはブロックされています！" };
        private static String[] messBalance = { "Your Balance is:", "Váš zostatok na účte je:", "Ihr Gleichgewicht ist", "あなたの残高は" };
        private static String[] messBack = { "Back", "Spať", "zurück", "バック" };

        private static String[] messHintsPressOk = { "Press OK to Confirm.", "Stlačte OK pre potvrdenie.", "Drücken Sie OK, um zu bestätigen.", "確認のためにOKを押してください" };
        private static String[] messEnterNewPin = { "Enter New PIN:", "Zadajte nový PIN:", "Neue PIN eingeben:", "新しいPINを入力してください :" };
        private static String[] messReEnterNewPin = { "Re-Enter New PIN:", "Zadajte nový PIN:", "Neue PIN eingeben:", "新しいPINを入力してください :" };
        private static String[] messEnterOldPin = { "Enter Old PIN:", "Zadajte Starý PIN:", "Alte PIN eingeben:", "古いPINを入力：" };

        private static String[] messPinChanged = { "PIN was changed!", "Váš PIN bol zmenený!", "PIN wurde geändert!", "PINが変更されました！" };
        private static String[] messPinNotChanged = { "Your PIN wasn't changed!", "Váš PIN nebol zmenený!", "Ihre PIN wurde nicht verändert!", "あなたのPINは変更されていません！" };
        private static String[] messCardBlocked = { "Your Card was BLOCKED!:", "Vaša karta bola zablokovaná!", "Deine karte war gebrochen!", "あなたのカードはブロックされました！" };

        private static String[] messWithdrawMoney = { "Withdraw Money", "Výber peňazí", "Geld abheben", "お金を引き出します" };



        public static string getMessageWithdrawMoney(Languages lang)
        {
            if (lang == Languages.ENG)
                return messWithdrawMoney[0];
            else if (lang == Languages.SVK)
                return messWithdrawMoney[1];
            else if (lang == Languages.DE)
                return messWithdrawMoney[2];
            else if (lang == Languages.JPN)
                return messWithdrawMoney[3];
            return null;
        }

        public static string getMessagePinChanged(Languages lang)
        {
            if (lang == Languages.ENG)
                return messPinChanged[0];
            else if (lang == Languages.SVK)
                return messPinChanged[1];
            else if (lang == Languages.DE)
                return messPinChanged[2];
            else if (lang == Languages.JPN)
                return messPinChanged[3];
            return null;
        }

        public static string getMessageCardBlocked(Languages lang)
        {
            if (lang == Languages.ENG)
                return messCardBlocked[0];
            else if (lang == Languages.SVK)
                return messCardBlocked[1];
            else if (lang == Languages.DE)
                return messCardBlocked[2];
            else if (lang == Languages.JPN)
                return messCardBlocked[3];
            return null;
        }

        public static string getMessagePinNotChanged(Languages lang)
        {
            if (lang == Languages.ENG)
                return messPinNotChanged[0];
            else if (lang == Languages.SVK)
                return messPinNotChanged[1];
            else if (lang == Languages.DE)
                return messPinNotChanged[2];
            else if (lang == Languages.JPN)
                return messPinNotChanged[3];
            return null;
        }

        public static string getMessageHintsPressOk(Languages lang)
        {
            if (lang == Languages.ENG)
                return messHintsPressOk[0];
            else if (lang == Languages.SVK)
                return messHintsPressOk[1];
            else if (lang == Languages.DE)
                return messHintsPressOk[2];
            else if (lang == Languages.JPN)
                return messHintsPressOk[3];
            return null;
        }

        public static string getMessageEnterOldPin(Languages lang)
        {
            if (lang == Languages.ENG)
                return messEnterOldPin[0];
            else if (lang == Languages.SVK)
                return messEnterOldPin[1];
            else if (lang == Languages.DE)
                return messEnterOldPin[2];
            else if (lang == Languages.JPN)
                return messEnterOldPin[3];
            return null;
        }

        public static string getMessageEnterNewPin(Languages lang)
        {
            if (lang == Languages.ENG)
                return messEnterNewPin[0];
            else if (lang == Languages.SVK)
                return messEnterNewPin[1];
            else if (lang == Languages.DE)
                return messEnterNewPin[2];
            else if (lang == Languages.JPN)
                return messEnterNewPin[3];
            return null;
        }

        public static string getMessageReEnterNewPi(Languages lang)
        {
            if (lang == Languages.ENG)
                return messReEnterNewPin[0];
            else if (lang == Languages.SVK)
                return messReEnterNewPin[1];
            else if (lang == Languages.DE)
                return messReEnterNewPin[2];
            else if (lang == Languages.JPN)
                return messReEnterNewPin[3];
            return null;
        }

        public static string getMessageMenuPin(Languages lang)
        {
            if (lang == Languages.ENG)
                return menuPin[0];
            else if (lang == Languages.SVK)
                return menuPin[1];
            else if (lang == Languages.DE)
                return menuPin[2];
            else if (lang == Languages.JPN)
                return menuPin[3];
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
            else if (lang == Languages.JPN)
                return menuMoney[3];
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
            else if (lang == Languages.JPN)
                return menuBalance[3];
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
            else if (lang == Languages.JPN)
                return menuLanguage[3];
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
            else if (lang == Languages.JPN)
                return messEnterPin[3];
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
            else if (lang == Languages.JPN)
                return messBlockedCard[3];
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
            else if (lang == Languages.JPN)
                return messBalance[3];
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
            else if (lang == Languages.JPN)
                return messBack[3];
            return null;
        }

    }
}
