// <copyright file="WorldEntityManager.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using JME.Core.ECS;
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
    private readonly List<IEntity> entities = [];

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
    // Public Methods
    // ============================

    /// <summary>
    /// Adds an entity to the manager.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    public void AddEntity(IEntity entity)
    {
        if (!entities.Contains(entity))
        {
            entities.Add(entity);
        }
    }

    /// <summary>
    /// Removes an entity from the manager.
    /// </summary>
    /// <param name="entity">The entity to remove.</param>
    public void RemoveEntity(IEntity entity) => _ = entities.Remove(entity);

    /// <summary>
    /// Updates all entities and their components.
    /// </summary>
    /// <param name="updateContext">Context holding Update Data.</param>
    public void Update(UpdateContext updateContext)
    {
        foreach (IEntity entity in entities)
        {
            foreach (IUpdatableComponent component in GetUpdatableComponents(entity))
            {
                component.Update(updateContext);
            }
        }
    }

    /// <summary>
    /// Renders all entities that have a renderable component.
    /// </summary>
    /// <param name="renderManager">The render manager to use for drawing.</param>
    public void Render(RenderManager renderManager)
    {
        foreach (IEntity entity in entities)
        {
            RenderableComponent? renderable = entity.GetComponent<RenderableComponent>();
            if (renderable != null)
            {
                // Set the drawable’s position to match the entity’s position
                if (renderable.Drawable is Transformable transformable)
                {
                    transformable.Position = entity.Position;
                }

                renderManager.Draw(renderable.Drawable);
            }
        }
    }

    // ============================
    // Private Helpers
    // ============================

    /// <summary>
    /// Retrieves all updatable components from the entity.
    /// </summary>
    /// <returns>A list of all IUpdateableComponents.</returns>
    /// <param name="entity">The entity to get Updateable Components from.</param>
    private static IEnumerable<IUpdatableComponent> GetUpdatableComponents(IEntity entity)
    {
        foreach (IComponent component in entity.GetAllComponents())
        {
            if (component is IUpdatableComponent updatable)
            {
                yield return updatable;
            }
        }
    }

    // ============================
    // Nested Types (Structs, Classes, Interfaces)
    // ============================

    // public class NestedClass { }
}
