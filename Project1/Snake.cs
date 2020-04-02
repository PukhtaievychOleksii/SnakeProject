using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Snake
    {
        Head head;
        public List<BodyPart> body;
        int changei = 0;
        float tipaTime = 5f;
        float border = 800 / Game.measurment;
        int changej = 0;
        float headipos = 0;
        float headjpos = 0;

        public Snake()
        {
            head = new Head();
            body = new List<BodyPart>();

        }

        public void InputActions()
        {
         //   if (Keyboard.IsKeyPressed(Keyboard.Key.F)) CreateBodyPart();


        }
        public void Update()
        {
            head.Update();
            TimeChecker();
            headipos = head.GetIPos();
            headjpos = head.GetJPos();
            switch (Game.direction)
            {
                case Direction.Left:
                    changei = 0;
                    changej = -1;
                    break;

                case Direction.Up:
                    changei = -1;
                    changej = 0;
                    break;

                case Direction.Right:
                    changej = 1;
                    changei = 0;
                    break;

                case Direction.Down:
                    changej = 0;
                    changei = 1;
                    break;
            }

        }

        public void Draw(Game game)
        {
            game.window.Draw(head);
            
            if (body.Count > 0)
            {
                foreach (BodyPart i in body)
                {
                   game.window.Draw(i);
                }
            }
        }

        public void CreateBodyPart()
        {
           float bodyIPos = headipos;
            float bodyJPos = headjpos;
            if (body.Count != 0)
            {
                bodyIPos = body.Last().currentIPos;
                bodyJPos = body.Last().currentJPos;
            } 
            BodyPart bd = new BodyPart(bodyJPos, bodyIPos);
            switch (Game.direction)
            {
                case (Direction.Left):
                    bd = new BodyPart(bodyJPos + 1, bodyIPos);
                    bd.currentJPos = bodyJPos + 1;
                    bd.currentIPos = bodyIPos;
                    break;
                case (Direction.Right):
                    bd = new BodyPart(bodyJPos - 1, bodyIPos);
                    bd.currentJPos = bodyJPos - 1;
                    bd.currentIPos = bodyIPos;
                    break;
                case (Direction.Up):
                    bd = new BodyPart(bodyJPos, bodyIPos + 1);
                    bd.currentJPos = bodyJPos;
                    bd.currentIPos = bodyIPos + 1;
                    break;
                case (Direction.Down):
                    bd = new BodyPart(bodyJPos, bodyIPos - 1);
                    bd.currentJPos = bodyJPos;
                    bd.currentIPos = bodyIPos - 1;
                    break;


            }
            body.Add(bd);

        }

        void TimeChecker()
        {
          //  Console.WriteLine("Salom");
            tipaTime -= 0.01f;
            if (tipaTime <= 0)
            {
                tipaTime = 5f;
                TryMove();
                if(body.Count < 2)
                CreateBodyPart();
            }

        }

        public void TryMove()
        {
            if (body.Count != 0)
            {
             
                for (int i = body.Count - 2; i > 0; i--)
                {
                    body[i + 1].Move(body[i].currentJPos, body[i].currentIPos);
                    body[i].Move(body[i - 1].currentJPos, body[i - 1].currentIPos);
                }
                body[0].Move(headjpos, headipos);
            }

            headipos += changei;
            headjpos += changej;
            // if (headipos > border - 1 || headipos < 0) headipos -= changei;
            //if (headjpos > border - 1 || headjpos < 0) headjpos -= changej;
            if (headipos > border - 1) headipos = 0;
            if (headipos < 0) headipos = border - 1;
            if (headjpos > border - 1) headjpos = 0;
            if (headjpos < 0) headjpos = border - 1;
            head.Move(headjpos, headipos);
          
            
        }

    }
}
