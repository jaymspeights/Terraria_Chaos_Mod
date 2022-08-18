using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace terraria_death_penalty
{
    internal class Penalizer
    {

        private Penalizer()
        {

        }
        public void AddPenalty(Cause cause, Terraria.Player player)
        {
            PenaltyManager.GetInstance().GetRandomPenalty(cause, player).Penalty.Apply(player);
        }


        private static Penalizer instance;
        public static Penalizer GetInstance()
        {
            if (instance == null)
            {
                instance = new Penalizer();
            }
            return instance;
        }
    }
}
