# Segas Wolf RimWorld Local Fixes

> Stability-first local fixes for RimWorld 1.6 modpacks, with a strong focus on Progression-centered setups.

## Why this exists 🔍
Large modlists can break in subtle ways: tab UIs fail to open, context menus lose options, and repeated runtime errors create lag.

This project keeps a **problem -> fix -> validation** loop so each change is traceable and regressions are easier to catch.

## What you will find here 🧩
- Runtime safety patch source (`RuntimeStabilityFix`)
- Pawn Editor crash-guard source (`PawnEditorStabilityPatch`)
- XML fallback and cross-reference cleanup pack (`CrossRefStabilityFix`)
- Logs and triage docs to avoid repeating already-tested work

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
- Progression ecosystem Discord: https://discord.gg/b58NcrzxRS

## Attribution ✍️
- Local patch metadata uses author: `Segas Wolf`

---
If you are reviewing this repository for the first time, start with `docs/problems.md` and `docs/validation.md`.
