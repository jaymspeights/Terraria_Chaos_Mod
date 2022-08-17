using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ModLoader;

namespace terraria_death_penalty.Penalties
{
    internal class ComboPenalty : Penalty
    {
        public Penalty[] penalties;

        public ComboPenalty(Penalty[] penalties, string message = null) : base (message)
        {
            this.penalties = penalties;
        }

        protected override void ApplyEffect(Terraria.Player player)
        {
            for (int i = 0; i < penalties.Length; i++)
            {
                penalties[i].Apply(player);
            }
        }

        public override void Apply(Terraria.Player player)
        {
            ApplyEffect(player);
            if (message != null)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), Color.PowderBlue);
            }
        }

        public override bool IsValid(Cause cause, Terraria.Player player)
        {
            for (int i = 0; i < penalties.Length; i++)
            {
                if (!penalties[i].IsValid(cause, player))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
