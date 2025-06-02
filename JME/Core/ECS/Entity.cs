// <copyright file="Entity.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.System;

namespace JME.Core.ECS;

/// <summary>
/// Concrete implementation of an entity.
/// </summary>
public class Entity : IEntity
{
    // ============================
    // Instance fields
    // ============================
    private readonly Dictionary<Type, IComponent> components = [];

    // ============================
    // Properties
    // ============================

    /// <summary>
    /// Gets the unique ID of the entity.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the logical world position of the entity.
    /// </summary>
    public Vector2f Position { get; set; } = new (0, 0);

    // ============================
    // Public Methods
    // ============================

    /// <summary>
    /// Adds or replaces a component of the specified type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="component">The component instance.</param>
    public void AddComponent<T>(T component)
        where T : class, IComponent
    {
        Type type = typeof(T);
        component.Owner = this;
        components[type] = component;
    }

    /// <summary>
    /// Gets a component of the specified type if it exists.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <returns>The component instance or null.</returns>
    public T? GetComponent<T>()
        where T : class, IComponent
    {
        components.TryGetValue(typeof(T), out IComponent? component);
        return component as T;
    }

    /// <summary>
    /// Checks if the entity has a component of the specified type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <returns>True if the component exists; otherwise, false.</returns>
    public bool HasComponent<T>()
        where T : class, IComponent => components.ContainsKey(typeof(T));

    /// <summary>
    /// Removes a component of the specified type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    public void RemoveComponent<T>()
        where T : class, IComponent => _ = components.Remove(typeof(T));

    /// <summary>
    /// Gets all components currently attached to this entity.
    /// </summary>
    /// <returns>An enumerable of all components.</returns>
    public IEnumerable<IComponent> GetAllComponents() => components.Values;
}
