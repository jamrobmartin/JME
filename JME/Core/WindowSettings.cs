// <copyright file="WindowSettings.cs" company="NoeticDevStudio">
// Copyright (c) NoeticDevStudio. All rights reserved.
// </copyright>

namespace JME.Core;

/// <summary>
/// Represents the configurable settings for the game window.
/// </summary>
public class WindowSettings
{
    /// <summary>
    /// Gets or sets the window width in pixels.
    /// </summary>
    public uint Width { get; set; } = 800;

    /// <summary>
    /// Gets or sets the window height in pixels.
    /// </summary>
    public uint Height { get; set; } = 600;

    /// <summary>
    /// Gets or sets the window title text.
    /// </summary>
    public string Title { get; set; } = "JME - James' Minimalist Engine";

    /// <summary>
    /// Gets or sets a value indicating whether the window should be fullscreen.
    /// </summary>
    public bool Fullscreen { get; set; } = false;

    /// <summary>
    /// Gets or sets a value indicating whether vertical sync (VSync) is enabled.
    /// </summary>
    public bool VSync { get; set; } = true;

    /// <summary>
    /// Gets or sets the framerate limit, in frames per second.
    /// </summary>
    public uint FramerateLimit { get; set; } = 60;
}
