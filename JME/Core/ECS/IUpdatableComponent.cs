// <copyright file="IUpdatableComponent.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

namespace JME.Core.ECS;

/// <summary>
/// Represents a component that requires update logic.
/// Extends <see cref="IComponent"/>.
/// </summary>
public interface IUpdatableComponent : IComponent
{
    /// <summary>
    /// Updates the component with the provided context.
    /// </summary>
    /// <param name="updateContext">The update context for this frame.</param>
    void Update(UpdateContext updateContext);
}
