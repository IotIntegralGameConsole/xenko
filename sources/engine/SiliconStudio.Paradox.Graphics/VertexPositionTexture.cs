﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Runtime.InteropServices;
using SiliconStudio.Core.Mathematics;

namespace SiliconStudio.Paradox.Graphics
{
    /// <summary>
    /// Describes a custom vertex format structure that contains position and color information. 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VertexPositionTexture : IEquatable<VertexPositionTexture>, IVertex
    {
        /// <summary>
        /// Initializes a new <see cref="VertexPositionTexture"/> instance.
        /// </summary>
        /// <param name="position">The position of this vertex.</param>
        /// <param name="textureCoordinate">UV texture coordinates.</param>
        public VertexPositionTexture(Vector3 position, Vector2 textureCoordinate)
            : this()
        {
            Position = position;
            TextureCoordinate = textureCoordinate;
        }

        /// <summary>
        /// XYZ position.
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// UV texture coordinates.
        /// </summary>
        public Vector2 TextureCoordinate;

        /// <summary>
        /// Defines structure byte size.
        /// </summary>
        public static readonly int Size = 20;

        /// <summary>
        /// The vertex layout of this struct.
        /// </summary>
        public static readonly VertexDeclaration Layout = new VertexDeclaration(VertexElement.Position<Vector3>(), VertexElement.TextureCoordinate<Vector2>());

        public bool Equals(VertexPositionTexture other)
        {
            return Position.Equals(other.Position) && TextureCoordinate.Equals(other.TextureCoordinate);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is VertexPositionTexture && Equals((VertexPositionTexture)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Position.GetHashCode();
                hashCode = (hashCode * 397) ^ TextureCoordinate.GetHashCode();
                return hashCode;
            }
        }

        public VertexDeclaration GetLayout()
        {
            return Layout;
        }

        public void FlipWinding()
        {
            TextureCoordinate.X = (1.0f - TextureCoordinate.X);
        }

        public static bool operator ==(VertexPositionTexture left, VertexPositionTexture right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VertexPositionTexture left, VertexPositionTexture right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            return string.Format("Position: {0}, Texcoord: {1}", Position, TextureCoordinate);
        }
    }
}