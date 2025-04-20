# 2D Shape Editor

**2D Shape Editor** is a Windows Forms (WinForms) desktop application developed in C#.  
The application enables users to draw, interact with, and manage 2D geometric shapes on a visual canvas. Tailored to meet client-specific requirements, the application highlights the use of object-oriented design, intuitive graphical user interfaces, and advanced programming features within the .NET framework.

> Developed by Stanimir Petkov using C# and Windows Forms, with a focus on clean architecture, object-oriented design, and practical desktop application development.

---
> ⚠️ The application is still under development. Some features are planned but not yet implemented.

## 🎯 Project Goals

This application is a practical implementation of key programming concepts taught in object-oriented design and software engineering. It serves as a demonstration of:

- Advanced object-oriented programming (inheritance, encapsulation, polymorphism)
- Use of custom event handling with delegates
- Data persistence through serialization
- LINQ-based data processing
- Clean architecture using reusable logic libraries
- Multi-form WinForms interfaces with data transfer between forms

---

## 🧱 Technologies Used

- **Language:** C# (.NET Framework)
- **UI Platform:** Windows Forms
- **Graphics:** GDI+ (`System.Drawing`)
- **Data Access:** LINQ
- **Persistence:** XML / Binary Serialization
- **IDE:** Visual Studio 2019+

---

## 🧠 Implemented Concepts

The project demonstrates the use of the following core programming paradigms:

### ✅ Object-Oriented Fundamentals
| Concept                      | Implementation                                                                                                     |
|------------------------------|----------------------------------------------------------------------------------------------------------|
| Inheritance                 | Abstract `Shape` class with subclasses: `RectangleShape`, `EllipseShape`        |
| Encapsulation            | All fields are accessed and mutated through properties                                        |
| Polymorphism            | Shapes are stored as a list of base type and rendered via virtual methods          |
| Virtual Methods          | `Draw(Graphics g)` is overridden by each shape type                                          |
| Access Modifiers        | Use of `public`, `private`, and `protected` members throughout the application   |
| Properties                  | Properties like `Color`, `Location`, and `Size` defined for each shape                  |
| Delegates & Events   | Custom event handling for shape selection, interaction, and change tracking      |

---

### 🖥️  User Interface & Graphics

- **Multiple Forms:**  
The application features two main forms: one for drawing and one for managing shapes, with full support for data transfer between them.

- **Graphics API Integration:**  
  Shapes are rendered using GDI+ via the `System.Drawing.Graphics` context. Mouse interaction allows selection, movement, and resizing of shapes.

- **Operation Hierarchy:**  
  Encapsulated command pattern structure allows the addition of new operations without modifying existing code.

- **Undo/Redo Support:**  
  History is maintained for actions like shape creation, movement, and deletion. Operations can be undone/redone.
---

### 💾 Advanced Features

- **Data Persistence:**  
  Shapes can be saved and loaded using **serialization**.

- **LINQ Usage:**  
  LINQ is used for:
  - Filtering shapes by type
  - Sorting by size or position
  - Aggregating total area
  - Aggregating average area



- **Reusable Logic Library:**  
  Business logic and shape definitions are moved into a standalone class library, allowing reuse and unit testing without dependencies.

---

## 🖱️ Features Overview

| Feature                         | Status        |
|----------------------------------|---------------|
| Draw 2D shapes                | ✅ Implemented |
| Move, select and resize shapes   | ✅ Implemented |
| Shape-specific logic (color, size) | ✅ Implemented |
| Save/load from file              | ✅ Implemented |
| Undo/Redo functionality          | ✅ Implemented |
| Multiple form interaction        | ✅ Implemented |
| Add new shape types easily       | ✅ Implemented |
| LINQ-based filtering             | ✅ Implemented |
| Shape history, macros, replay    | 🔜 Planned     |

---

## 📸 Screenshots

> Screenshots will be added in a later stage of development.

---

## 🚀 Getting Started

### Requirements
- Windows 10/11
- Visual Studio 2019 or later
- .NET Framework 4.7.2+

## Installation and Running

Clone the repository:

    git clone https://github.com/stasssvp/application-shape-editor.git

## Credits

Developed by: Stanimir Petkov

## License

This project is licensed under the MIT License. See `LICENSE` for more information.
