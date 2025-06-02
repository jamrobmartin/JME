using JME.Core.ECS;
using JME.Core;
using SFML.System;

namespace JMETestGame.TestComponents
{
    /// <summary>
    /// A component that updates the entity's position to follow the mouse cursor.
    /// </summary>
    public class FollowMouseComponent : IUpdatableComponent
    {
        /// <inheritdoc/>
        public IEntity? Owner { get; set; }

        /// <summary>
        /// Updates the entity's position to match the current mouse position.
        /// </summary>
        /// <param name="context">The update context containing mouse position and frame data.</param>
        public void Update(UpdateContext context)
        {
            if (Owner != null)
            {
                Owner.Position = (Vector2f)context.MousePosition;
            }
        }
    }
}
