// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using System;

namespace SiliconStudio.Core
{
    /// <summary>
    /// Metadata used for providing attached getter/setter to a <see cref="PropertyKey"/>.
    /// </summary>
    public class AccessorMetadata : PropertyKeyMetadata
    {
        /// <summary>
        /// Setter delegate.
        /// </summary>
        /// <param name="propertyContainer">The property container holding the value.</param>
        /// <param name="value">The value to set</param>
        public delegate void SetterDelegate(ref PropertyContainer propertyContainer, object value);

        /// <summary>
        /// Getter delegate
        /// </summary>
        /// <param name="propertyContainer">The property container holding the value.</param>
        /// <returns>Returns the value</returns>
        public delegate object GetterDelegate(ref PropertyContainer propertyContainer);

        private SetterDelegate setter;
        private GetterDelegate getter;

        /// <summary>
        /// Initializes a new instance of <see cref="AccessorMetadata"/>.
        /// </summary>
        /// <param name="getter">Getter delegate.</param>
        /// <param name="setter">Setter delegate.</param>
        public AccessorMetadata(GetterDelegate getter, SetterDelegate setter)
        {
            this.getter = getter;
            this.setter = setter;
        }

        /// <summary>
        /// Gets the value from a <see cref="PropertyContainer"/> associated to this getter.
        /// </summary>
        /// <param name="obj">the property container.</param>
        /// <returns>The value stored.</returns>
        public object GetValue(ref PropertyContainer obj)
        {
            return getter(ref obj);
        }

        /// <summary>
        /// Sets the value for a <see cref="PropertyContainer"/> value.
        /// </summary>
        /// <param name="obj">The property container.</param>
        /// <param name="value">The value to set.</param>
        public void SetValue(ref PropertyContainer obj, object value)
        {
            setter(ref obj, value);
        }
    }
}
