﻿//-------------------------------------------------------------------------------
// <copyright file="EventArgs{T}.cs" company="Appccelerate">
//   Copyright (c) 2008-2012
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace Appccelerate.Events
{
    using System;

    /// <summary>
    /// Generic EventArgs
    /// Use like : event EventHandler&lt;EventArgs&lt;int&gt;&gt; clickedyclick
    /// </summary>
    /// <typeparam name="T">Type of the contained value.</typeparam>
    [Serializable]
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// The contained value.
        /// </summary>
        private readonly T value;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventArgs{T}"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public EventArgs(T value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets the contained value.
        /// </summary>
        public T Value
        {
            get { return this.value; }
        }
    }
}