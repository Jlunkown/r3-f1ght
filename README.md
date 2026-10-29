# R3_f1ght

A top-down shooter where every round reshuffles how you play. Clear the wave and your character gets a random weapon and a random way of moving.

Made in Unity for **Brackeys Game Jam 2023.1** (theme: *An End Is a New Beginning*).

▶ **Play it in the browser on itch.io: [jlunknown.itch.io/r3-f1ght](https://jlunknown.itch.io/r3-f1ght)**

## How it plays

When you kill every enemy, the round ends and the next one starts with a new loadout:

- **Weapons:** bow, gun or bash
- **Movement:**
  - **Land:** move with W / S
  - **Water:** hold W to swim forward, drifting with momentum
  - **Air:** you fly forward on your own; hold Space to slow down

## Controls

| Input | Action |
| --- | --- |
| Mouse | Aim / turn |
| Left click | Attack |
| W / S | Move (depends on movement style) |
| Space | Slow down while flying |

## Project

- Engine: Unity **2020.3.32f1**
- Main scene: `Assets/Scenes/SampleScene.unity`
- Gameplay scripts: `Assets/scripts/` (player, weapons, enemies, spawner, game manager)

To open it, add this folder in Unity Hub with editor 2020.3.32f1 and open `SampleScene`. Builds are not stored in the repo; play the jam build on itch.io.

## Author

Made by [Jlunknown](https://jlunknown.itch.io).
