using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HarmonyLib;
using Verse;
using UnityEngine;
using RimWorld;
using RimWorld;

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

[HarmonyPatch]
public static class Patch_TabWorker_Bio_Humanlike_SetDevStage {
  static IEnumerable<MethodBase> TargetMethods() {
    var t = AccessTools.TypeByName("PawnEditor.TabWorker_Bio_Humanlike");
    if (t == null) yield break;
    var m = AccessTools.Method(t, "SetDevStage");
    if (m != null) yield return m;
  }

  static bool Prefix(Pawn pawn, DevelopmentalStage stage) {
    try {
      if (stage == DevelopmentalStage.Adult) {
        var currentBioAge = pawn.ageTracker.AgeBiologicalYears;
        if (currentBioAge > 18) {
          return false;
        }
      }
    } catch {
    }
    return true;
  }
}

[HarmonyPatch]
public static class Patch_Hediff_Add {
  static IEnumerable<MethodBase> TargetMethods() {
    var t = AccessTools.TypeByName("Verse.HediffSet");
    if (t == null) yield break;
    var m = AccessTools.Method(t, "Add");
    if (m != null) yield return m;
  }

  static bool Prefix(object __instance, Hediff hediff) {
    try {
      if (__instance is HediffSet hediffSet) {
        if (hediff != null && hediff.def.defName == "MissingBodyPart") {
          if (hediff.Part == null) {
            Log.Warning("[PawnEditorStabilityPatch] Attempted to add MissingBodyPart without specific body part - blocking to prevent pawn death.");
            return false;
          }
        }
      }
    } catch {
    }
    return true;
  }
}

[HarmonyPatch]
public static class Patch_SaveLoadUtility_LoadItem {
  static IEnumerable<MethodBase> TargetMethods() {
    var t = AccessTools.TypeByName("PawnEditor.SaveLoadUtility");
    if (t == null) yield break;
    var m = AccessTools.Method(t, "LoadItem");
    if (m != null) yield return m;
  }

  static void Postfix(object __result, object item) {
    try {
      if (item is Pawn pawn) {
        int newId = -1;
        
        try {
          var findType = typeof(Verse.Find);
          var worldProp = findType.GetProperty("World");
          if (worldProp != null) {
            var world = worldProp.GetValue(null);
            if (world != null) {
              var worldPawnsProp = world.GetType().GetProperty("WorldPawns");
              if (worldPawnsProp != null) {
                var worldPawns = worldPawnsProp.GetValue(world);
                if (worldPawns != null) {
                  var allPawnsProp = worldPawns.GetType().GetProperty("AllPawnsAliveOrDead");
                  if (allPawnsProp != null) {
                    var allPawns = allPawnsProp.GetValue(worldPawns) as IEnumerable<Pawn>;
                    if (allPawns != null) {
                      int maxId = 0;
                      foreach (var p in allPawns) {
                        if (p != null && p.thingIDNumber > maxId) {
                          maxId = p.thingIDNumber;
                        }
                      }
                      
                      bool hasDuplicate = false;
                      foreach (var p in allPawns) {
                        if (p != pawn && p.thingIDNumber == pawn.thingIDNumber) {
                          hasDuplicate = true;
                          break;
                        }
                      }
                      
                      if (hasDuplicate || pawn.thingIDNumber <= 0) {
                        newId = maxId + 1;
                      }
                    }
                  }
                }
              }
            }
          }
        } catch {
        }
        
        if (newId > 0) {
          pawn.thingIDNumber = newId;
          Log.Warning($"[PawnEditorStabilityPatch] Assigned new unique ID {newId} to pawn to fix duplicate.");
        }
      }
    } catch (Exception ex) {
      Log.Warning($"[PawnEditorStabilityPatch] LoadItem postfix failed: {ex.Message}");
    }
  }
}
}
