using SiliconStudio.Assets;
using SiliconStudio.Core.Serialization;
using SiliconStudio.Xenko.Assets.Textures;
using SiliconStudio.Xenko.Audio;
using SiliconStudio.Xenko.Graphics;
using SiliconStudio.Xenko.Physics;

namespace SiliconStudio.Xenko.Assets
{
    public class GameSettingsFactory : AssetFactory<GameSettingsAsset>
    {
        public static GameSettingsAsset Create()
        {
            var asset = new GameSettingsAsset();

            asset.SplashScreen = AttachedReferenceManager.CreateProxyObject<Texture>(new AssetId("d26edb11-10bd-403c-b3c2-9c7fcccf25e5"), "XenkoDefaultSplashScreen");

            //add default filters, todo maybe a config file somewhere is better
            asset.PlatformFilters.Add("PowerVR SGX 54[0-9]");
            asset.PlatformFilters.Add("Adreno \\(TM\\) 2[0-9][0-9]");
            asset.PlatformFilters.Add("Adreno (TM) 320");
            asset.PlatformFilters.Add("Adreno (TM) 330");
            asset.PlatformFilters.Add("Adreno \\(TM\\) 4[0-9][0-9]");
            asset.PlatformFilters.Add("NVIDIA Tegra");
            asset.PlatformFilters.Add("Intel(R) HD Graphics");
            asset.PlatformFilters.Add("^Mali\\-4");
            asset.PlatformFilters.Add("^Mali\\-T6");
            asset.PlatformFilters.Add("^Mali\\-T7");

            asset.GetOrCreate<RenderingSettings>();
            asset.GetOrCreate<EditorSettings>();
            asset.GetOrCreate<TextureSettings>();
            asset.GetOrCreate<PhysicsSettings>();
            asset.GetOrCreate<AudioEngineSettings>();

            return asset;
        }

        public override GameSettingsAsset New()
        {
            return Create();
        }
    }
}
