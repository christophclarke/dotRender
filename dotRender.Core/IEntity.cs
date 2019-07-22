namespace dotRender.Core {
    using System;
    using System.Collections.Generic;

    public interface IEntity {
        void Update(ConsoleKeyInfo? keyPressed, Renderer game);
        void Render();
    }

    public abstract class EntityBase : IEntity {
        protected int XPos;
        protected int YPos;

        protected EntityBase(int xPos = 0, int yPos = 0) {
            this.XPos = xPos;
            this.YPos = yPos;
        }

        protected abstract char[][] Sprite { get; set; }

        public abstract void Update(ConsoleKeyInfo? keyPressed, Renderer game);

        public void Render() {
            for (var row = 0; row < this.Sprite.Length; row++) {
                Console.SetCursorPosition(this.XPos, this.YPos + row);
                Console.Write(string.Join("", this.Sprite[row]));
            }
        }
    }
}
