# 🍉 Fruit Splash

**Made by Sawera**

A 2D fruit-slicing game built in Unity, inspired by the classic *Fruit Ninja*. Swipe across the screen to slice flying fruits, rack up your score, and don't let too many fall  you only get 3 lives!

## 🎮 Gameplay

- Fruits (apple, banana, orange, strawberry, watermelon) spawn randomly and launch upward from the bottom of the screen.
- Swipe/drag your mouse across a fruit to slice it — each successful slice adds to your score and triggers a slice sound + splatter effect.
- Miss a fruit and let it fall off-screen, and you lose a life.
- Lose all 3 lives and it's Game Over, with the option to restart or return to the main menu.

## ✨ Features

- Smooth blade-trail swipe mechanic with velocity-based cutting detection
- Randomized fruit spawning across multiple spawn points
- Score and lives tracking with live UI updates
- Sliced-fruit particle prefabs for a satisfying splash effect
- Sound effects for slicing and game over
- Main menu with a Play button, plus restart/menu options on the Game Over screen

## 🛠️ Tools & Technologies

- **Unity** — Game engine
- **C#** — Scripting
- **Visual Studio Code** — Code editor

## 📁 Project Structure

```
Assets/
├── Scripts/
│   ├── Blade.cs           # Handles swipe input and slicing detection
│   ├── FruitBehaviour.cs  # Fruit physics, slicing response, miss detection
│   ├── FruitSpawner.cs    # Randomized fruit spawning logic
│   ├── GameManager.cs     # Score, lives, game over, and scene management
│   └── MainMenu.cs        # Main menu / play button logic
├── Prefabs/                # Fruit prefabs (whole + sliced versions)
├── Pictures/                # Sprites and UI images
├── Sounds/                  # Slice and Game Over sound effects
└── Scenes/                  # MenuScene and SampleScene (gameplay)
```

## ▶️ How to Run

1. Open the project folder in **Unity Hub** (Unity 2020+ recommended).
2. Open the `MenuScene` from `Assets/Scenes/`.
3. Press **Play** in the Unity Editor, or build the project for your target platform.

## 🙌 Credits

Fruit Splash — a Fruit Ninja–inspired project, developed and customized by **Sawera**.
