using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;
using UnityEngine;

namespace PawnEditorStabilityPatch {
public class Bootstrap : Mod {
  public Bootstrap(ModContentPack c) : base(c) {
    if (!LoadedModManager.RunningModsListForReading.Any(m => string.Equals(m.PackageId, "isorex.pawneditor", StringComparison.OrdinalIgnoreCase))) return;
    try {
      new Harmony("localfix.pawneditor.stability").PatchAll();
      Log.Message("[PawnEditorStabilityPatch] Loaded.");
    } catch (Exception ex) {
      Log.Error($"[PawnEditorStabilityPatch] Failed to load: {ex.Message}");
    }
  }
}

[HarmonyPatch]
public static class Patch_TabDefInitialize {
  static IEnumerable<MethodBase> TargetMethods() {
    var t = AccessTools.TypeByName("PawnEditor.TabDef");
    if (t == null) yield break;
    var m = AccessTools.Method(t, "Initialize");
    if (m != null) yield return m;
  }

  static bool Prefix() {
    try {
      var t = AccessTools.TypeByName("PawnEditor.TabDef");
      var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public);
      foreach (var f in fields) {
        if (f.FieldType == typeof(Texture2D) && f.GetValue(null) == null) {
          f.SetValue(null, Texture2D.whiteTexture);
        }
      }
    } catch (Exception ex) {
      Log.Warning($"[PawnEditorStabilityPatch] TabDefInitialize prefix failed: {ex.Message}");
    }
    return true;
  }
}

[HarmonyPatch]
public static class Patch_TabWorker_AnimalMech_Initialize {
  static IEnumerable<MethodBase> TargetMethods() {
    var t = AccessTools.TypeByName("PawnEditor.TabWorker_AnimalMech");
    if (t == null) yield break;
    var m = AccessTools.Method(t, "Initialize");
    if (m != null) yield return m;
  }

  static bool Prefix(object __instance) {
    try {
      if (__instance == null) return true;
      var fields = __instance.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      foreach (var f in fields) {
        if (f.FieldType == typeof(Texture2D)) {
          var val = f.GetValue(__instance) as Texture2D;
          if (val == null) {
            f.SetValue(__instance, Texture2D.whiteTexture);
          }
        }
      }
    } catch (Exception ex) {
      Log.Warning($"[PawnEditorStabilityPatch] TabWorker_AnimalMech.Initialize prefix failed: {ex.Message}");
    }
    return true;
  }
}

[HarmonyPatch]
public static class Patch_TabWorker_FactionOverview_GetHeadings {
  static IEnumerable<MethodBase> TargetMethods() {
    var t = AccessTools.TypeByName("PawnEditor.TabWorker_FactionOverview");
    if (t == null) yield break;
    var m = AccessTools.Method(t, "GetHeadings");
    if (m != null) yield return m;
  }

  static bool Prefix() {
    try {
      var t = AccessTools.TypeByName("PawnEditor.TexPawnEditor");
      if (t != null) {
        var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
        foreach (var f in fields) {
          if (f.FieldType == typeof(Texture2D)) {
            var val = f.GetValue(null) as Texture2D;
            if (val == null) {
              f.SetValue(null, Texture2D.whiteTexture);
            }
          }
        }
      }
    } catch {
    }
    return true;
  }
}
}
