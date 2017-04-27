// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
namespace SiliconStudio.Presentation.Services
{
    /// <summary>
    /// A structure representing the check status and the button pressed by the user to close a checkable message box.
    /// </summary>
    public struct CheckedMessageBoxResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedMessageBoxResult"/> structure.
        /// </summary>
        /// <param name="messageBoxResult">The result of the message box.</param>
        /// <param name="isChecked">The check status of the message box.</param>
        public CheckedMessageBoxResult(MessageBoxResult messageBoxResult, bool? isChecked)
        {
            MessageBoxResult = messageBoxResult;
            Result = (int)MessageBoxResult;
            IsChecked = isChecked;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckedMessageBoxResult"/> structure.
        /// </summary>
        /// <param name="result">The result of the message box.</param>
        /// <param name="isChecked">The check status of the message box.</param>
        public CheckedMessageBoxResult(int result, bool? isChecked)
        {
            MessageBoxResult = MessageBoxResult.None;
            Result = result;
            IsChecked = isChecked;
        }

        /// <summary>
        /// Gets the result of the message box.
        /// </summary>
        public MessageBoxResult MessageBoxResult { get; }

        /// <summary>
        /// Gets the result of the message box.
        /// </summary>
        public int Result { get; }

        /// <summary>
        /// Gets the check status of the message box.
        /// </summary>
        public bool? IsChecked { get; }
    }
}
