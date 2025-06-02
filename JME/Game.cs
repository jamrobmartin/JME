// <copyright file="Game.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using System.Diagnostics;
using JME.Core;

namespace JME;

/// <summary>
/// Represents the main game controller for the JME engine.
/// Manages initialization, the main loop, update, render, and shutdown phases.
/// </summary>
public class Game
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
    private readonly CoreContext coreContext = new ();

    // ============================
    // Instance fields
    // ============================
    private bool initialized = false;
    private bool running = false;
    private bool closeRequested = false;

    // FPS tracking
    private double lastFpsUpdate = 0;
    private int frameCount = 0;
    private int fpsCount = 0;

    // ============================
    // Constructors
    // ============================

    /// <summary>
    /// Initializes a new instance of the <see cref="Game"/> class.
    /// </summary>
    public Game()
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
    /// Gets a value indicating whether the game has been initialized.
    /// </summary>
    public bool Initialized
    {
        get { return initialized; }
        private set { initialized = value; }
    }

    /// <summary>
    /// Gets a value indicating whether the game is currently running.
    /// </summary>
    public bool Running
    {
        get { return running; }
        private set { running = value; }
    }

    /// <summary>
    /// Gets the currently active scene.
    /// </summary>
    public Scene? ActiveScene => coreContext.SceneManager?.ActiveScene;

    // ============================
    // Indexers
    // ============================

    // public string this[int index] => "Example";

    // ============================
    // Methods
    // ============================

    /// <summary>
    /// Initializes the game systems and prepares the engine.
    /// </summary>
    /// <param name="customSettings">Optional custom window settings to apply; if null, defaults are used.</param>
    public void Initialize(WindowSettings? customSettings = null)
    {
        coreContext.Initialize(customSettings);
        coreContext.CloseRequested += () => { closeRequested = true; };

        Initialized = true;

        Console.WriteLine("Game.Initialize() has been called");
    }

    /// <summary>
    /// Runs the main game loop, continuously updating and rendering while the game is active.
    /// </summary>
    public void Run()
    {
        if (!Initialized)
        {
            Initialize();
        }

        var sw = Stopwatch.StartNew();
        double latestTime;
        double deltaTime;

        latestTime = sw.Elapsed.TotalSeconds;
        lastFpsUpdate = latestTime;

        Running = true;

        while (Running & !closeRequested)
        {
            double currentTime = sw.Elapsed.TotalSeconds;
            deltaTime = currentTime - latestTime;
            latestTime = currentTime;

            Update(deltaTime);
            Render();
            frameCount++;

            if (latestTime - lastFpsUpdate >= 1.0)
            {
                fpsCount = frameCount;
                frameCount = 0;
                lastFpsUpdate = latestTime;
                Console.WriteLine($"FPS : {fpsCount}");
            }
        }

        ShutDown();

        Console.WriteLine("Game.Run() has been called");
    }

    /// <summary>
    /// Pushes a new scene onto the active scene stack.
    /// </summary>
    /// <param name="scene">The scene to push.</param>
    public void PushScene(Scene scene) => coreContext.SceneManager?.PushScene(scene);

    /// <summary>
    /// Pops the top scene off the active scene stack.
    /// </summary>
    public void PopScene() => coreContext.SceneManager?.PopScene();

    /// <summary>
    /// Clears the current scene stack and sets a new active scene.
    /// </summary>
    /// <param name="scene">The scene to set as the only active scene.</param>
    public void SetActiveScene(Scene scene) => coreContext.SceneManager?.SetActiveScene(scene);

    /// <summary>
    /// Updates the game logic.
    /// </summary>
    /// <param name="deltaTime">The time elapsed since the last update, in seconds.</param>
    private void Update(double deltaTime)
    {
        if (coreContext.Initialized)
        {
            coreContext.Update(deltaTime);
        }
    }

    /// <summary>
    /// Renders the current game frame.
    /// </summary>
    private void Render()
    {
        if (coreContext.Initialized)
        {
            coreContext.Render();
        }
    }

    /// <summary>
    /// Shuts down the game systems and releases resources.
    /// </summary>
    private void ShutDown()
    {
        Initialized = false;

        Console.WriteLine("Game.Shutdown() has been called");
    }

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
