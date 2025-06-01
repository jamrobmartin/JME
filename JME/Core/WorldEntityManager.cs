// <copyright file="WorldEntityManager.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;

namespace JME.Core;

/// <summary>
/// Manages all world-space entities and handles their updates and rendering.
/// </summary>
public class WorldEntityManager
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
    private readonly List<Drawable> entities = [];

    // ============================
    // Instance fields
    // ============================

    // private int _exampleInstanceField;

    // ============================
    // Constructors
    // ============================

    /// <summary>
    /// Initializes a new instance of the <see cref="WorldEntityManager"/> class.
    /// </summary>
    /// <param name="view">The initial view.</param>
    public WorldEntityManager(View? view = null)
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
    /// Gets or sets the view of the WorldEntityManager.
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
    /// Adds a world-space entity to the manager.
    /// </summary>
    /// <param name="entity">The drawable entity to add.</param>
    public void AddEntity(Drawable entity)
    {
        if (!entities.Contains(entity))
        {
            entities.Add(entity);
        }
    }

    /// <summary>
    /// Removes a world-space entity from the manager.
    /// </summary>
    /// <param name="entity">The drawable entity to remove.</param>
    public void RemoveEntity(Drawable entity) => _ = entities.Remove(entity);

    /// <summary>
    /// Updates all world-space entities.
    /// </summary>
    public void Update()
    {
        foreach (Drawable entity in entities)
        {
            entity.ToString();
        }
    }

    /// <summary>
    /// Renders all world-space entities using the provided RenderManager.
    /// </summary>
    /// <param name="renderManager">The render manager to use for drawing.</param>
    public void Render(RenderManager renderManager)
    {
        foreach (Drawable entity in entities)
        {
            renderManager.Draw(entity);
        }
    }

    // Private Methods

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
