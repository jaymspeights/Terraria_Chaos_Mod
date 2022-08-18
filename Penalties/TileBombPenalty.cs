using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace terraria_death_penalty.Penalties
{
    internal class TileBombPenalty : Penalty
    {

        private ushort tile;
        private int radius;
        private bool fillEmpty;
        private bool fillSolid;
        private double fillPercentage;

        public TileBombPenalty(ushort tile, int radius, string message = null, bool fillEmpty = false, bool fillSolid = false, double fillPercentage = 1) : base(message)
        {
            this.tile = tile;
            this.fillSolid = fillSolid;
            this.fillEmpty = fillEmpty;
            this.radius = radius;
            this.fillPercentage = fillPercentage;
        }

        protected override void ApplyEffect(Terraria.Player player)
        {
            var targetVector = player.position / 16;
            var target = (X: (int)targetVector.X, Y: (int)targetVector.Y);

            for (int i = -this.radius + 1; i < this.radius; i++)
            {
                for (int j = -this.radius + 1; j < this.radius; j++)
                {
                    var x = target.X + i;
                    var y = target.Y + j;

                    if (i * i + j * j > radius * radius) continue;

                    if (new Random().NextDouble() > fillPercentage) continue;

                    if (Main.tile[x, y].HasTile && fillSolid)
                    {
                        WorldGen.PlaceTile(x, y, tile, false, true);
                    }
                    else if (fillEmpty)
                    {
                        WorldGen.PlaceTile(x, y, tile, false, true);
                    }
                    
                }
            }
        }

        public override bool IsValid(Cause cause, Terraria.Player player)
        {
            if (cause == Cause.Death) return true;
            return false;
        }
    }
}
