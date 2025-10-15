# C# Coding Conventions - GDEngine Module

## Overview
Consistent coding style improves readability, reduces bugs, and makes collaboration easier.  

These are the **coding conventions** you must follow when developing in C# for the **module**.  

The goal is to ensure your code is **readable, consistent, and professional**, while helping you build habits expected in real software development teams.  

### 1. Use PascalCase for Class, Struct, Enum, and Interface Names
```csharp
public class PlayerController { }
public struct Matrix4x4 { }
public enum GameState { Menu, Playing, Paused }
public interface IUpdatable { void Update(); }
```

---

### 2. Use PascalCase for Public Members
```csharp
public float Speed { get; set; }
public void Move(Vector3 direction) { }
```

---

### 3. Use camelCase for Local Variables and Parameters
```csharp
float speed = 5f;
Vector3 direction = new Vector3(1, 0, 0);

public void Move(Vector3 direction) { }
```

---

### 4. Prefix Private Fields with an Underscore
```csharp
private float _x;
private float _y;
```

---

### 5. One Class per File
Each `.cs` file should contain **one class or struct**.  
The file name should match the class name.  
```csharp
// Vector3.cs
public class Vector3 { }
```

---

### 6. Use Properties Instead of Public Fields
```csharp
private float _health;
public float Health
{
    get => _health;
    set => _health = value < 0 ? 0 : value; // validation
}
```

---

### 7. Use Meaningful, Descriptive Names
```csharp
// Good
public float MaxSpeed { get; set; }

// Bad
public float ms; // unclear
```

---

### 8. Organize Code with Regions
```csharp
#region Fields
private float _x;
#endregion

#region Methods
public void Normalize() { }
#endregion
```

---

### 9. Keep Methods Short and Focused
- A method should do **one thing well**.  
- If it grows too long, split it into smaller methods.  

---

### 10. Write Comments for *Why*, Not *What*
```csharp
// GOOD: explain reasoning
// Clamp health to avoid negative values
_health = value < 0 ? 0 : value;

// BAD: obvious comment
// Set health to value
_health = value;
```

---

### 11. Use XML Documentation Comments
```csharp
/// <summary>
/// Normalizes this vector in place.
/// </summary>
public void Normalize() { }
```

---

### 12. Always Use Braces
```csharp
// Good
if (isAlive)
{
    TakeDamage();
}

// Bad
if (isAlive) TakeDamage();  // harder to extend safely
```

---

### 13. Avoid Magic Numbers
```csharp
// Good
const float Gravity = -9.81f;
velocity.Y += Gravity * deltaTime;

// Bad
velocity.Y += -9.81f * deltaTime;
```

---

### 14. Use var Wisely
```csharp
// Good: obvious type
var player = new Player();

// Better: explicit when unclear
Matrix4x4 transform = LoadTransform();
```

---

### 15. Be Explicit with Access Modifiers
```csharp
public class Player
{
    private int _score; // write explicitly
}
```

---

## Code Cleanup in Visual Studio
Visual Studio Community 2022 includes a **Code Cleanup** feature that can automatically format and fix many style issues (indentation, spacing, braces, etc.).  

- To use it, click the **broom icon** at the bottom of the editor or press **Ctrl+K, Ctrl+E**.  
- Make Code Cleanup part of your workflow to keep your code consistent with these conventions.  
