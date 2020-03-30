# bug-fixer

## Vision

> Perfect is the enemy of the good

> Make it work, then make it nice

### Gameplay

Gattling/big gun/turret, attached to the top of the screen. Aim the turret with the mouse and shoot by clicking. Bugs, larvae and caterpillars will crawl across the ground from one side of the screen to the other. Kill them before they reach the side of the screen, where they will crawl up the side and crawl into your turrent.

### Goal/Win

There is no winning, only faster, bigger bugs.

### Planned Features

- Bugs

  - Faster as the game progresses
  - Stop randomly, change direction, evade incoming bullets
  - Dies with an explosion with the text "PATCHED/SQUASHED/MERGED/FIX"
  - Big bug every major/minor
  - Crawl up sides and on the ceiling into the turret

- Turret

  - Shoots 1's and 0's
  - Pivot with som lag and aim where the mouse is (simulating a heavy turret)
  - Can't aim all the way up? _Added after Phase 1_
  - When damaged pop up text "+1 Feature"
  - Updated sprite when damaged

- UI/Player
  - 3 lives
  - Points like major.minor.patch (v 0.0.1 -> One point)

## Phases

### Phase 1 - Complete

- Bugs
  - ~~Rectangles that get randomly created and move with set speed (no textures)~~
  - ~~Randomly stop and continue~~ (Not in planning but added)
- Turret
  - ~~Rectangle that pivots and shoots rectangles (no textures)~~
  - ~~Follow mouse~~
- Code
  - ~~Basic gameloop~~
- UI/Player
  - ~~No lives~~
  - ~~No points~~
- Gameplay
  - ~~No dying (player or bugs)~~ (Bugs die from bullets)

### Phase 2 - Complete

- Bugs
  - ~~Remove rectangle when outside screen~~ (scrapped)
  - ~~Remove rectangle when touching bullet rectangles~~
- Turret
  - ~~Remove bullets when hitting bugs or outside screen~~
- Code
  - ~~Sprite interaction~~
  - ~~Removing of sprites (Implement spawner/handler?)~~
- Gameplay
  - ~~Bugs die when hit~~

### Phase 3 - Complete

- Bugs
  - ~~Random change of direction~~
- UI/Player
  - ~~Counter when killing bugs~~
- Gameplay
  - ~~Primitive game score is shown~~

### Phase 4 - Complete

- Bugs
  - ~~Crawl up wall, remove when reaching top~~ (no removal)
- Turret
  - ~~Limit movement, little lag after mouse~~
  - Not att the way up too? - Not right now atleast

### Phase 5

- Bugs
  - Crawl on the ceiling, remove when reaching the turret
- Turret
  - Loses health when bug reaches it
- UI/Player
  - Implement health

### Phase 6

- Bugs
  - When die, fall (if on wall/ceiling) and slowly fade away
- UI/Player
- Gameplay
  - Game over screen

### Phase 7

- UI/Player
- Gameplay
  - Play/Start button
