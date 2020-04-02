using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{

    class Actor:Drawable
    { 
    
        public Shape obj;
        public Texture text;
        public Vector2f pos;
        public float size;

        
        public void PostCreate(ActorArgs args)
        {
            obj = args.m_shape;
            text = args.m_texture;
            pos = args.m_position;
            size = args.m_size;

            obj.Texture = text;
            obj.Position = pos;
        }
        public void Draw(RenderTarget target, RenderStates renderstate)
        {
            target.Draw(obj);
        }

     /*   public void Display(Game game)
        {
            game.window.Display(this);
        }*/
    }
}
