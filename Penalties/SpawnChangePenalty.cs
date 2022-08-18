using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace terraria_death_penalty.Penalties
{
    internal class SpawnChangePenalty : Penalty
    {

        public SpawnChangePenalty(string message = null) : base(message)
        {
        }

        protected override void ApplyEffect(Terraria.Player player)
        {
            var point = WorldGen.RandomWorldPoint((int)Main.worldSurface, 50, 500, 50);
            Main.spawnTileX = point.X;
            Main.spawnTileY = point.Y;
            player.ChangeSpawn(point.X, point.Y);
            if (!player.dead)
            {
                player.Hurt(PlayerDeathReason.ByCustomReason("oof"), 9999, 0);
            }
        }
    }
}
