using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter2016
{
    class Tower : SimpleSprite
    {
        float _damage;
        private Texture2D _txHealthBar; // hold the texture
        public Vector2 _position; // Position on the screen
        public int _health { get; set; }
        public bool _isfriendly { get; set; }

        public Tower(Game g, string SpriteName, Vector2 StartPosition) : base(g, SpriteName, StartPosition)
        {
            Active = true;
        }

        public Tower(Game g, string SpriteName, Vector2 StartPosition, int Health, bool IsFriendly) : base(g, SpriteName, StartPosition)
        {
            Active = true;
            _isfriendly = IsFriendly;
            _position = StartPosition;
            _health = Health;
            _txHealthBar = new Texture2D(g.GraphicsDevice, 1, 1);
            _txHealthBar.SetData(new[] { Color.White });
        }

        public Rectangle HealthRect
        {
            get
            {
                return new Rectangle((int)_position.X,
                                (int)_position.Y, _health, 10);
            }
        }

        public float Damage
        {
            get
            {
                return _damage;
            }

            set
            {
                _damage = value;
            }
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch sp = Game.Services.GetService<SpriteBatch>();

            if (_isfriendly)
            {
                sp.Begin();

                if (_health > 60)
                    sp.Draw(_txHealthBar, HealthRect, Color.Green);

                else if (_health > 30 && _health <= 60)
                    sp.Draw(_txHealthBar, HealthRect, Color.Orange);

                else if (_health > 0 && _health <= 30)
                    sp.Draw(_txHealthBar, HealthRect, Color.Red);

                sp.End();
            }

            base.Draw(gameTime);
        }

    }
}
