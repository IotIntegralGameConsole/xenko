// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.

using SiliconStudio.Core;
using SiliconStudio.Core.Mathematics;

namespace SiliconStudio.Xenko.Particles.Spawners
{
    /// <summary>
    /// <see cref="ParticleSpawnTriggerBirth"/> triggers when the parent particle is first spawned
    /// </summary>
    [DataContract("ParticleSpawnTriggerBirth")]
    [Display("On Birth")]
    public class ParticleSpawnTriggerBirth : ParticleSpawnTrigger<float>
    {
        public override void PrepareFromPool(ParticlePool pool)
        {
            if (pool == null)
            {
                FieldAccessor = ParticleFieldAccessor<float>.Invalid();
                return;
            }

            FieldAccessor = pool.GetField(ParticleFields.RemainingLife);
        }

        public unsafe override float HasTriggered(Particle parentParticle)
        {
            if (!FieldAccessor.IsValid())
                return 0f;

            var currentLifetime = 1f - (*((float*)parentParticle[FieldAccessor]));

            return (currentLifetime <= MathUtil.ZeroTolerance) ? 1f : 0f;
        }
    }
}
