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

### Phase 1

- Bugs
  - Rectangles that get randomly created and move with set speed (no textures)
  - **Not in planning but added** - Randomly stop and continue
- Turret
  - Rectangle that pivots and shoots rectangles (no textures)
  - Follow mouse
- Code
  - Basic gameloop
- UI/Player
  - No lives
  - No points
- Gameplay
  - No dying (player or bugs)

### Phase 2

- Bugs
  - Remove rectangle when outside screen
  - Remove rectangle when touching bullet rectangles
- Turret
  - Remove bullets when hitting bugs or outside screen
- Code
  - Sprite interaction
  - Removing of sprites (Implement spawner/handler?)
- UI/Player
- Gameplay
  - Bugs die when hit

### Phase 3

- Bugs
  - Random change of direction
- Turret
- Code
- UI/Player
  - Counter when killing bugs
- Gameplay
  - Primitive game score is shown

### Phase 4

- Bugs
  - Crawl up wall, remove when reaching top
- Turret
  - Limit movement, little lag after mouse
  - Not att the way up too???
- Code
- UI/Player
- Gameplay
