namespace dotRender.Core {
    using System;

    class BulletBlock : EntityBase {
        public BulletBlock(int xPos, int yPos, int xVel, int yVel) : base(xPos, yPos) {
            this._xVel = xVel;
            this._yVel = yVel;
        }

        private int _xVel;
        private int _yVel;

        protected override char[][] Sprite { get; set; } = {
            new[] {'#', '#', '#'}
        };

        public override void Update(ConsoleKeyInfo? keyPressed, Renderer game) {
            if (this.XMax >= Console.WindowWidth || this.YMax >= Console.WindowHeight || this.XMin <= 1 || this.YMin <= 1) {
                game.Entities.Remove(this);
            }

            this.XPos += this._xVel;
            this.YPos += this._yVel;
        }
    }
}
