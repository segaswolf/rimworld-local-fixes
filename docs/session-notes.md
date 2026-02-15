# Session Notes

## Imported Operational Notes

### Stability Direction
- Prioritize broad, high-impact fixes over many tiny one-off patches.
- Keep local patches independent from workshop dependencies when possible.
- Preserve patch author signature as `Segas Wolf` in local mod metadata.

### Confirmed Problem Families
- Pawn Editor in-game `Edit` blocked by tab worker initialization path.
- Right-click fence->gate flow intermittently losing material selection menu.
- Deadlife Rotstink sustainer spam under long tick runs.
- Ghost rendering exception loops in UI update path.
- Stockpile Ranking sequence-empty exception loop.

### Key Log Signatures Used During Triage
- `Failed to initialize tab worker`
- `PawnEditor.UITable<T>.Heading..ctor(Texture2D icon, Nullable<float> width)`
- `PawnEditor.TabWorker_AnimalMech.Initialize`
- `Rotstink spray sustainer still playing after 1000 ticks. Force-ending.`
- `Exception in UIRootUpdate` at `Verse.GhostUtility.GhostGraphicFor`
- `Sequence contains no elements`

### Fixing Principles
- Prefer fail-safe behavior to avoid hard UI loss.
- Use one-time warnings (`WarningOnce`) to reduce log spam.
- Keep each fix line isolated by branch and documented in patch notes.

### Publishing/Process Principles
- Keep conversation language flexible, but publish repository content in English.
- Use issues for root causes, not individual repeated stacktrace lines.
- Validate before closing issues to avoid false positives.


### Discord reference
- Progression ecosystem server: https://discord.gg/b58NcrzxRS
