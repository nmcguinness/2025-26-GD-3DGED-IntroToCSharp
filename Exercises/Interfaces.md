## C# Interfaces 

### What is an Interface?
An **interface** defines a **contract** — a set of method signatures or properties that a class or struct must implement.

```csharp
public interface IDamageable
{
    void ApplyDamage(int amount);
}
```

Any class that implements `IDamageable` **must** have the `ApplyDamage(int)` method.

---

### Why Use Interfaces?
- Interfaces let you **program to abstractions**, not concrete types.
- Great for **plug-and-play game systems** (weapons, AI, effects).
- Makes your code more **extensible and testable**.

---

### Example: Interface for Damageable Game Object

```csharp
public interface IDamageable
{
    void ApplyDamage(int amount);
}

public class Player : IDamageable
{
    public int Health = 100;

    public void ApplyDamage(int amount)
    {
        Health -= amount;
        Console.WriteLine($"Player took {amount} damage. Health now: {Health}");
    }
}
```

```csharp
void DoHit(IDamageable target)
{
    target.ApplyDamage(10);
}
```

---

### Interface Rules Recap

| Feature                       | Supported |
|------------------------------|-----------|
| Methods                      | Yes        |
| Properties                   | Yes        |
| Fields                       | No        |
| Constructors                 | No        |
| Multiple inheritance         | Yes        |
| Explicit implementation      | Yes       |

---

## Exercises

### Exercise 1 — Create a Simple Interface

**Description:**  
Define an interface `IInteractable` with one method: `void Interact()`.  
Then implement it in a `Door`, `Switch`, and `NPC` class.

**Difficulty:** Easy

---

### Exercise 2 — Upgrade System

**Description:**  
Create an interface `IUpgrade` with method `void Apply(Player player)`.  
Implement two upgrades:
- `HealthBoost` increases health
- `SpeedBoost` increases speed

**Difficulty:** Medium

---

### Exercise 3 — Polymorphic Interaction

**Description:**  
Create a `List<IInteractable>` with mixed objects (e.g., `Door`, `Switch`, `NPC`) and call `Interact()` on each.

**Difficulty:** Medium

---

### Exercise 4 — Object Mods (Game Obstacle System)

**Description:**  
A player can encounter different threats/obstacles. Each obstacle modifies the player:
- Lava pit reduces health
- Laughing gas boosts resistance
- Sad story lowers mood

Define an interface `IModifyObject` and implement multiple modifiers.  
Use a list of objects that implement `IModifyObject` to apply each effect to the player.

**Difficulty:** Medium

---

## Reflective Questions

- Why use an interface instead of an abstract class?
- What’s the benefit of using `List<IModifyObject>` or `List<IApplyDamage>`?
- How do interfaces help you separate data (Player) from behavior (modifier)?

