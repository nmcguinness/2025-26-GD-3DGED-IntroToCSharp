## C# `ref` and `out` 

### Why use `ref` and `out`?
Normally, method parameters in C# are passed **by value** — a **copy** is made.

Use `ref` or `out` when you want to:

| Keyword | Use Case                         | Must Be Initialized? | Purpose                                |
|---------|----------------------------------|-----------------------|----------------------------------------|
| `ref`   | Modify a variable in-place       |  Yes                | Pass a variable **into and out of** a method |
| `out`   | Return extra data from a method  |  No                 | Pass a value **out only** from a method |

**Key Points**
- `ref` → Input + Output (must be initialized before use)
- `out` → Output only (must be assigned before method ends)
- You must use the keyword **both** at the method declaration and the call site

---

##  Examples

### `ref` Example: Apply Damage

```csharp
void ApplyDamage(ref int health, int damage)
{
    health -= damage;
    if (health < 0) health = 0;
}

int playerHealth = 100;
ApplyDamage(ref playerHealth, 25);
Console.WriteLine(playerHealth); // 75
```

---

### `out` Example: Parse Coordinates

```csharp
bool TryGetSpawnPoint(out int x, out int y)
{
    x = 100;
    y = 200;
    return true; // could be false if not available
}

if (TryGetSpawnPoint(out int sx, out int sy))
    Console.WriteLine($"Spawn at {sx},{sy}");
```

---

### `ref + out` Combined Example

```csharp
void ResolveHit(ref int health, int dmg, out bool isDead)
{
    health -= dmg;
    if (health < 0) health = 0;
    isDead = health == 0;
}
```

---

## Exercises

### Exercise 1 — Use `ref` to Modify Health
**Description:** Write a method `ApplyDamage(ref int health, int damage)` that reduces health and clamps it to zero.  
**Difficulty:** Easy

```csharp
int hp = 50;
ApplyDamage(ref hp, 75); // hp should be 0
```

---

### Exercise 2 — Use `out` to Return Position
**Description:** Write `GetStartPosition(out int x, out int y)` that sets `x=10`, `y=5`.  
Print the values in `Main()`.  
**Difficulty:** Easy

---

### Exercise 3 — Combine `ref` and `out`
**Description:** Write `ResolveHit(ref int health, int damage, out bool isDead)`. If health drops to 0 or below, set `isDead = true`.  
**Difficulty:** Medium

```csharp
int hp = 30;
ResolveHit(ref hp, 50, out bool dead); // hp = 0, dead = true
```

---

### Exercise 4 — Large Struct Optimization 
**Description:** Create a large `struct PlayerStats` (8+ fields). Write a method `UpdateStats(ref PlayerStats stats)` to modify multiple fields.  
Compare performance with and without `ref` using `Stopwatch`.  
**Difficulty:** Hard

```csharp
public struct PlayerStats
{
    public int Strength, Agility, Endurance, Intelligence;
    public int Wisdom, Luck, Charisma, Perception;

    public void Randomize(Random rand)
    {
        Strength = rand.Next(1, 100);
        Agility = rand.Next(1, 100);
        Endurance = rand.Next(1, 100);
        Intelligence = rand.Next(1, 100);
        Wisdom = rand.Next(1, 100);
        Luck = rand.Next(1, 100);
        Charisma = rand.Next(1, 100);
        Perception = rand.Next(1, 100);
    }
}

public static void UpdateStats(ref PlayerStats stats)
{
    stats.Strength += 1;
    stats.Agility += 1;
    stats.Endurance += 1;
    stats.Intelligence += 1;
    stats.Wisdom += 1;
    stats.Luck += 1;
    stats.Charisma += 1;
    stats.Perception += 1;
}

public static void RunStopwatchDemo()
{
    var statsList = new List<PlayerStats>();
    var rand = new Random();

    for (int i = 0; i < 1_000_000; i++)
    {
        var s = new PlayerStats();
        s.Randomize(rand);
        statsList.Add(s);
    }

    var sw = System.Diagnostics.Stopwatch.StartNew();

    for (int i = 0; i < statsList.Count; i++)
    {
        var s = statsList[i];
        UpdateStats(ref s); // Notice the 'ref' improves performance
        statsList[i] = s;   // Structs are copied back into the list
    }

    sw.Stop();
    Console.WriteLine($"Updated 1 million structs in: {sw.ElapsedMilliseconds}ms");
}
```

*Note:* Without `ref`, you'd be mutating a local copy and need to overwrite it manually anyway. But passing by `ref` may reduce overhead when the struct is very large.



---

## Reflective Questions

- Why is `ref` useful for modifying values inside methods?
- How is `out` different from `ref` in terms of initialization?
- Why do both caller and callee need to declare `ref` or `out`?
- When could using `ref` hurt readability or make debugging harder?
- Would you use `ref` with small structs? What about large ones?
