using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace terraria_death_penalty.Penalties
{
    internal class RainLiquidPenalty : Penalty
    {

        private byte liquid;
        private int height;

        public RainLiquidPenalty(byte liquid, int height = 1, string message = null) : base(message)
        {
            this.liquid = liquid;
            this.height = height;
        }

        protected override void ApplyEffect(Terraria.Player player)
        {
            for (int i = 0; i < Main.tile.Width; i++)
            {
                for (int j = 0; j < Main.worldSurface; j++)
                {
                    if (Main.tile[i, j].HasTile)
                    {
                        for (int k = 0; k < height; k++)
                        {
                            WorldGen.PlaceLiquid(i, j - k, liquid, byte.MaxValue);
                        }
                        break;
                    }
                }
            }
        }
    }
}
