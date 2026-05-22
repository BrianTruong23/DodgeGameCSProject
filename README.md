# Dodge Game

## Overview
Dodge Game is a simple 2D survival game built in Unity. The goal is to stay alive as long as possible while avoiding falling obstacles. The longer you survive, the higher your score climbs.

This repository is the first stage of the project and satisfies the base assignment requirements:

- A live score counter
- A game over screen
- A restart system

The project now includes the additional gameplay feature required by the assignment: a shrinking safe area.

## How The Game Works

- The player moves left and right along the bottom of the screen.
- Obstacles spawn from the top of the scene and fall downward.
- If a falling obstacle touches the player, the game ends.
- The score increases over time based on survival.
- When the game ends, the game freezes and displays a game over message.
- Press `Space` to restart the game immediately.

## Controls

- `A` or `Left Arrow`: Move left
- `D` or `Right Arrow`: Move right
- `Space`: Restart after game over

## Base Requirements Completed

This stage of the project already includes the required core gameplay systems:

### Score Counter
The score increases every frame while the player survives. It is displayed at the top of the screen and updates continuously during gameplay.

### Game Over Screen
When the player collides with an obstacle, the game stops and a game over message appears on screen.

### Restart System
After game over, pressing `Space` reloads the scene and starts a fresh run.

## Additional Feature

This version of the project implements a shrinking safe area.

- The playable area starts wide and gradually narrows over time.
- The player is clamped to the current safe area.
- Falling obstacles spawn within the current safe area.
- The safe area resets when the game restarts.

## How To Launch In Unity

1. Open Unity Hub.
2. Select **Add** and choose this project folder: `DodgeGameCSProject`.
3. Open the project using the Unity version shown in `ProjectSettings/ProjectVersion.txt`.
4. Open the main scene:
   - `Assets/Scenes/SampleScene.unity`
5. Press the **Play** button in the Unity Editor.

## Unity Version

This project was created with:

- `Unity 6000.4.7f1`

## Project Scripts

- `Assets/PlayerMovement.cs` controls player movement and detects collisions.
- `Assets/Spawner.cs` creates falling obstacles at regular intervals.
- `Assets/GameManager.cs` tracks score, handles game over, and restarts the scene.

## Notes

- The project uses the Unity Input System.
- The current build includes the base requirements and the shrinking safe area feature.
