// <copyright file="Scene.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace JME.Core;

/// <summary>
/// Represents an abstract base class for all game scenes.
/// Handles initialization, updating, and rendering logic.
/// </summary>
public abstract class Scene
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

    // private readonly string _exampleInstanceReadonlyField;

    // ============================
    // Instance fields
    // ============================

    // ============================
    // Constructors
    // ============================

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
    /// Gets a value indicating whether the scene has been initialized.
    /// </summary>
    public bool Initialized { get; private set; } = false;

    /// <summary>
    /// Gets or sets the name of the scene.
    /// </summary>
    public string SceneName { get; set; } = "Unnamed Scene";

    /// <summary>
    /// Gets the world entity manager for managing world-space entities.
    /// </summary>
    protected WorldEntityManager WorldEntityManager { get; private set; } = new ();

    /// <summary>
    /// Gets the UI manager for managing screen-space UI elements.
    /// </summary>
    protected UIManager UIManager { get; private set; } = new ();

    // ============================
    // Indexers
    // ============================

    // public string this[int index] => "Example";

    // ============================
    // Methods
    // ============================

    // Public Methods

    /// <summary>
    /// Initializes the scene.
    /// </summary>
    /// <param name="defaultView">The default view of the render window.</param>
    public void Initialize(View defaultView)
    {
        if (!Initialized)
        {
            UIManager.View = defaultView;
            WorldEntityManager.View = defaultView;
            OnInitialize();
            Initialized = true;
        }
    }

    /// <summary>
    /// Updates the scene.
    /// </summary>
    /// <param name="deltaTime">The time elapsed since the last update.</param>
    public virtual void Update(double deltaTime)
    {
        Vector2i mousePosition = Mouse.GetPosition(); // Adjust if you want window-relative positions
        UIManager.Update(mousePosition);
        WorldEntityManager.Update();
        OnUpdate(deltaTime);
    }

    /// <summary>
    /// Renders the scene.
    /// </summary>
    /// <param name="renderManager">The render manager to issue draw calls.</param>
    public virtual void Render(RenderManager renderManager)
    {
        renderManager.SetView(WorldEntityManager.View);
        WorldEntityManager.Render(renderManager);

        renderManager.SetView(UIManager.View);
        UIManager.Render(renderManager);

        OnRender(renderManager);
    }

    /// <summary>
    /// Called when the scene is first initialized.
    /// Override this to set up scene-specific content.
    /// </summary>
    protected abstract void OnInitialize();

    /// <summary>
    /// Override to define scene-specific update logic.
    /// </summary>
    /// <param name="deltaTime">The time elapsed since the last update.</param>
    protected abstract void OnUpdate(double deltaTime);

    /// <summary>
    /// Override to define scene-specific rendering logic.
    /// </summary>
    /// <param name="renderManager">The render manager.</param>
    protected abstract void OnRender(RenderManager renderManager);

    // Private Methods

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
