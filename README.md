# Segas Wolf RimWorld Local Fixes

> Stability-first local fixes for RimWorld 1.6 modpacks, with a strong focus on Progression-centered setups.

## What you will find here 🧩

### Local Patches (in `mods/`)

| Mod | Description | Target Problem |
|-----|-------------|----------------|
| `RuntimeStabilityFix` | Runtime safety patches for various mod incompatibilities | Suppresses known crashes, handles null references |
| `PawnEditorStabilityPatch` | Fixes for Pawn Editor UI crashes and duplicate pawn IDs | "Failed to initialize tab worker", duplicate pawn IDs |
| `StockpileRankingSafePatch` | Prefix-based guards to prevent errors | "Sequence contains no elements" loop |
| `NeuralSuperchargerOwnershipFix` | Deduplicates pawns/buildings on game load | "register the same load ID twice" |
| `CrossRefStabilityFix` | XML fallback defs and cross-reference cleanup | Missing defs, cross-ref errors |

### Tracking Docs
- `docs/problems.md` -> open + historical problem signatures
- `docs/fixes.md` -> implemented fixes by module
- `docs/patch-notes.md` -> dated changes

## Target environment 🎯
- RimWorld `1.6`
- Progression ecosystem (Ferny and related content)
- Long-running colonies where stability is prioritized

## Repository map 🗂️
- `main` -> docs, process, tracking, triage workflow
- `patch/runtime-stability-fix` -> runtime guard module
- `patch/pawneditor-stability` -> Pawn Editor stabilization module
- `patch/crossref-stability` -> XML fallback/cleanup module

## Tracking docs 📘
- `docs/problems.md` -> open + historical problem signatures
- `docs/fixes.md` -> implemented fixes by module
- `docs/patch-notes.md` -> dated changes
- `docs/validation.md` -> validation queue/results
- `docs/session-notes.md` -> operational context
- `docs/triage.md` -> repeatable Player.log triage flow

## Workflow (short) ⚙️
1. Capture root issue from `Player.log`
2. Open issue with log signature + impact
3. Patch on dedicated branch
4. Validate behavior and logs
5. Push + update notes

## Community 💬
These patches are made for the Progression mod ecosystem created by Ferny.

- Discord: https://discord.gg/b58NcrzxRS
- Modpack: https://steamcommunity.com/sharedfiles/filedetails/?id=3521297585

## Attribution ✍️
- Local patch metadata uses author: `Segas Wolf`

---
If you are reviewing this repository for the first time, start with `docs/problems.md` and `docs/validation.md`.
