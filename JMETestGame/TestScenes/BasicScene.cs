using JME.Core;
using SFML.Graphics;
using SFML.System;


namespace JMETestGame.TestScenes
{
    public class BasicScene : Scene
    {
        protected override void OnInitialize()
        {
            // Create a blue circle
            CircleShape circleShape = new(50f)
            {
                FillColor = Color.Blue,

                // Center the circle’s origin
                Origin = new Vector2f(50f, 50f),

                // Place in middle of the screen (assuming 800x600 window)
                Position = new Vector2f(800f / 2f, 600f / 2f)
            };

            UIManager.AddElement(circleShape);
        }

        protected override void OnRender(RenderManager renderManager)
        {
            //
            
        }

        protected override void OnUpdate(UpdateContext updateContext)
        {
            //
        }
    }
}
