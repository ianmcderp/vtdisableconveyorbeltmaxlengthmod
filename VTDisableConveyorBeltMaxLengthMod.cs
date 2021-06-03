using HarmonyLib;
using System;
using System.Reflection;
using VoxelTycoon;
using VoxelTycoon.Modding;

namespace VTDisableConveyorBeltMaxLengthMod
{
    public class VTDisableConveyorBeltMaxLengthMod : Mod
    {
        Logger _logger = new Logger<VTDisableConveyorBeltMaxLengthMod>();

        protected override void OnGameStarted()
        {
            try
            {
                var harmony = new Harmony("com.github.ianmcderp");
                Harmony.DEBUG = true;
                harmony.PatchAll(Assembly.GetExecutingAssembly());
                harmony.PatchAll();
            }
            catch (Exception e)
            {
                _logger.LogError("Loading VTDisableConveyorBeltMaxLengthMod failed");
                _logger.LogException(e);
            }
        }
    }

    [HarmonyPatch(
        typeof(VoxelTycoon.Tools.TrackBuilder.ConveyorBuilderTool),
        "CheckLength",
        new Type[] {}
        )]
    class PatchedConveyorBuilderTool
    {
        static void Postfix(ref bool __result)
        {
            __result = true;
        }
    }
}
