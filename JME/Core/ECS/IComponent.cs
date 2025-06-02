// <copyright file="IComponent.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

namespace JME.Core.ECS;

/// <summary>
/// Represents a component that can be attached to an entity.
/// </summary>
public interface IComponent
{
    /// <summary>
    /// Gets or sets the owner entity of this component.
    /// </summary>
    IEntity? Owner { get; set; }
}
