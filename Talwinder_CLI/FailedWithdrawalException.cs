using System;

namespace Talwinder_CLI
{
    public class FailedWithdrawalException : Exception
    {
        public FailedWithdrawalException()
        {
        }

        public FailedWithdrawalException(string message)
            : base(message)
        {
        }

        public FailedWithdrawalException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
