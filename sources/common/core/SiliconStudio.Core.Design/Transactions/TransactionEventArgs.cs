// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System;

namespace SiliconStudio.Core.Transactions
{
    /// <summary>
    /// Arguments of events triggered by <see cref="ITransactionStack"/> instances that affect a single transaction.
    /// </summary>
    public class TransactionEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionEventArgs"/> class.
        /// </summary>
        /// <param name="transaction">The transaction associated to this event.</param>
        public TransactionEventArgs(IReadOnlyTransaction transaction)
        {
            Transaction = transaction;
        }

        /// <summary>
        /// Gets the transaction associated to this event.
        /// </summary>
        public IReadOnlyTransaction Transaction { get; }
    }
}
