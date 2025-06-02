// <copyright file="UIManager.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;

namespace JME.Core;

/// <summary>
/// Manages all screen-space UI elements and handles their updates and rendering.
/// </summary>
public class UIManager
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
    private readonly List<Drawable> uiElements = [];

    // ============================
    // Instance fields
    // ============================

    // private int _exampleInstanceField;

    // ============================
    // Constructors
    // ============================

    /// <summary>
    /// Initializes a new instance of the <see cref="UIManager"/> class.
    /// </summary>
    /// <param name="view">The initial view.</param>
    public UIManager(View? view = null)
    {
        View = view ?? new View();
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

    /// <summary>
    /// Gets or sets the view of the UIManager.
    /// </summary>
    public View View { get; set; } = new ();

    // ============================
    // Indexers
    // ============================

    // public string this[int index] => "Example";

    // ============================
    // Methods
    // ============================

    // Public Methods

    /// <summary>
    /// Adds a UI element to the manager.
    /// </summary>
    /// <param name="element">The drawable UI element to add.</param>
    public void AddElement(Drawable element)
    {
        if (!uiElements.Contains(element))
        {
            uiElements.Add(element);
        }
    }

    /// <summary>
    /// Removes a UI element from the manager.
    /// </summary>
    /// <param name="element">The drawable UI element to remove.</param>
    public void RemoveElement(Drawable element) => _ = uiElements.Remove(element);

    /// <summary>
    /// Updates all UI elements (if needed).
    /// </summary>
    /// <param name="updateContext">Context holding Update Data.</param>
    public void Update(UpdateContext updateContext) => _ = View.Viewport.Contains(updateContext.MousePosition);

    /// <summary>
    /// Renders all UI elements using the provided RenderManager.
    /// </summary>
    /// <param name="renderManager">The render manager to use for drawing.</param>
    public void Render(RenderManager renderManager)
    {
        foreach (Drawable element in uiElements)
        {
            renderManager.Draw(element);
        }
    }

    // Private Methods

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
