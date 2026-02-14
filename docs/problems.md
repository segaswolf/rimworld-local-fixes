# Problems Log

## Open
- Pawn Editor UI does not open from in-game `Edit` (dev mode).
  - Symptom: `Failed to initialize tab worker` in logs.
  - Stack: `PawnEditor.UITable<T>.Heading..ctor(Texture2D icon, Nullable<float> width)` -> `TabWorker_AnimalMech.Initialize`.
- Fence -> gate material menu intermittently missing in right-click flow.
  - Symptom: material list not shown despite material marker icon.

## Known High-Impact Historical Issues
- Deadlife Rotstink sustainer spam (`still playing after 1000 ticks`).
- `Sequence contains no elements` loop from Stockpile Ranking updates.
- Ghost rendering (`GhostUtility.GhostGraphicFor`) NRE loops causing UI lag.
