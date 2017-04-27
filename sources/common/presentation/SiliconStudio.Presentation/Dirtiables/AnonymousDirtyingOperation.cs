// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System;
using System.Collections.Generic;
using SiliconStudio.Core.Annotations;

namespace SiliconStudio.Presentation.Dirtiables
{
    public class AnonymousDirtyingOperation : DirtyingOperation
    {
        private Action undo;
        private Action redo;

        public AnonymousDirtyingOperation([NotNull] IEnumerable<IDirtiable> dirtiables, Action undo, Action redo)
            : base(dirtiables)
        {
            this.undo = undo;
            this.redo = redo;
        }

        /// <inheritdoc/>
        protected override void FreezeContent()
        {
            undo = null;
            redo = null;
        }

        /// <inheritdoc/>
        protected override void Undo()
        {
            undo?.Invoke();
        }

        /// <inheritdoc/>
        protected override void Redo()
        {
            redo?.Invoke();
        }
    }
}
