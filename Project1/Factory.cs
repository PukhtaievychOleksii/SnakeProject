using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public struct ActorArgs
    {
       public  Texture m_texture;
        public Shape m_shape;
        public Vector2f m_position;
        public float m_size;
        public ActorArgs(Texture texture,Shape shape,Vector2f position,float size)
        {
            m_texture = texture;
            m_shape = shape;
            m_position = position;
            m_size = size;
        }
    }

   static class Factory
    {
        public static T CreateInternalActor<T>(this Game game,ActorArgs args) where T : Actor,new()
        {
            /*Actor actor = new Actor();
            actor.intr = args.intrect;
            actor.text = args.texture;
            actor.pos = args.position;
            actor.obj = args.shape;*/
            T t = new T();
            t.PostCreate(args);
            game.RegisterActor(t);
            return t;

        }

       

    }
}
