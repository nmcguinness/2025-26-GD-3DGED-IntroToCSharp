## C# Structs 

### What is a `struct`?

A **struct** is a lightweight data type that stores a **copy** of its data when assigned or passed to a method.

```csharp
public struct Vector2
{
    public float X;
    public float Y;

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }
}
```

**Key points**
- Structs are **value types** (copied when passed).
- Best used for **small**, self-contained types: positions, colors, IDs.
- Stored by value in memory — no reference or pointer indirection.

---

### Copy Semantics Example
```csharp
var a = new Vector2(1, 1);
var b = a;      // copy
b.X = 99;

Console.WriteLine(a); // (1, 1)
Console.WriteLine(b); // (99, 1)
```

**Key points**
- Modifying `b` does **not** change `a`.
- Structs behave differently from classes, which are reference types.

---

### Readonly Structs (Safe by Design)
```csharp
public readonly struct Health
{
    public int Current { get; }
    public int Max { get; }

    public Health(int current, int max)
    {
        Current = current;
        Max = max;
    }

    public Health WithDelta(int delta) =>
        new Health(Math.Clamp(Current + delta, 0, Max));
}
```

**Key points**
- `readonly struct` improves safety and performance.
- Use methods like `WithDelta()` to return modified copies.

---

### Operator Overloading
```csharp
public struct Vector2
{
    public float X, Y;

    public Vector2(float x, float y) { X = x; Y = y; }

    public static Vector2 operator +(Vector2 a, Vector2 b)
        => new Vector2(a.X + b.X, a.Y + b.Y);
}
```

**Key points**
- Enables natural math operations: `a + b`, `v * scale`, etc.

---

### Struct vs Class — Key Differences

| Feature                  | `struct` (value type)         | `class` (reference type)         |
|--------------------------|-------------------------------|----------------------------------|
| Stored in                | Stack or inline in memory     | Heap (reference stored elsewhere)|
| Assignment               | **Copies** all data           | **Copies reference**, not data   |
| Inheritance              | Cannot inherit                | Can inherit from other classes   |
| Default parameter passing| By value (copy)               | By reference (object reference)  |
| Method types allowed     | Instance, static, operators, overrides  | All method types                        |
| Nullability              | Cannot be `null` (by default) | Can be `null`                    |
| Use case                 | Small, mathy types (e.g. `Vector2`) | Complex data, shared objects (e.g. `Player`) |

---

## Exercises

### Exercise 1 — Your First Struct
**Description:** Define `struct Vector2` with `X`, `Y`, constructor, `Length()` method, and `ToString()`.  
**Difficulty:** Easy

```csharp
public struct Vector2
{
    public float X;
    public float Y;

    public Vector2(float x, float y) { X = x; Y = y; }

    public float Length() => MathF.Sqrt(X * X + Y * Y);
    public override string ToString() => $"({X:0.##}, {Y:0.##})";
}
```

---

### Exercise 2 — Struct Copy Test
**Description:** Show that assigning one struct to another makes a copy. Modify the second and print both.  
**Difficulty:** Easy

```csharp
var a = new Vector2(1, 2);
var b = a;
b.X = 5;

Console.WriteLine(a); // (1, 2)
Console.WriteLine(b); // (5, 2)
```

---

### Exercise 3 — Add Math Operators
**Description:** Add `+` and `*` operators to `Vector2` for addition and scaling.  
**Difficulty:** Easy

```csharp
public struct Vector2
{
    public float X, Y;
    public Vector2(float x, float y) { X = x; Y = y; }

    public static Vector2 operator +(Vector2 a, Vector2 b) => new(a.X + b.X, a.Y + b.Y);
    public static Vector2 operator *(Vector2 v, float s)   => new(v.X * s, v.Y * s);
}
```

---
### Exercise 4 — Collections of Structs
**Description:** Create a `List<Vector2>` and populate it with random values. Sum all positions.  
**Difficulty:** Medium

*Hint:* Use `Random.Shared.NextSingle()` for values.

---

### Exercise 5 — ScreenRect: Immutable Struct with Helpers
**Description:**  
Define a `readonly struct` called `ScreenRect` that represents a rectangular region on screen using four integers: `Left`, `Top`, `Right`, and `Bottom`.

Add:
- A constructor
- A computed `Width` and `Height` property
- A method `Contains(int x, int y)` that checks if a point is inside the rectangle
- Override `ToString()` to return something like: `Rect(Left=0, Top=0, Right=1280, Bottom=720)`

**Difficulty:** Medium

```csharp
public readonly struct ScreenRect
{
    public int Left { get; }
    public int Top { get; }
    public int Right { get; }
    public int Bottom { get; }

    public int Width => Right - Left;
    public int Height => Bottom - Top;

    public ScreenRect(int left, int top, int right, int bottom)
    {
        Left = left;
        Top = top;
        Right = right;
        Bottom = bottom;
    }

    public bool Contains(int x, int y)
        => x >= Left && x <= Right && y >= Top && y <= Bottom;

    public override string ToString()
        => $"Rect(Left={Left}, Top={Top}, Right={Right}, Bottom={Bottom})";
}
```

**Try:**
```csharp
var rect = new ScreenRect(0, 0, 1280, 720);
Console.WriteLine(rect);            // Rect(Left=0, Top=0, Right=1280, Bottom=720)
Console.WriteLine(rect.Contains(64, 64));   // True
Console.WriteLine(rect.Width);     // 1280
Console.WriteLine(rect.Height);    // 720
```

---

## Reflective Questions
- Why does modifying a struct variable not affect the original?
- Why might you choose a `struct` over a `class` in a game?
- What are the benefits of making a struct `readonly`?
- When would you prefer a class instead of a struct for similar data?
