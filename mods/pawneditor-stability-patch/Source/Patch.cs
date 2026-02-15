using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;

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
public static class Patch_DialogPawnEditorPreOpen {
  static IEnumerable<MethodBase> TargetMethods() {
    var m1 = AccessTools.Method("PawnEditor.Dialog_PawnEditor:PreOpen");
    if (m1 != null) yield return m1;
    var m2 = AccessTools.Method("PawnEditor.Dialog_PawnEditor_InGame:PreOpen");
    if (m2 != null) yield return m2;
  }

  static void Prefix() {
    try {
      var listingType = AccessTools.TypeByName("PawnEditor.ListingMenu_Items");
      if (listingType != null) {
        var staticInit = listingType.GetMethod(".cctor", BindingFlags.Static | BindingFlags.NonPublic);
        if (staticInit != null) {
          _ = staticInit.Invoke(null, null);
        }
      }
    } catch {
    }
  }
}

[HarmonyPatch]
public static class Patch_TexPawnEditorStaticInit {
  static IEnumerable<MethodBase> TargetMethods() {
    var t = AccessTools.TypeByName("PawnEditor.TexPawnEditor");
    if (t == null) yield break;
    var cctor = t.GetMethod(".cctor", BindingFlags.Static | BindingFlags.NonPublic);
    if (cctor != null) yield return cctor;
  }

  static void Prefix() {
    try {
      var t = AccessTools.TypeByName("PawnEditor.TexPawnEditor");
      var fields = t.GetFields(BindingFlags.Static | BindingFlags.Public);
      foreach (var f in fields) {
        if (f.FieldType == typeof(UnityEngine.Texture2D) && f.GetValue(null) == null) {
          f.SetValue(null, UnityEngine.Texture2D.whiteTexture);
        }
      }
    } catch {
    }
  }
}
}
