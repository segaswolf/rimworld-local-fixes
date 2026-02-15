# Segas Wolf RimWorld Local Fixes

A local compatibility and stability patch line for RimWorld 1.6, focused on heavily modded saves.

## Project Vision
This repository tracks practical fixes for runtime errors, cross-reference breakage, and UI regressions that appear in large modlists.

Primary target context:
- RimWorld 1.6
- Progression-centered setups (Ferny ecosystem and related content)
- Long-running colonies where stability is more important than perfect upstream purity

## What This Repository Contains
- Runtime guard patch source (`RuntimeStabilityFix`)
- Pawn Editor crash guard patch source (`PawnEditorStabilityPatch`)
- XML fallback and cross-reference cleanup pack (`CrossRefStabilityFix`)
- Problem/fix/validation logs to avoid repeating already-tested steps

## Goals
- Keep long-running saves stable with targeted runtime guards.
- Reduce cross-reference and startup noise with safe fallback defs and patches.
- Preserve in-game UX (menus, tabs, tools) when third-party providers throw errors.
- Track problem -> fix -> validation so regressions are easy to spot.

## Branch Model
- `main`: docs, issue tracking, process, and triage workflow.
- `patch/runtime-stability-fix`: runtime guard patch source and metadata.
- `patch/pawneditor-stability`: Pawn Editor-specific stability patch source and metadata.
- `patch/crossref-stability`: XML fallback and cross-reference cleanup pack.

## Tracking Files
- `docs/problems.md`: active and historical problem signatures.
- `docs/fixes.md`: implemented fixes by patch module.
- `docs/patch-notes.md`: dated change log.
- `docs/validation.md`: current validation queue and outcomes.
- `docs/session-notes.md`: imported operational notes and key decisions.
- `docs/triage.md`: repeatable Player.log triage flow.

## Triage Workflow
- Track root problems from logs through issues using `.github/ISSUE_TEMPLATE/playerlog-problem.md`.
- Validate each fix with `.github/ISSUE_TEMPLATE/fix-validation.md` and `docs/validation.md`.
- Keep pushes aligned with `docs/triage.md` to prevent regression loops and duplicate work.


## Community
- Progression ecosystem Discord: https://discord.gg/b58NcrzxRS

## Attribution Note
- Local patch About metadata in this repository uses author `Segas Wolf`.
