using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw4_bank_
{
    enum TransitionType
    {
        Withdraw = 1,
        Deposit = 2,

    }
    class TransitionInfo
    {
        TransitionType transitionType;
        string transitionFromNumber;
        string transitionTo;
        decimal totalValue;

        public TransitionInfo(TransitionType type, string numberFrom, string numberTo, decimal value)
        {
            this.transitionType = type;
            this.transitionFromNumber = numberFrom;
            this.transitionTo = numberTo;
            this.totalValue = value;
        }

        public override string ToString()
        {
            return $"\n<--------->\nTransition: {Enum.GetName(transitionType)},\nFrom: {transitionFromNumber},\nTo: {transitionTo},\nValue: {totalValue}\n<--------->\n";
        }
    }
    class TransitionHistory
    {
        public HashSet<TransitionInfo> transitions = new HashSet<TransitionInfo> ();

        public TransitionHistory()
        {

        }
        public TransitionHistory(HashSet<TransitionInfo> transitionsInfo) {
            transitions = new HashSet<TransitionInfo> (transitionsInfo);
        }
    }
}
