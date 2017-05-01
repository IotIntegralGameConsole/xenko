﻿// Copyright (c) 2016-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using System;
using System.Collections.Generic;
using System.Linq;
using SiliconStudio.Core;
using SiliconStudio.Core.Annotations;

namespace SiliconStudio.Assets
{
    /// <summary>
    /// A class containing the information of a hierarchy of asset parts contained in an <see cref="AssetCompositeHierarchy{TAssetPartDesign, TAssetPart}"/>.
    /// </summary>
    /// <typeparam name="TAssetPartDesign">The type used for the design information of a part.</typeparam>
    /// <typeparam name="TAssetPart">The type used for the actual parts,</typeparam>
    [DataContract("AssetCompositeHierarchyData")]
    public class AssetCompositeHierarchyData<TAssetPartDesign, TAssetPart>
        where TAssetPartDesign : class, IAssetPartDesign<TAssetPart>
        where TAssetPart : class, IIdentifiable
    {
        /// <summary>
        /// Gets a collection if identifier of all the parts that are root of this hierarchy.
        /// </summary>
        [DataMember(10)]
        [NonIdentifiableCollectionItems]
        [NotNull]
        public List<TAssetPart> RootParts { get; } = new List<TAssetPart>();

        /// <summary>
        /// Gets a collection of all the parts, root or not, contained in this hierarchy.
        /// </summary>
        [DataMember(20)]
        [NonIdentifiableCollectionItems]
        [ItemNotNull, NotNull]
        public AssetPartCollection<TAssetPartDesign, TAssetPart> Parts { get; } = new AssetPartCollection<TAssetPartDesign, TAssetPart>();
    }
}
