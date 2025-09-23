# 3D Game Engine Development – ToDo List

## Overview
This document contains a step-by-step development plan of revision content covered in class. 
The work is structured week-by-week and will be developed **live in class** as a refresher on C# and as a foundation for our custom game engine (`GDEngine`).  

## Goals
- Refresh core C# OOP concepts.
- Discuss design choices.
- Introduce software engineering practices (namespaces, regions, unit testing).
- Build reusable classes for use in the engine.

## Instructions
- Follow the tasks in order (marked with `[ ]` for incomplete and `[x]` for complete).
- Code is developed interactively in class; update this checklist as we progress.
- Unit tests are implemented in a **separate MSTest project** after the class implementation is stable.
- Each week builds on the previous week.

## Exercises

### Week 2 - ColorRGBA from [Class Definition](Exercises/Class%20Definition.md)
- [x] Add `class ColorRGBA` in `GDEngine.Maths`
- [x] Add fields `_r`, `_g`, `_b`, `_a`
- [x] Add properties `R`, `G`, `B`, `A` with clamping (0–1)
- [x] Add constructors (default = white, custom RGBA)
- [x] Add `ToString()` override
- [x] Add `ToGrayscale()` method
- [x] Add operator overloads: `+` (color + color), `*` (color * scalar)
- [x] Add static helpers: `Red`, `Green`, `Blue`, `Black`, `White`
- [x] Add `DeepCopy()` method
- [x] Add `Lerp(ColorRGBA a, ColorRGBA b, float t)` method
- [x] Add HSV conversion methods (`ToHSV`, `FromHSV`)
- [ ] Add unit tests for `ToGrayscale`, `Lerp`, and HSV conversion

---

### Week 1

#### C# Refresher: Vector3 Class
- [x] Add `namespace` (e.g., `GDEngine.Maths`)
- [x] Add `class Vector3`
- [x] Add `fields` (`X`, `Y`, `Z`)
- [x] Add constructor `(float x, float y, float z)`
- [x] Add default constructor and `constructor chaining`
- [x] Add `properties` (get/set) for `X`, `Y`, `Z`
- [x] Add `validation` on set (e.g., disallow NaN, or clamp with ternary operator)
- [x] Add `ToString()` override
- [x] Add `Equals()` override
- [x] Introduce `#region` and `#endregion` for organizing code
  - [x] Group `fields` & `properties`
  - [x] Group `constructors`
  - [x] Group `methods`
  - [x] Group `operator overloads`
  - [x] Group `constants`
- [x] Discuss pros/cons of using `#region` (readability vs collapsing code hides detail)
- [x] Add `Magnitude` 
- [ ] Add `SqrMagnitude` 
- [x] Add `Normalize()` method (mutates vector)
- [x] Add `Normalized` property (returns new normalized vector)
- [x] Add `Dot(Vector3 a, Vector3 b)` static method
- [x] Add `Cross(Vector3 a, Vector3 b)` static method
- [x] Add operator overloads: `+`, `-`, `*`, `/`
- [x] Add static helpers: `Zero`, `One`, `Up`, `Down`, `Forward`, `Backward`
- [x] Tidy Program demos

### Week 2

#### Extensions: Cloning & Code Organization
- [x] Add `Clone()` method (shallow copy using `MemberwiseClone`)
- [x] Add deep cloning method (`DeepCopy()`) – manually copy all fields
- [x] Demonstrate difference between shallow vs deep copies

#### C# Extension: Transform3D Class
- [x] Add `class Transform3D` in `GDEngine.Scene`
- [x] Add `fields` for Position, Rotation, Scale
- [x] Add default constructor (sets Position=Zero, Rotation=Zero, Scale=One)
- [ ] Add constructor chaining for `Transform3D(position)`
- [x] Add `Translate(Vector3 translation)` method
- [x] Add `Rotate(Vector3 eulerAngles)` method
- [x] Add `ScaleBy(Vector3 scaleFactors)` method
- [x] Add `ToString()` override
- [x] Add `Clone()` and `DeepCopy()` methods
- [x] Demonstrate modifying Position and observing effect on copies (shallow vs deep)

#### GDMath Helpers
- [x] Add `class GDMath` in `GDEngine.Maths`
- [x] Add `Clamp(float value)` method
- [x] Add `ToDegrees(float radians)` method
- [x] Add `ToRadians(float degrees)` method

#### Delegates and Functional Programming
- [x] Add `Action` demo
- [x] Add `Func` demo
- [x] Add `Predicate` demo
- [x] Add Lambda expression demos
- [x] Demonstrate using delegates with lists:
  - [x] `ForEach` (Action)
  - [x] `ConvertAll` (Func)
  - [x] `RemoveAll` (Predicate)
  - [x] `TrueForAll` (Predicate)
  - [x] `Find` / `FindAll` (Predicate)
  - [x] `Exists` (Predicate)

#### Testing: Using MSTest
- [ ] Create a **separate MSTest project** in the solution (`GDEngine.Tests`)
- [ ] Add project reference to `GDEngine` project
- [ ] Write first unit test: check `ToString()` output
- [ ] Test: `Magnitude` and `SqrMagnitude`
- [ ] Test: `Normalize()` method
- [ ] Test: `Dot` and `Cross` product correctness
- [ ] Test: operator overloads (`+`, `-`, `*`, `/`)
- [ ] Test: static helpers (`Zero`, `One`, `Up`, etc.)
- [ ] Test: shallow vs deep cloning differences
- [ ] Test: ColorRGBA methods (`ToGrayscale`, `Lerp`, `HSV conversions`)
- [ ] Test: GDMath methods (`Clamp`, `ToDegrees`, `ToRadians`)
- [ ] Run all tests and verify
- [ ] Discuss importance of separating engine code from tests

### Week N...
- [ ] Demonstrate `MemberwiseClone` with Player
- [ ] Add `Forward`, `Right`, and `Up` derived properties to Transform3D
- [ ] Use `ref` and `out` in a function call (see Program)
- [ ] Use `IComparer` in a collection demo 
- [ ] Use `Comparison` in a collection demo 
- [ ] Add event and delegate demo - see EventGenerator
- [ ] Add Singleton pattern demo - see InventoryManager
