using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class BodyPart:Drawable
    {
        RectangleShape rect;
        public float currentIPos = 0;
        public float currentJPos = 0;
        float body_Size = Game.measurment;
        public BodyPart(float j,float i)
        {
            rect = new RectangleShape(new SFML.System.Vector2f(body_Size, body_Size));
            rect.Texture = Content.textureBody;
            rect.Position = new SFML.System.Vector2f(j * Game.measurment, i * Game.measurment);
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            
            target.Draw(rect);
        }

        public void Move(float j,float i)
        {
            /* rect.Position += new SFML.System.Vector2f(xpos,ypos);
             currentIPos += ypos / Game.measurment;
             currentJPos += xpos / Game.measurment;*/
            rect.Position = new SFML.System.Vector2f(j * Game.measurment, i * Game.measurment);
            currentIPos = i;
            currentJPos = j;
        }

    }
}
