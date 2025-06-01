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

    // ============================
    // Instance fields
    // ============================
    private bool initialized = false;

    // Private Managers
    private WindowManager? windowManager;
    private RenderManager? renderManager;
    private SceneManager? sceneManager;

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
    public WindowManager? WindowManager => this.windowManager;

    /// <summary>
    /// Gets the scene manager responsible for managing scenes.
    /// </summary>
    public SceneManager? SceneManager => this.sceneManager;

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
        WindowSettings windowSettings = customSettings ?? new WindowSettings();

        windowManager = new WindowManager(windowSettings);
        windowManager.CloseRequested += () => { CloseRequested?.Invoke(); };

        renderManager = new RenderManager(windowManager.Window);

        sceneManager = new SceneManager(renderManager.GetDefaultView());

        initialized = true;

        Console.WriteLine("CoreContext Initialized");
    }

    /// <summary>
    /// Updates all active core systems.
    /// </summary>
    /// /// <param name="deltaTime">The time elapsed since the last update call.</param>
    public void Update(double deltaTime)
    {
        windowManager?.Update();
        sceneManager?.Update(deltaTime);
    }

    /// <summary>
    /// Renders all active core systems.
    /// </summary>
    public void Render()
    {
        if (renderManager == null || windowManager == null)
        {
            return;
        }

        renderManager.Clear();

        // Pass RenderManager so scenes can issue draw calls
        sceneManager?.Render(renderManager);

        renderManager.Display();
    }

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
