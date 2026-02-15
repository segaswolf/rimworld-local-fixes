# Pawn Editor Stability Patch

Runtime safety patch for Pawn Editor mod.

## Problems Fixed

### Runtime Crashes
- **Failed to initialize tab worker**: NullReferenceException when opening Pawn Editor tabs
- **Duplicate Pawn IDs**: Occasional duplicate pawn IDs when copying/pasting pawns in the editor
- **Texture initialization errors**: Null textures causing UI crashes

### Solution
- Prefix-based guards that pre-initialize Texture2D fields before they're accessed
- Postfix on LoadItem that detects and fixes duplicate pawn IDs by assigning unique IDs
- Global try-catch in Bootstrap to prevent mod load crashes

## Known Issues (Require Fork to Fix)

### 1. Age Reset Bug
**Problem**: When user changes age in Bio tab, it resets to 18 or doesn't persist.

**Location**: `Source/PawnEditor/Tabs/Humanlike/Bio/BasicInfo.cs` and `TopRightButtons.cs`

**Root Cause**: The `SetDevStage` method in TopRightButtons.cs automatically sets age to the minimum age for the developmental stage (18 for Adult). This runs after user changes age, resetting it.

**Fix Needed**: Separate age setting from developmental stage setting, or prevent SetDevStage from overwriting user-set ages.

### 2. Missing Body Part Bug
**Problem**: Adding "Missing Body Part" hediff marks ALL body parts as missing, killing the pawn instantly.

**Location**: `Source/PawnEditor/Tabs/TabWorker_Health.cs`

**Root Cause**: The hediff creation/addition doesn't properly specify which body part should be missing, causing a wildcard effect.

**Fix Needed**: Ensure the UI properly selects and assigns a specific BodyPartRecord before adding the hediff.

## Load Order
Place AFTER the Pawn Editor mod (isorex.pawneditor) in your mod list.
