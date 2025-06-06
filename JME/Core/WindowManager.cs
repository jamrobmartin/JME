﻿// <copyright file="WindowManager.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;
using SFML.Window;

namespace JME.Core;

/// <summary>
/// Manages the SFML window, handling creation, settings, event dispatch, and rendering.
/// </summary>
public class WindowManager
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

    // ============================
    // Instance fields
    // ============================

    // private int _exampleInstanceField;

    // ============================
    // Constructors
    // ============================

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowManager"/> class with default settings.
    /// </summary>
    public WindowManager()
        : this(new WindowSettings())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowManager"/> class using the specified window settings.
    /// </summary>
    /// <param name="settings">The window settings to apply.</param>
    public WindowManager(WindowSettings settings)
    {
        Styles style = settings.Fullscreen ? Styles.Fullscreen : Styles.Default;

        window = new RenderWindow(new VideoMode(settings.Width, settings.Height), settings.Title, style);
        window.SetVerticalSyncEnabled(settings.VSync);
        window.SetFramerateLimit(settings.FramerateLimit);

        window.Closed += (sender, e) =>
        {
            CloseRequested?.Invoke();
            window.Close();
        };
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

    /// <summary>
    /// Occurs when the window close event is triggered.
    /// </summary>
    public event Action? CloseRequested;

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
    /// Gets the underlying SFML RenderWindow instance.
    /// </summary>
    public RenderWindow Window => window;

    /// <summary>
    /// Gets a value indicating whether the window is currently open.
    /// </summary>
    public bool IsOpen => window != null && window.IsOpen;

    // ============================
    // Indexers
    // ============================

    // public string this[int index] => "Example";

    // ============================
    // Methods
    // ============================

    // Public Methods

    /// <summary>
    /// Dispatches window events such as input and window actions.
    /// Should be called once per frame.
    /// </summary>
    public void Update() => window.DispatchEvents();

    /// <summary>
    /// Clears and displays the window frame.
    /// Should be called once per frame after all rendering is complete.
    /// </summary>
    public void Render()
    {
        window.Clear(Color.Black);

        // Add render calls here (later we’ll call into the RenderManager)
        window.Display();
    }

    /// <summary>
    /// Closes the window manually.
    /// </summary>
    public void Close() => window.Close();

    // Private Methods

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
