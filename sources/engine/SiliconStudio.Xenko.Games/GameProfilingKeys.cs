// Copyright (c) 2014-2017 Silicon Studio Corp. All rights reserved. (https://www.siliconstudio.co.jp)
// See LICENSE.md for full license information.
using SiliconStudio.Core.Diagnostics;

namespace SiliconStudio.Xenko.Games
{
    /// <summary>
    /// Keys used for profiling the game class.
    /// </summary>
    public static class GameProfilingKeys
    {
        public static readonly ProfilingKey Game = new ProfilingKey("Game");

        /// <summary>
        /// Profiling initialization of a Game instance.
        /// </summary>
        public static readonly ProfilingKey GameInitialize = new ProfilingKey(Game, "Initialize");

        /// <summary>
        /// Profiling load content of a Game instance.
        /// </summary>
        public static readonly ProfilingKey GameLoadContent = new ProfilingKey(Game, "LoadContent");

        /// <summary>
        /// Profiling initialization of a <see cref="IGameSystemBase"/>.
        /// </summary>
        public static readonly ProfilingKey GameSystemInitialize = new ProfilingKey(Game, "GameSystem.Initialize");

        /// <summary>
        /// Profiling LoadContent of a <see cref="IGameSystemBase"/>.
        /// </summary>
        public static readonly ProfilingKey GameSystemLoadContent = new ProfilingKey(Game, "GameSystem.LoadContent");

        /// <summary>
        /// Profiling Draw() method of a <see cref="GameBase"/>. This profiling is only used through markers published every seconds.
        /// </summary>
        public static readonly ProfilingKey GameDraw = new ProfilingKey(Game, "Draw");

        /// <summary>
        /// Profiling EndDraw() method of a <see cref="GameBase"/>. This profiling is only used through markers published every seconds.
        /// </summary>
        public static readonly ProfilingKey GameEndDraw = new ProfilingKey(Game, "EndDraw");

        /// <summary>
        /// Profiling Update() method of a <see cref="GameBase"/>. This profiling is only used through markers published every seconds.
        /// </summary>
        public static readonly ProfilingKey GameUpdate = new ProfilingKey(Game, "Update");

        /// <summary>
        /// Profiling Draw() method of a <see cref="GameBase"/>. This profiling is only used through markers published every seconds.
        /// </summary>
        public static readonly ProfilingKey GameDrawFPS = new ProfilingKey(Game, "DrawFPS");

        /// <summary>
        /// Profiling Object Database initialization.
        /// </summary>
        public static readonly ProfilingKey ObjectDatabaseInitialize = new ProfilingKey(Game, "ObjectDatabase.Initialize");

        /// <summary>
        /// Profiling Entity processors initialization.
        /// </summary>
        public static readonly ProfilingKey EntityProcessorInitialize = new ProfilingKey(Game, "EntityProcessor.Initialize");
    }
}
