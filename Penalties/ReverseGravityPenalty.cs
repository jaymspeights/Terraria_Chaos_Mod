using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace terraria_death_penalty.Penalties
{
    internal class ReverseGravityPenalty : Penalty
    {

        public ReverseGravityPenalty(string message = null) : base(message)
        {
        }

        protected override void ApplyEffect(Terraria.Player player)
        {
            int startingPos = player.gravDir == 1 ? (int) (player.position.Y / 16) + 3 : (int) (player.position.Y / 16);

            bool noBlocksAbovePlayer = true;
            for (int y = startingPos; y >= 0 && y < Main.tile.Height; y -= (int) player.gravDir)
            {
                if (Main.tile[y, (int)(player.position.X / 16)].HasTile && Main.tileSolid[Main.tile[y, (int) (player.position.X / 16)].TileType]
                    || Main.tile[y, (int)(player.position.X / 16) + 1].HasTile && Main.tileSolid[Main.tile[y, (int) (player.position.X / 16) + 1].TileType])
                {
                    Logging.PublicLogger.Info($"Block found at {y} of type {Main.tile[y, (int)(player.position.X / 16) + 1]} {Main.tile[y, (int)(player.position.X / 16)]}");
                    noBlocksAbovePlayer = false;
                    break;
                }
            }

            if (noBlocksAbovePlayer)
            {
                Logging.PublicLogger.Info("No blocks above player");
                WorldGen.PlaceTile((int) (player.position.X / 16), startingPos, TileID.Cloud);
                WorldGen.PlaceTile((int) (player.position.X / 16) + 1, startingPos, TileID.Cloud);
            }

            player.gravControl2 = !player.gravControl2;
            player.gravDir = -1 * player.gravDir;
        }
    }
}
