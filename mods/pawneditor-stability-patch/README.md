# Pawn Editor Stability Patch

Runtime safety patch for Pawn Editor mod.

## Problem

Original patches used Harmony Finalizers which caused:
1. `System.NotSupportedException` when patching generic constructors (`Heading<T>::.ctor`)
2. Mod load failures
3. Silent UI crashes when opening Pawn Editor

## Solution

Removed broken Finalizer patches and simplified to only:
- Guard `PreOpen` methods with try-catch
- Guard `TexPawnEditor` static init with texture fallback
- Global try-catch in Bootstrap to prevent mod load crashes

## Known Issues

- Tab UI may still have occasional issues, but game won't crash
- Full fix requires fork of Pawn Editor (future work)
