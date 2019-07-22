namespace dotRender.Core {
    using System;
    using System.Collections.Generic;

    public interface IEntity {
        int XMin { get; }
        int XMax { get; }
        int YMin { get; }
        int YMax { get; }

        void Update(ConsoleKeyInfo? keyPressed, Renderer game);
        void Render();
        bool CheckCollision(IEntity entity);
    }

    public abstract class EntityBase : IEntity {
        protected int XPos;
        protected int YPos;

        protected EntityBase(int xPos = 0, int yPos = 0) {
            this.XPos = xPos;
            this.YPos = yPos;
        }

        protected abstract char[][] Sprite { get; set; }

        public int XMin => this.XPos;

        public int XMax => this.XPos + this.Sprite[0].Length;

        public int YMin => this.YPos;

        public int YMax => this.YPos + this.Sprite.Length;

        public abstract void Update(ConsoleKeyInfo? keyPressed, Renderer game);

        public void Render() {
            for (var row = 0; row < this.Sprite.Length; row++) {
                Console.SetCursorPosition(this.XPos, this.YPos + row);
                Console.Write(string.Join("", this.Sprite[row]));
            }
        }

        public bool CheckCollision(IEntity entity) {
            return this.XMax > entity.XMin && this.XMin < entity.XMax
                   && this.YMax > entity.YMin && this.YMin < entity.YMax;
        }
    }
}
