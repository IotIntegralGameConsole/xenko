// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System;
using System.Collections;
using System.Collections.Generic;

namespace SiliconStudio.Shaders.Ast
{
    /// <summary>
    /// A Conditional expression
    /// </summary>
    public partial class ConditionalExpression : Expression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalExpression"/> class.
        /// </summary>
        public ConditionalExpression()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConditionalExpression"/> class.
        /// </summary>
        /// <param name="condition">The condition.</param>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        public ConditionalExpression(Expression condition, Expression left, Expression right)
        {
            Condition = new ParenthesizedExpression(condition);
            Left = left;
            Right = right;
        }

        #region Public Properties

        /// <summary>
        ///   Gets or sets the condition.
        /// </summary>
        /// <value>
        ///   The condition.
        /// </value>
        public Expression Condition { get; set; }

        /// <summary>
        ///   Gets or sets the left.
        /// </summary>
        /// <value>
        ///   The left.
        /// </value>
        public Expression Left { get; set; }

        /// <summary>
        ///   Gets or sets the right.
        /// </summary>
        /// <value>
        ///   The right.
        /// </value>
        public Expression Right { get; set; }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public override IEnumerable<Node> Childrens()
        {
            ChildrenList.Clear();
            ChildrenList.Add(Condition);
            ChildrenList.Add(Left);
            ChildrenList.Add(Right);
            return ChildrenList;
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return string.Format("{0} ? {1} : {2}", Condition, Left, Right);
        }

        #endregion
    }
}
