// <copyright file="IEntity.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.System;

namespace JME.Core.ECS;

/// <summary>
/// Represents a basic entity in the ECS system.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets the unique ID of the entity.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Gets or sets the logical world position of the entity.
    /// </summary>
    Vector2f Position { get; set; }

    /// <summary>
    /// Adds or replaces a component of the specified type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <param name="component">The component instance.</param>
    void AddComponent<T>(T component)
        where T : class, IComponent;

    /// <summary>
    /// Gets a component of the specified type if it exists.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <returns>The component instance or null.</returns>
    T? GetComponent<T>()
        where T : class, IComponent;

    /// <summary>
    /// Checks if the entity has a component of the specified type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    /// <returns>True if the component exists; otherwise, false.</returns>
    bool HasComponent<T>()
        where T : class, IComponent;

    /// <summary>
    /// Removes a component of the specified type.
    /// </summary>
    /// <typeparam name="T">The component type.</typeparam>
    void RemoveComponent<T>()
        where T : class, IComponent;

    /// <summary>
    /// Gets all components currently attached to this entity.
    /// </summary>
    /// <returns>An enumerable of all components.</returns>
    IEnumerable<IComponent> GetAllComponents();
}
