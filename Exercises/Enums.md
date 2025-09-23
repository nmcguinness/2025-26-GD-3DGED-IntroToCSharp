## C# Enums 

### What is an `enum`?
An **enum** defines a **named set of related constants** (backed by an integral type, default `int`).  
Use enums when a variable should only hold **one of a small set of known values**.

```csharp
public enum GameState
{
    MainMenu,
    Playing,
    Paused,
    GameOver
}
```

**Key points**
- Enums improve **readability** and **type safety** (vs magic numbers/strings).
- Default underlying type is `int`; you can specify another (e.g., `: byte`).
- Default value is `0` (the first member) unless you set it explicitly.

---

### Using Enums
```csharp
GameState state = GameState.Playing;

if (state == GameState.Paused)
{
    Console.WriteLine("Game is paused");
}

switch (state)
{
    case GameState.MainMenu: Console.WriteLine("Press Start"); break;
    case GameState.Playing:  Console.WriteLine("Go!"); break;
    case GameState.Paused:   Console.WriteLine("Paused"); break;
    case GameState.GameOver: Console.WriteLine("GG"); break;
}
```

**Key points**
- Always **handle all cases** in `switch` to avoid silent bugs.
- Prefer enums over strings for **compiler-checked** states.

---

### Setting Explicit Values (when order matters)
```csharp
public enum DamageType
{
    Physical = 0,
    Fire     = 1,
    Ice      = 2
}
```
**Key points**
- Fix values when persisting/saving, networking, or interop needs **stable IDs**.

---

### Changing the Underlying Type
```csharp
public enum ItemRarity : byte
{
    Common = 1,
    Rare   = 2,
    Epic   = 3,
    Mythic = 4
}
```
**Key points**
- Smaller underlying types can reduce memory for **large arrays** or **save files**.
- Don’t mix underlying types for related enums without reason.

---

### Flags Enums (combine options with bitwise OR)
Use **[Flags]** when multiple values can be **combined** at once.

```csharp
[System.Flags]
public enum CollisionLayer
{
    None   = 0,
    Player = 1 << 0, // 1
    Enemy  = 1 << 1, // 2
    Ground = 1 << 2, // 4
    Loot   = 1 << 3  // 8
}

CollisionLayer mask = CollisionLayer.Player | CollisionLayer.Ground;

bool hitsGround = (mask & CollisionLayer.Ground) != 0; // true
```

**Key points**
- Each flag must be a **distinct power of two**.
- Include `None = 0` for “no flags”.
- Use bitwise ops: `|` (add), `&` (check), `~` (invert), `^` (toggle).

---

### Conversions & Parsing
```csharp
// To int
int code = (int)GameState.Playing;

// From int (unsafe if number is invalid)
GameState s = (GameState)2;

// From string safely
if (Enum.TryParse<GameState>("Paused", out var parsed))
{
    Console.WriteLine(parsed); // Paused
}
```

**Key points**
- **Validate** when coming from user input, files, or network (use `Enum.TryParse`).
- Be careful casting from arbitrary ints—could yield **undefined** enum values.

---

### Naming & Structure Tips
- **PascalCase** names for enum types and members.
- Group enums near the types/systems that use them (e.g., `Core/GameState.cs`).
- Avoid “miscellaneous” catch-all enums—keep them **cohesive**.

---

## Exercises

> Create separate `.cs` files for each enum. Keep code small and runnable in a console app.

### Exercise 1 — Basic GameState
**Description:** Create `GameState { MainMenu, Playing, Paused, GameOver }`. Write a method `Describe(GameState s)` that prints a short message for each state using `switch`.  
**Difficulty:** Easy

```csharp
public enum GameState { MainMenu, Playing, Paused, GameOver }

public static void Describe(GameState s)
{
    switch (s)
    {
        case GameState.MainMenu: Console.WriteLine("Press Start"); break;
        case GameState.Playing:  Console.WriteLine("Go!"); break;
        case GameState.Paused:   Console.WriteLine("Paused"); break;
        case GameState.GameOver: Console.WriteLine("Game Over"); break;
    }
}
```

---

### Exercise 2 — Explicit Values for Save/Network
**Description:** Define `DamageType { Physical=0, Fire=1, Ice=2 }`. Write functions to **serialize** to `int` and **deserialize** from `int` (with validation).  
**Difficulty:** Easy

```csharp
public enum DamageType { Physical = 0, Fire = 1, Ice = 2 }

public static int ToCode(DamageType t) => (int)t;

public static bool TryFromCode(int code, out DamageType t)
{
    t = (DamageType)code;
    return Enum.IsDefined(typeof(DamageType), code);
}
```

---

### Exercise 3 — Flags for Collision Layers
**Description:** Create a `[Flags]` enum `CollisionLayer` with `None, Player, Enemy, Ground, Loot` as powers of two.  
Write helpers: `Add(ref CollisionLayer mask, CollisionLayer layer)`, `Has(CollisionLayer mask, CollisionLayer layer)`.  
**Difficulty:** Medium

```csharp
[System.Flags]
public enum CollisionLayer
{
    None   = 0,
    Player = 1 << 0,
    Enemy  = 1 << 1,
    Ground = 1 << 2,
    Loot   = 1 << 3
}

public static void Add(ref CollisionLayer mask, CollisionLayer layer) => mask |= layer;
public static bool Has(CollisionLayer mask, CollisionLayer layer) => (mask & layer) != 0;
```

---

### Exercise 4 — Parsing Player Command
**Description:** Create `PlayerCommand { None, Move, Attack, Interact }`. Read a string (e.g., `"move"`), `TryParse` (case-insensitive) to enum, and execute a `switch`.  
**Difficulty:** Medium

```csharp
public enum PlayerCommand { None, Move, Attack, Interact }

public static bool TryParseCommand(string s, out PlayerCommand cmd) =>
    Enum.TryParse<PlayerCommand>(s, ignoreCase: true, out cmd);
```

---

## Reflective Questions
- When is an enum better than a string or int? Give two examples from your code.
- **Flags enums:** what makes them different from normal enums, and when would you choose them?
- **Validation:** how would you safely handle unknown enum values from a file or server?
- **Design:** where should enum files live in your project so they’re easy to find and maintain?
