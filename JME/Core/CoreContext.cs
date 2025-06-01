// <copyright file="CoreContext.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

namespace JME.Core;

/// <summary>
/// Represents the core context of the JME engine.
/// Manages core systems, engine initialization, and coordinates update and render calls.
/// </summary>
public class CoreContext
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
    private bool initialized = false;

    // Private Managers
    private WindowManager windowManager = new ();

    // ============================
    // Constructors
    // ============================

    /// <summary>
    /// Initializes a new instance of the <see cref="CoreContext"/> class.
    /// </summary>
    public CoreContext()
    {
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
    /// Occurs when a close has been requested (e.g., window close button clicked).
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
    /// Gets the window manager responsible for handling the SFML window.
    /// </summary>
    public WindowManager WindowManager => this.windowManager;

    /// <summary>
    /// Gets a value indicating whether the core context has been initialized.
    /// </summary>
    public bool Initialized
    {
        get { return this.initialized; }
        private set { this.initialized = value; }
    }

    // ============================
    // Indexers
    // ============================

    // public string this[int index] => "Example";

    // ============================
    // Methods
    // ============================

    /// <summary>
    /// Initializes the core systems of the engine, including the window manager.
    /// </summary>
    /// <param name="customSettings">Optional custom window settings; if null, default settings are used.</param>
    public void Initialize(WindowSettings? customSettings = null)
    {
        Console.WriteLine("CoreContext Initialized");

        WindowSettings windowSettings = customSettings ?? new WindowSettings();

        windowManager = new WindowManager(windowSettings);
        windowManager.CloseRequested += () => { CloseRequested?.Invoke(); };

        initialized = true;
    }

    /// <summary>
    /// Updates all active core systems.
    /// </summary>
    public void Update() => windowManager?.Update();

    /// <summary>
    /// Renders all active core systems.
    /// </summary>
    public void Render() => windowManager?.Render();

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
