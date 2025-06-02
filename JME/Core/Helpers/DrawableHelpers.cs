// <copyright file="DrawableHelpers.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.Graphics;

namespace JME.Core.Helpers;

/// <summary>
/// Helper Static Class for Drawables.
/// </summary>
public static class DrawableHelpers
{
    /// <summary>
    /// Sets the origin of a sprite to its center.
    /// </summary>
    /// <param name="sprite">The Sprite that you are centering the Origin for.</param>
    public static void CenterOrigin(Sprite sprite)
    {
        IntRect bounds = sprite.TextureRect;
        sprite.Origin = new SFML.System.Vector2f(bounds.Width / 2f, bounds.Height / 2f);
    }

    /// <summary>
    /// Sets the origin of a shape to its center.
    /// </summary>
    /// <param name="shape">The Shape that you are centering the Origin for.</param>
    public static void CenterOrigin(Shape shape)
    {
        FloatRect bounds = shape.GetGlobalBounds();
        shape.Origin = new SFML.System.Vector2f(bounds.Width / 2f, bounds.Height / 2f);
    }
}
