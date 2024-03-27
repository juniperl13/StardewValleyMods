﻿using System.IO;
using System.Linq;
using StardewModdingAPI;

namespace BushBloomMod.Patches.Integrations {
    internal static class Automate {
        public static void Register(IManifest manifest, IModHelper helper, IMonitor monitor, Config config) {
            try {
                System.Reflection.Assembly.LoadFrom(Path.Combine(new FileInfo(typeof(ModEntry).Assembly.Location).DirectoryName, "AutomateBBM.dll"))
                    .GetTypes().Where(t => t.Name == "Automate")
                    .Select(t => t.GetMethod("Register"))
                    .FirstOrDefault().Invoke(null, new object[] { manifest, helper, monitor, config });
            } catch { }
        }
    }
}