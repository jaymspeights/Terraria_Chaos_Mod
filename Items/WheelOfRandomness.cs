using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace terraria_death_penalty.Items
{
    internal class WheelOfRandomness : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Increases fun at the cost of sanity.");
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.Register();
        }

        public override bool? UseItem(Terraria.Player player)
        {
            Penalizer.GetInstance().AddPenalty(Cause.Manual, player);
            return true;
        }

    }
}
