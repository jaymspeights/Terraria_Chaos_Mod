using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace terraria_death_penalty
{
    internal class Player : ModPlayer
    {

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            Penalizer.GetInstance().AddPenalty(Cause.Death, Player);
        }
    }
}
