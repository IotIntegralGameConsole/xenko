// Copyright (c) 2011-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using System.Linq;
using System.Reflection;

namespace SiliconStudio.Core.Yaml.Serialization
{
    /// <summary>
    /// A factory selector that will select factories depending on the profiles specified in the <see cref="YamlSerializerFactoryAttribute"/>.
    /// </summary>
    public class ProfileSerializerFactorySelector : SerializerFactorySelector
    {
        private static readonly string[] EmptyProfiles = new string[0];
        private readonly string[] profiles;

        public ProfileSerializerFactorySelector(params string[] profiles)
        {
            this.profiles = profiles ?? EmptyProfiles;
        }

        protected override bool CanAddSerializerFactory(IYamlSerializableFactory factory)
        {
            var attribute = factory.GetType().GetCustomAttribute<YamlSerializerFactoryAttribute>();
            if (attribute == null)
                return profiles.Any(x => YamlSerializerFactoryAttribute.AreProfilesEqual(x, YamlSerializerFactoryAttribute.Default));

            return profiles.Any(x => attribute.ContainsProfile(x));
        }
    }
}
