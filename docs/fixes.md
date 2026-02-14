# Fixes Log

## RuntimeStabilityFix
- Highborn social gene empty-list guard.
- MultiFloors prepatcher field exposure guard.
- WidgetRow null icon safety.
- GrowerHarvest `HasJobOnCell` finalizer safety.
- FloatMenu `GetOptions` safety adjusted to avoid wiping options list on exceptions.
- Ghost graphic fallback guard in `GhostUtility.GhostGraphicFor`.
- Deadlife gas spewer sustainer stability guards.

## PawnEditorStabilityPatch
- Guards for `ListingMenu_Items` static/init and constructors.
- Guard for `TexPawnEditor` static init with placeholder icons.
- Guard for `TabDef.Initialize`.
- Null icon placeholder injection for heading constructors.
- Additional `TabWorker_AnimalMech.Initialize` guard with broader method discovery.

## CrossRefStabilityFix
- Restored missing research/category/thing fallback defs.
- Medieval Fridge XML cleanup.
- Kid apparel texture fallback.
- Cross-ref cleanup for dangling style/pawnkind refs.
- Archotech punch sound fallback.
