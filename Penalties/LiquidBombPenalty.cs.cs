using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace terraria_death_penalty.Penalties
{
    internal class LiquidBombPenalty : Penalty
    {

        private byte liquid;
        private int radius;
        private bool fillEmpty;
        private bool fillSolid;

        public LiquidBombPenalty(byte liquid, int radius, bool fillEmpty = false, bool fillSolid = false, string message = null) : base(message)
        {
            this.liquid = liquid;
            this.fillSolid = fillSolid;
            this.fillEmpty = fillEmpty;
            this.radius = radius;
        }

        protected override void ApplyEffect(Terraria.Player player)
        {
            var targetVector = player.position / 16;
            var target = (X: (int)targetVector.X, Y: (int)targetVector.Y);

            for (int i = -this.radius + 1; i < this.radius; i++)
            {
                for (int j = -this.radius + 1; j < this.radius; j++)
                {
                    if (i * i + j * j > radius * radius) continue;

                    var x = target.X + i;
                    var y = target.Y + j;

                    if (Main.tile[x, y].HasTile && fillSolid)
                    {
                        Main.tile[x, y].ClearTile();
                        WorldGen.PlaceLiquid(x, y, liquid, byte.MaxValue);
                    }
                    else if (fillEmpty)
                    {
                        WorldGen.PlaceLiquid(x, y, liquid, byte.MaxValue);
                    }

                }
            }
        }
        
        public override bool IsValid(Cause cause, Terraria.Player player)
        {
            if (cause == Cause.Boss) return false;
            return true;
        }
    }
}
