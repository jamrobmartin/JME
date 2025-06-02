using JME.Core;
using JME.Core.ECS;
using JMETestGame.TestComponents;
using SFML.Graphics;
using SFML.System;

namespace JMETestGame.TestScenes
{
    /// <summary>
    /// A test scene demonstrating the ECS system.
    /// Creates an entity with a blue square that follows the mouse.
    /// </summary>
    public class ECSTestScene : Scene
    {
        /// <summary>
        /// Called when the scene is first initialized.
        /// Sets up the ECS entities and components.
        /// </summary>
        protected override void OnInitialize()
        {
            // Create a blue square shape (50x50)
            var square = new RectangleShape(new Vector2f(50, 50))
            {
                FillColor = Color.Blue,
                // Center the origin so positioning aligns to the center
                Origin = new Vector2f(25, 25)
            };

            // Create the entity
            var entity = new Entity();

            // Add RenderableComponent
            var renderable = new RenderableComponent(square);
            entity.AddComponent(renderable);

            // Add FollowMouseComponent
            var mouseFollow = new FollowMouseComponent();
            entity.AddComponent(mouseFollow);

            // Add to the world entity manager
            WorldEntityManager.AddEntity(entity);
        }

        /// <summary>
        /// Defines scene-specific update logic.
        /// Nothing needed here — behavior handled by components.
        /// </summary>
        /// <param name="context">The update context for this frame.</param>
        protected override void OnUpdate(UpdateContext context)
        {
            // No scene-specific logic for now
        }

        /// <summary>
        /// Defines scene-specific rendering logic.
        /// Nothing needed here — handled by WorldEntityManager.
        /// </summary>
        /// <param name="renderManager">The render manager.</param>
        protected override void OnRender(RenderManager renderManager)
        {
            // No scene-specific rendering logic for now
        }
    }
}
