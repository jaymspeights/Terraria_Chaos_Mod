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
    internal abstract class Penalty
    {
        public string message;

        public Penalty(string message = null)
        {
            this.message = message;
        }

        protected abstract void ApplyEffect(Terraria.Player player);

        public virtual void Apply(Terraria.Player player)
        {
            ApplyEffect(player);
            if (message != null)
            {
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(message), Color.PowderBlue);
            }
        }

        public virtual bool IsValid(Cause cause, Terraria.Player player)
        {
            return true;
        }
    }
}
