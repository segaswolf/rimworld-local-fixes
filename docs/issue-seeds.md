# Initial Issue Seeds

Use these as first GitHub issues.

## 1) Pawn Editor in-game Edit UI blocked
- Suggested title: `[playerlog] pawneditor - tab worker init blocks in-game edit UI`
- Signature: `Failed to initialize tab worker` + `PawnEditor.UITable<T>.Heading..ctor` + `TabWorker_AnimalMech.Initialize`
- Impact: UI block
- Suggested labels: `source:playerlog`, `patch:pawneditor`, `status:open`

## 2) Fence -> Gate material list missing in right-click flow
- Suggested title: `[playerlog] architect menu - fence gate material chooser not displayed`
- Signature: user-visible regression in material picker despite material marker
- Impact: UI block / workflow degradation
- Suggested labels: `source:playerlog`, `patch:runtime`, `status:open`

## 3) GhostGraphicFor null loop causing UI lag
- Suggested title: `[playerlog] ghost rendering - GhostGraphicFor null loop in UIRootUpdate`
- Signature: `Exception in UIRootUpdate` at `Verse.GhostUtility.GhostGraphicFor`
- Impact: heavy lag / spam
- Suggested labels: `source:playerlog`, `patch:runtime`, `status:watching`

## 4) Deadlife Rotstink sustainer spam
- Suggested title: `[playerlog] deadlife - rotstink sustainer spam after 1000 ticks`
- Signature: `Rotstink spray sustainer still playing after 1000 ticks. Force-ending.`
- Impact: heavy spam
- Suggested labels: `source:playerlog`, `patch:runtime`, `status:watching`

## 5) Stockpile Ranking sequence-empty loop
- Suggested title: `[playerlog] stockpile ranking - sequence contains no elements loop`
- Signature: `InvalidOperationException: Sequence contains no elements`
- Impact: warning + potential logic disable
- Suggested labels: `source:playerlog`, `status:watching`
