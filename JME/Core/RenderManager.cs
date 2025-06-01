// <copyright file="RenderManager.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;

namespace JME.Core;

/// <summary>
/// Provides a lightweight abstraction over the SFML RenderWindow.
/// Handles basic rendering operations like clearing, drawing, and displaying.
/// </summary>
public class RenderManager
{
    // ============================
    // Constants
    // ============================

    // public const int ExampleConstant = 42;

    // ============================
    // Static readonly fields
    // ============================

    // private static readonly string ExampleStaticReadonlyField;

    // ============================
    // Static fields
    // ============================

    // private static int ExampleStaticField;

    // ============================
    // Instance readonly fields
    // ============================
    private readonly RenderWindow window;
    private readonly Color clearColor = Color.White;

    // ============================
    // Instance fields
    // ============================

    // private int _exampleInstanceField;

    // ============================
    // Constructors
    // ============================

    /// <summary>
    /// Initializes a new instance of the <see cref="RenderManager"/> class.
    /// </summary>
    /// <param name="window">The SFML render window to manage.</param>
    public RenderManager(RenderWindow window)
    {
        this.window = window;
    }

    // ============================
    // Finalizers
    // ============================

    // ~YourClassName()
    // {
    // }

    // ============================
    // Delegates
    // ============================

    // public delegate void ExampleDelegate();

    // ============================
    // Events
    // ============================

    // public event ExampleDelegate? ExampleEvent;

    // ============================
    // Enums
    // ============================

    // public enum ExampleEnum { Value1, Value2 }

    // ============================
    // Interfaces
    // ============================

    // public interface IExampleInterface { }

    // ============================
    // Properties
    // ============================

    // public int ExampleProperty { get; set; }

    // ============================
    // Indexers
    // ============================

    // public string this[int index] => "Example";

    // ============================
    // Methods
    // ============================

    // Public Methods

    /// <summary>
    /// Clears the render window with the configured clear color.
    /// </summary>
    public void Clear() => window.Clear(clearColor);

    /// <summary>
    /// Draws a single SFML drawable object onto the render window.
    /// </summary>
    /// <param name="drawable">The drawable object to render.</param>
    public void Draw(Drawable drawable) => window.Draw(drawable);

    /// <summary>
    /// Displays the contents of the render window.
    /// </summary>
    public void Display() => window.Display();

    /// <summary>
    /// Sets the view of the window.
    /// </summary>
    /// <param name="view">The view to set in the window.</param>
    public void SetView(View view) => window.SetView(view);

    /// <summary>
    /// Gets the default View of the RenderWindow.
    /// </summary>
    /// <returns>The default View of the RenderWindow.</returns>
    public View GetDefaultView() => window.DefaultView;

    // Private Methods

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
