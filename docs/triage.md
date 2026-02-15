# Player.log Triage Workflow

This workflow keeps problem tracking consistent between pushes.

## 1) Capture
- Read `Player.log`, `Player-prev.log`, and `warning and errors.txt`.
- Extract one *root* problem per issue (do not create one issue per repeated line).
- Use title format: `[playerlog] <system> - <symptom>`.

## 2) Classify
- Add labels:
  - `source:playerlog`
  - `status:open` / `status:watching` / `status:fixed`
  - `patch:runtime` / `patch:pawneditor` / `patch:crossref`
- Record impact: gameplay block, UI block, lag/spam, warning-only.

## 3) Link to Work
- Attach issue to target branch (`patch/...`).
- Add intended fix scope in issue body before coding.

## 4) Validate
- Test in-game against explicit acceptance checks.
- Record before/after evidence in `docs/validation.md`.
- Open a `Fix Validation` issue if behavior changed but is not fully resolved.

## 5) Push Discipline
- Keep commits scoped to one problem family.
- Update in-repo logs before push:
  - `docs/problems.md`
  - `docs/fixes.md`
  - `docs/validation.md`
  - `docs/patch-notes.md`

## 6) Close Loop
- Move issue to `status:fixed` only after validation confirms expected behavior and log signature reduction/removal.
