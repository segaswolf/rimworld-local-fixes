# Fixes Log

## RuntimeStabilityFix
- Highborn social gene empty-list guard.
- MultiFloors prepatcher field exposure guard.
- WidgetRow null icon safety.
- GrowerHarvest `HasJobOnCell` finalizer safety.
- FloatMenu `GetOptions` safety adjusted to avoid wiping options list on exceptions.
- Ghost graphic fallback guard in `GhostUtility.GhostGraphicFor`.
- Deadlife gas spewer sustainer stability guards.
- SuppressCurl60Spam: suppresses SSL certificate errors from mod update checker (prevents log spam).
- MinifiedThing label safety guard.
- 2026-02-15: Removed XmlDocumentViewer disable patches (broke functionality), added try-catch in Bootstrap.

## PawnEditorStabilityPatch
- 2026-02-15: Simplified patch - removed broken Finalizer patches that caused load errors. Only kept PreOpen and TexPawnEditor static init guards.

## CrossRefStabilityFix
- Restored missing research/category/thing fallback defs.
- Medieval Fridge XML cleanup.
- Kid apparel texture fallback.
- Cross-ref cleanup for dangling style/pawnkind refs.
- Archotech punch sound fallback.

## StockpileRankingSafePatch
- 2026-02-15: Converted from Finalizer-based to Prefix-based guards.
- Patch_RankComp_DetermineUsedFilter: prevents null/empty ranks error before calling .Last()
- Patch_RankComp_DetermineUsedFilters: skips processing if rankedSettings is null/empty
- Patch_RankComp_GameComponentTick: skips tick processing if not dirty
- Patch_RankComp_LoadedGame: skips processing if no rankedSettings on game load
- Added try-catch in Bootstrap for safer loading
