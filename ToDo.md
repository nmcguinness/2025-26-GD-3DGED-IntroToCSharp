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

### Week 1

#### C# Refresher: Vector3 Class
- [x] Add `namespace` (e.g., `GDEngine.Math`)
- [x] Add `class Vector3`
- [x] Add `fields` (`X`, `Y`, `Z`)
- [x] Add constructor `(float x, float y, float z)`
- [ ] Add default constructor and `constructor chaining`
- [x] Add `properties` (get/set) for `X`, `Y`, `Z`
- [x] Add `validation` on set (e.g., disallow NaN, or clamp with ternary operator)
- [x] Add `ToString()` override
- [ ] Add `Èquals()` override
- [ ] Introduce `#region` and `#endregion` for organizing code
  - [ ] Group `fields` & `properties`
  - [ ] Group `constructors`
  - [ ] Group `methods`
  - [ ] Group `operator overloads`
  - [ ] Group `static helpers`
- [ ] Discuss pros/cons of using `#region` (readability vs collapsing code hides detail)
- [ ] Add `Magnitude` and `SqrMagnitude` properties
- [ ] Add `Normalize()` method (mutates vector)
- [ ] Add `Normalized` property (returns new normalized vector)
- [ ] Add `Dot(Vector3 a, Vector3 b)` static method
- [ ] Add `Cross(Vector3 a, Vector3 b)` static method
- [ ] Add operator overloads: `+`, `-`, `*`, `/`
- [ ] Add static helpers: `Zero`, `One`, `Up`, `Down`, `Forward`, `Backward`
- [ ] Discuss `struct` vs `class` (value vs reference types)
- [ ] Discuss performance: `SqrMagnitude` vs `Magnitude`

#### Extensions: Cloning & Code Organization
- [ ] Add `Clone()` method (shallow copy using `MemberwiseClone`)
- [ ] Add deep cloning method (`DeepClone()`) – manually copy all fields
- [ ] Demonstrate difference between shallow vs deep copies

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
- [ ] Run all tests and verify.
- [ ] Discuss importance of separating engine code from tests

 
### Week N...
- [ ] Use `ref` and `out` in a function call (see Program)
- [ ] Use IComparer in a collection demo 
- [ ] Use Comparison in a collection demo 
- [ ] Add event and delegate demo - see EventGenerator
- [ ] Add Action, Func, Predicate demo - see Program 
- [ ] Add Singleton pattern demo - see InventoryManager

