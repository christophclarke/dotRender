namespace dotRender.Core {
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BlockEntity : EntityBase {
        public BlockEntity(int initX = 0, int initY = 0) : base(initX, initY) { }

        protected override char[][] Sprite { get; set; } = {
            new[] {'#', '#', '#', '#', '#'},
            new[] {'#', ' ', ' ', ' ', '#'},
            new[] {'#', ' ', ' ', ' ', '#'},
            new[] {'#', ' ', ' ', ' ', '#'},
            new[] {'#', '#', '#', '#', '#'},
        };

        public override void Update(ConsoleKeyInfo? keyPressed, Renderer game) {
            if (keyPressed.HasValue) {
                switch (keyPressed.Value.Key) {
                    case ConsoleKey.W:
                        this.HandleUp();
                        break;
                    case ConsoleKey.S:
                        this.HandleDown();
                        break;
                    case ConsoleKey.A:
                        this.HandleLeft();
                        break;
                    case ConsoleKey.D:
                        this.HandleRight();
                        break;
                    case ConsoleKey.Spacebar:
                        game.Entities.Add(new BulletBlock(this.XPos + 5, this.YPos + 2, 2, 0));
                        break;
                }
            }

            HashSet<IEntity> o = game.Entities.ToHashSet();
            o.Remove(this);
            foreach (IEntity other in o) {
                if (this.CheckCollision(other)) {
                    Console.WriteLine("COLLISION");
                    game.Entities.Remove(this);
                    // game.Entities.Remove(other);
                }
            }
        }

        protected void HandleUp() {
            if (this.YPos != 0) {
                this.YPos--;
            }
        }

        protected void HandleDown() {
            this.YPos++;
        }

        protected void HandleLeft() {
            if (this.XPos != 0) {
                this.XPos--;
            }
        }

        protected void HandleRight() {
            this.XPos++;
        }
    }

    public class BlockEntityP2 : BlockEntity {
        public BlockEntityP2(int initX = 0, int initY = 0) : base(initX, initY) { }

        public override void Update(ConsoleKeyInfo? keyPressed, Renderer game) {
            if (keyPressed.HasValue) {
                switch (keyPressed.Value.Key) {
                    case ConsoleKey.D8:
                        this.HandleUp();
                        break;
                    case ConsoleKey.D2:
                        this.HandleDown();
                        break;
                    case ConsoleKey.D4:
                        this.HandleLeft();
                        break;
                    case ConsoleKey.D6:
                        this.HandleRight();
                        break;
                    case ConsoleKey.D0:
                        game.Entities.Add(new BulletBlock(this.XPos - 5, this.YPos + 2,-2, 0));
                        break;
                }
            }

            HashSet<IEntity> o = game.Entities.ToHashSet();
            o.Remove(this);
            foreach (IEntity other in o) {
                if (this.CheckCollision(other)) {
                    Console.WriteLine("COLLISION");
                    game.Entities.Remove(this);
                }
            }
        }
    }
}
