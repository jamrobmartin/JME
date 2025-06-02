// <copyright file="SceneManager.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;

namespace JME.Core;

/// <summary>
/// Manages a stack of active scenes.
/// Allows pushing and popping scenes to support overlays like pause menus or dialogs.
/// </summary>
public class SceneManager
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
    private readonly Stack<Scene> sceneStack = new ();
    private readonly View defaultView;

    // ============================
    // Instance fields
    // ============================

    // ============================
    // Constructors
    // ============================

    /// <summary>
    /// Initializes a new instance of the <see cref="SceneManager"/> class.
    /// </summary>
    /// <param name="defaultView">The default view of the Render Window.</param>
    public SceneManager(View? defaultView = null)
    {
        this.defaultView = defaultView ?? new View();
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
    /// Gets the scene currently on top of the stack.
    /// </summary>
    public Scene? ActiveScene => sceneStack.Count > 0 ? sceneStack.Peek() : null;

    /// <summary>
    /// Pushes a new scene onto the stack.
    /// </summary>
    /// <param name="scene">The scene to push.</param>
    public void PushScene(Scene scene)
    {
        if (!scene.Initialized)
        {
            scene.Initialize(defaultView);
        }

        sceneStack.Push(scene);
        Console.WriteLine($"SceneManager: Pushed scene '{scene.SceneName}'.");
    }

    /// <summary>
    /// Pops the top scene off the stack.
    /// </summary>
    public void PopScene()
    {
        if (sceneStack.Count > 0)
        {
            Scene removed = sceneStack.Pop();
            Console.WriteLine($"SceneManager: Popped scene '{removed.SceneName}'.");
        }
    }

    /// <summary>
    /// Clears the current scene stack and sets a new active scene.
    /// </summary>
    /// <param name="scene">The scene to set as the only active scene.</param>
    public void SetActiveScene(Scene scene)
    {
        sceneStack.Clear();

        if (!scene.Initialized)
        {
            scene.Initialize(defaultView);
        }

        sceneStack.Push(scene);

        Console.WriteLine($"SceneManager: Set active scene to '{scene.SceneName}'.");
    }

    /// <summary>
    /// Updates the top scene on the stack.
    /// </summary>
    /// <param name="updateContext">Context holding Update Data.</param>
    public void Update(UpdateContext updateContext) => ActiveScene?.Update(updateContext);

    /// <summary>
    /// Renders all scenes on the stack in order (bottom to top).
    /// </summary>
    /// <param name="renderManager">The render manager.</param>
    public void Render(RenderManager renderManager)
    {
        foreach (Scene scene in sceneStack)
        {
            scene.Render(renderManager);
        }
    }

    // Private Methods

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
