using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using System.Text;
using System.Threading.Tasks;

namespace Project1 
{
    class Head : Drawable
    {
        public const float head_Size = Game.measurment;
        RectangleShape rect;
      
        public int newi = 0;
        public int newj = 0;
        

        public Head()
        {
            rect = new RectangleShape(new SFML.System.Vector2f(head_Size, head_Size));
            rect.Texture = Content.textureHead;
            
           
        }

        public void Update()
        {





        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(rect);
        }

        public void Move(float a, float b)
        {
            rect.Position = new SFML.System.Vector2f(a * Game.measurment, b * Game.measurment);

        }

        public float GetIPos()
        {
            return rect.Position.Y / Game.measurment;
        }

        public float GetJPos()
        {
            return rect.Position.X / Game.measurment;
        }

    }
}
