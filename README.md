# 2025 - 26 - GD - C# Concepts for Game Developers in GD3

## Overview 

This repository contains code samples used to learn the basics of C# in preparation for the development of the code for this module.
The module descriptor can be viewed [here](https://courses.dkit.ie/index.cfm/page/module/moduleId/55573).

## Contents

## C# for Game Development

| #  | Completed | Topic                            | Description                                                                 | Recommended Reading                                                                                           |
|----|:---------:|----------------------------------|-----------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| 1  | <ul><li>- [x] </li></ul> | **Namespace Definition**                  | Organizing game code using namespaces to prevent conflicts.                 | [Namespace](https://www.tutorialspoint.com/csharp/csharp_namespaces.htm)                                       |
| 2  | <ul><li>- [ ] </li></ul> | **Value and Reference Types**             | Managing memory in Unity by understanding value and reference types.        | [Value type and Reference type](https://www.tutorialsteacher.com/csharp/csharp-value-type-and-reference-type)  |
| 3  | <ul><li>- [ ] </li></ul> | **Class Definition & Inheritance**        | Class structures, inheritance, and polymorphism in game development.        | [Class & Object](https://www.geeksforgeeks.org/c-sharp-class-and-object/)                                      |
| 4  | <ul><li>- [ ] </li></ul> | **Interfaces**                            | Implementing interfaces for game systems (e.g., input handling, AI).        | [Interfaces](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/)                    |
| 5  | <ul><li>- [ ] </li></ul> | **Types (struct, enum)**                  | Use of `struct` for data (e.g., Vector3) and `enum` for states in Unity.    | [Struct](https://www.tutorialsteacher.com/csharp/csharp-struct), [Enum](https://www.geeksforgeeks.org/c-sharp-enumeration-or-enum/) |
| 6  | <ul><li>- [x] </li></ul> | **Properties**                            | Using properties to control access to fields in Unity game objects.         | [C# Properties](https://www.geeksforgeeks.org/c-sharp-properties/)                                             |
| 7 | <ul><li>- [x] </li></ul> | **Static Methods & Fields**               | Using static methods and fields for global utilities (e.g., GameManager).   | [Static Methods](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members) |
| 8 | <ul><li>- [x] </li></ul> | **Operator Overloading**                  | Overloading operators for custom operations in game physics or math.        | [Operator Overloading](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/operator-overloading) |
| 9 | <ul><li>- [ ] </li></ul> | **Indexers**                              | Simplifying access to collections in game classes (e.g., inventory).        | [Indexers](https://www.tutorialspoint.com/csharp/csharp_indexers.htm)                                          |
| 10 | <ul><li>- [x] </li></ul> | **Shallow vs Deep Copy**                  | Handling object references and copies.                                      | [Shallow vs Deep Copy](https://www.geeksforgeeks.org/shallow-copy-and-deep-copy-in-c-sharp/)                   |
| 11 | <ul><li>- [ ] </li></ul> | **Containers (List)**              | Managing collections of game objects using `List<T>`.   | [C# List Tutorial](https://www.c-sharpcorner.com/article/c-sharp-list/)                                        |
| 12 | <ul><li>- [ ] </li></ul> | **SortedList & Dictionary**               | Using `SortedList` and `Dictionary` for quick lookups in games.             | [SortedList](https://www.tutorialspoint.com/csharp/csharp_collections.htm)                                     |

## C# Memory & Performance

| #  | Completed | Topic                            | Description                                                                 | Recommended Reading                                                                                           |
|----|:---------:|----------------------------------|-----------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| 1  | <ul><li>- [ ] </li></ul> | **Keywords (ref, out)**                   | Use of `ref` and `out` to optimize memory in functions.                     | [ref](https://www.geeksforgeeks.org/ref-in-c-sharp/), [out](https://www.geeksforgeeks.org/out-parameter-with-examples-in-c-sharp/) |
| 2 | <ul><li>- [ ] </li></ul> | **Garbage Collection & Memory Management** | Understanding C# garbage collection to avoid performance issues.            | [Garbage Collection in Unity](https://docs.unity3d.com/Manual/performance-garbage-collector.html)              |
| 3 | <ul><li>- [ ] </li></ul> | **Game Optimization & Profiling**         | Using the profiler to optimize code and memory usage in games.          | [Measure app performance in Visual Studio](https://learn.microsoft.com/en-us/visualstudio/profiling/?view=vs-2022)                                                |

## Advanced C# Techniques

| #  | Completed | Topic                            | Description                                                                 | Recommended Reading                                                                                           |
|----|:---------:|----------------------------------|-----------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| 1 | <ul><li>- [ ] </li></ul> | **Predicate & Lambda Expressions**        | Using `Predicate` and Lambda Expressions to filter and find game objects.   | [Predicate](https://www.tutorialsteacher.com/csharp/csharp-predicate), [Lambda Expressions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions) |
| 2 | <ul><li>- [ ] </li></ul> | **Func & Action**                         | Passing game logic as parameters for AI or state machines.                  | [Func](https://www.tutorialsteacher.com/csharp/csharp-func-delegate), [Action](https://www.tutorialsteacher.com/csharp/csharp-action-delegate) |
| 3 | <ul><li>- [ ] </li></ul> | **Delegates & Events**           | Implementing event-driven gameplay using C# delegates and events.           | [Delegate](https://www.tutorialsteacher.com/csharp/csharp-delegates), [Event](https://www.tutorialspoint.com/csharp/csharp_events.htm) |
| 4 | <ul><li>- [ ] </li></ul> | **Async & Await**                         | Using `async` and `await` for asynchronous operations in our engine.             | [Async and Await](https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/)                    |

## Miscellaneous Techniques

| #  | Completed | Topic                            | Description                                                                 | Recommended Reading                                                                                           |
|----|:---------:|----------------------------------|-----------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|
| 1  | <ul><li>- [ ] </li></ul> | **String Interpolation**                  | Efficient string handling for debugging and logging in Unity.               | [String interpolation](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated) |
| 2  | <ul><li>- [ ] </li></ul> | **Constructor Chaining**                  | Creating versatile constructors using constructor chaining.                 | [Constructor Chaining](https://www.delftstack.com/howto/csharp/constructor-chaining-in-csharp/)                |

## Coding Conventions

- [Coding Conventions](Notes/CodingConventions.md)

## Required Reading 

- [Tutorials Teacher - Learn C#](https://www.tutorialsteacher.com/csharp)
- [Refactoring Guru - Design Patterns](https://refactoring.guru/design-patterns) 
- **Under Construction** - [Summary - Action, Func, Delegate, and Event in C#](Reading/csharp_delegates.md)

## Recommended Reading 

- [The C# type system](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types)
- [Generate a constructor in Visual Studio](https://learn.microsoft.com/en-us/visualstudio/ide/reference/generate-constructor?view=vs-2019)
- [Standard numeric format strings](https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings)
## Exercises

1. [Namespace Definition](Exercises/Namespace%20Definition.md)
2. [Class Definition](Exercises/Class%20Definition.md)
3. [Value & Reference Types](Exercises/Value%20and%20Reference%20Types.md)
4. [Structs and Enums](Exercises/Structs%20and%20Enums.md)
5. [Lists & Predicates](Exercises/Lists%20and%20Predicates.md)
6. [Keywords](Exercises/Keywords.md)
7. [Design Exercises](Exercises/Design%20Exercises.md)

## Useful Links
- [Markdown](https://docs.github.com/en/enterprise-cloud@latest/get-started/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax) in GitHub
- Add emojis with [gitmoji](https://gitmoji.dev/) to your Git commits to improve readability

## To Do 

- [Weekly Development Plan](ToDo.md)




