using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace terraria_death_penalty.Penalties
{
    internal class ReplaceTilePenalty : Penalty
    {

        private ushort[] fromTiles;
        private ushort toTile;

        public ReplaceTilePenalty(ushort[] fromTiles, ushort toTile, string message = null) : base(message)
        {
            this.fromTiles = fromTiles;
            this.toTile = toTile;
        }

        protected override void ApplyEffect(Terraria.Player player)
        {
            var fromTilesList = new List<ushort>(fromTiles);
            for (int i = 0; i < Main.tile.Width; i++)
            {
                for (int j = 0; j < Main.tile.Height; j++)
                {
                    if (fromTilesList.Contains(Main.tile[i, j].TileType))
                    {
                        Main.tile[i, j].TileType = toTile;
                    }
                }
            }
            // need to reframe but it is really slow
        }
    }
}
