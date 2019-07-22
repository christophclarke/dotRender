namespace dotRender.Core {
    using System;
    using System.Collections.Generic;

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
            if (!keyPressed.HasValue) {
                return;
            }

            switch (keyPressed.Value.Key) {
                case ConsoleKey.UpArrow:
                    this.HandleUp();
                    break;
                case ConsoleKey.DownArrow:
                    this.HandleDown();
                    break;
                case ConsoleKey.LeftArrow:
                    this.HandleLeft();
                    break;
                case ConsoleKey.RightArrow:
                    this.HandleRight();
                    break;
                case ConsoleKey.Spacebar:
                    game.Entities.Add(new BulletBlock(this.XPos + 5, this.YPos + 2));
                    break;
            }
        }

        private void HandleUp() {
            if (this.YPos != 0) {
                this.YPos--;
            }
        }

        private void HandleDown() {
            this.YPos++;
        }

        private void HandleLeft() {
            if (this.XPos != 0) {
                this.XPos--;
            }
        }

        private void HandleRight() {
            this.XPos++;
        }
    }

    class BulletBlock : EntityBase {
        public BulletBlock(int xPos, int yPos) : base(xPos, yPos) {
            this.xVel = 2;
        }

        private int xVel;

        protected override char[][] Sprite { get; set; } = {
            new[] {'#', '#', '#'}
        };

        public override void Update(ConsoleKeyInfo? keyPressed, Renderer game) {
            if (this.XPos + 4 >= Console.WindowWidth || this.YPos + 4 >= Console.WindowHeight) {
                game.Entities.Remove(this);
            }

            this.XPos += this.xVel;
        }
    }
}
