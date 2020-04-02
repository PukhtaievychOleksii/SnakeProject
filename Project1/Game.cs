using HelloWorld;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    enum Direction
    {
        Left,
        Right,
        Up,
        Down

    }
    class Game
    {
        public static Direction direction;
        public  const float measurment = 80f;
        public  RenderWindow window;
        private bool wantToClose = false;
        private uint max_FPS_Limit = 60;
        public bool[,] movingField;
        public List<Actor> actorList = new List<Actor>();
        public readonly uint SCREEN_WIDTH;
        public readonly uint SCREEN_HEIGHT;
        private Settings settings;
        public Vector2u ScreenResolution { get; private set; }

        Snake snake;
        
        private  float timeStep;
        private void ChangeResolution(Vector2u newResolution)
        {
            ScreenResolution = newResolution;
            RecreateWindow(ScreenResolution);
        }

        private void RecreateWindow(Vector2u ScreenResolution)
        {
            window = new RenderWindow(new VideoMode(ScreenResolution.X, ScreenResolution.Y), "SFML window");
            //window.Closed += new EventHandler(OnClose);
        }

        public void Run()
        {
            Init();
            RecreateWindow(new Vector2u(800, 800));
            while (IsGameRun())
            {
               
                Input();
                Logic();
                Draw();
            }
        }

        private void Init()
        {
            window = new RenderWindow(new VideoMode(800, 800), "SFML window");
            Content.Load();
            this.CreateInternalActor<Actor>(new ActorArgs(new Texture(Content.textureBody),new CircleShape(20),new Vector2f(600,600),10));
            direction = Direction.Up;
            timeStep = 1f / max_FPS_Limit;
            float a = window.Size.X / measurment;
            float b = window.Size.Y / measurment;
            movingField = new bool[(int)a,(int)b] ;
            // window.SetFramerateLimit(max_FPS_Limit);
            snake = new Snake();
            


        }

        public void Input()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left)) direction = Direction.Left;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) direction = Direction.Up;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) direction = Direction.Down;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right)) direction = Direction.Right;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape)) wantToClose = true;
            snake.InputActions();

        }

        public void Logic()
        {

            snake.Update();

        }

        public bool IsGameRun()
        {
            return window.IsOpen && !wantToClose;
        }

        public void Draw()
        {
            window.Clear();
            snake.Draw(this);
            foreach(Drawable @object in actorList)
            {
                //@object.Draw(window, RenderStates.Default);
                window.Draw(@object);
            }
            window.Display();
        }

        
        public void RegisterActor(Actor actor)
        {
            actorList.Add(actor);
        }

    }
}
