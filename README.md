# Segas Wolf RimWorld Local Fixes

Local compatibility and stability fixes for RimWorld 1.6 modpacks.

## Goals
- Keep long-running saves stable with targeted runtime guards.
- Reduce cross-reference and startup noise with safe fallback defs/patches.
- Track problem -> fix -> validation so regressions are easy to spot.

## Branch Model
- `main`: docs, issue tracking, and overall roadmap.
- `patch/runtime-stability-fix`: Runtime guard patch source and mod metadata.
- `patch/pawneditor-stability`: Pawn Editor stability patch source and mod metadata.
- `patch/crossref-stability`: XML fallback/cleanup patch mod.

## Logbook Files
- `docs/problems.md`: known issues and symptoms.
- `docs/fixes.md`: implemented fixes and technical details.
- `docs/patch-notes.md`: dated change log by patch line.
- `docs/validation.md`: quick validation outcomes after test runs.


## Triage Workflow
- Track root problems from logs through issues using `.github/ISSUE_TEMPLATE/playerlog-problem.md`.
- Validate each fix using `.github/ISSUE_TEMPLATE/fix-validation.md` and `docs/validation.md`.
- Keep push history aligned with `docs/triage.md` to prevent regression loops and duplicate work.
