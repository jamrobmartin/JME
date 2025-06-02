// <copyright file="RenderableComponent.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;

namespace JME.Core.ECS;

/// <summary>
/// A component that holds a drawable visual element.
/// The drawable should have its origin properly set.
/// </summary>
public class RenderableComponent : IComponent
{
    /// <summary>
    /// Initializes a new instance of the <see cref="RenderableComponent"/> class.
    /// </summary>
    /// <param name="drawable">The drawable object with preconfigured origin.</param>
    public RenderableComponent(Drawable drawable)
    {
        Drawable = drawable;
    }

    /// <summary>
    /// Gets or sets the owner entity of this component.
    /// </summary>
    public IEntity? Owner { get; set; }

    /// <summary>
    /// Gets or sets the drawable (sprite, shape, etc.) for this component.
    /// </summary>
    public Drawable Drawable { get; set; }
}
