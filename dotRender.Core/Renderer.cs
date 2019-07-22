namespace dotRender.Core {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public class Renderer {
        public Renderer() {
            this.Entities = new List<IEntity>();
        }

        public ICollection<IEntity> Entities { get; set; }

        public void Run(string title = "untitled", int height = 500, int width = 500) {
            Console.CursorVisible = false;
            Console.Title = title;

            var m = new FPSMonitor();

            this.Entities.Add(new BlockEntity());
            // this.Entities.Add(new BlockEntity(25, 5));
            // this.Entities.Add(new BlockEntity(10, 10));

            while (true) {
                Console.Clear();
                m.Tick();
                Console.WriteLine(m.FPS);
                Console.WriteLine($"{Console.WindowWidth} x {Console.WindowHeight}");
                ConsoleKeyInfo? kp = null;

                if (Console.KeyAvailable) {
                     kp = Console.ReadKey();
                }

                foreach (IEntity ent in this.Entities.ToList()) {
                    ent.Update(kp, this);
                }

                foreach (var ent in this.Entities.ToList()) {
                    ent.Render();
                }

                Console.SetCursorPosition(0,0);
                Thread.Sleep(100);
            }
        }
    }
}
