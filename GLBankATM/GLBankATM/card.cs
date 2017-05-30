using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLBankATM
{
    public class Card
    {
        private int idCard;
        private long cardNumber;
        private long idAcc;
        private bool blocked;

        public Card(int idCard, long cardNumber, long idAcc, bool blocked)
        {
            this.idCard = idCard;
            this.cardNumber = cardNumber;
            this.idAcc = idAcc;
            this.blocked = blocked;
        }

        public int getIdCard()
        {
            return idCard;
        }

        public long getCardNumber()
        {
            return cardNumber;
        }

        public long getIdAcc()
        {
            return idAcc;
        }

        public bool idBlocked()
        {
            return blocked;
        }
    }
}
