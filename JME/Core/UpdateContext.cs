// <copyright file="UpdateContext.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

using SFML.System;

namespace JME.Core;

/// <summary>
/// Update Information.
/// </summary>
public class UpdateContext
{
    /// <summary>
    /// Gets the elapsed time since the last update.
    /// </summary>
    public double DeltaTime { get; init; }

    /// <summary>
    /// Gets the current MousePosition.
    /// In game window coordinates (Confirm this.)
    /// </summary>
    public Vector2i MousePosition { get; init; }

    // Add future fields here
}
