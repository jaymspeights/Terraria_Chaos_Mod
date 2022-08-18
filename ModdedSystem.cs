using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace terraria_death_penalty
{
    internal class ModdedSystem : ModSystem
    {

        public override void SaveWorldData(TagCompound tag)
        {
            Logging.PublicLogger.Info("Save called");
            tag.Add("test", true);
            var test = tag.Get<bool>("test");
        }
    }
}
