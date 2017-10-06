// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System;
using SiliconStudio.Assets.Quantum.Internal;
using SiliconStudio.Core.Reflection;
using SiliconStudio.Quantum;
using SiliconStudio.Quantum.References;

namespace SiliconStudio.Assets.Quantum
{
    /// <summary>
    /// An implementation of <see cref="INodeFactory"/> that creates node capable of storing additional metadata, such as override information, connection
    /// to a base node or any other node, etc.
    /// </summary>
    public class AssetNodeFactory : INodeFactory
    {
        /// <inheritdoc/>
        public IObjectNode CreateObjectNode(INodeBuilder nodeBuilder, Guid guid, object obj, ITypeDescriptor descriptor)
        {
            if (nodeBuilder == null) throw new ArgumentNullException(nameof(nodeBuilder));
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));
            var reference = nodeBuilder.CreateReferenceForNode(descriptor.Type, obj, false) as ReferenceEnumerable;
            return new AssetObjectNode(nodeBuilder, obj, guid, descriptor, reference);
        }

        /// <inheritdoc/>
        public IObjectNode CreateBoxedNode(INodeBuilder nodeBuilder, Guid guid, object structure, ITypeDescriptor descriptor)
        {
            if (nodeBuilder == null) throw new ArgumentNullException(nameof(nodeBuilder));
            if (structure == null) throw new ArgumentNullException(nameof(structure));
            if (descriptor == null) throw new ArgumentNullException(nameof(descriptor));
            return new AssetBoxedNode(nodeBuilder, structure, guid, descriptor);
        }

        /// <inheritdoc/>
        public IMemberNode CreateMemberNode(INodeBuilder nodeBuilder, Guid guid, IObjectNode parent, IMemberDescriptor member, object value)
        {
            if (nodeBuilder == null) throw new ArgumentNullException(nameof(nodeBuilder));
            if (parent == null) throw new ArgumentNullException(nameof(parent));
            if (member == null) throw new ArgumentNullException(nameof(member));
            var reference = nodeBuilder.CreateReferenceForNode(member.Type, value, true);
            return new AssetMemberNode(nodeBuilder, guid, parent, member, reference);
        }
    }
}