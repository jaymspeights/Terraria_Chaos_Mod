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
    internal class PlayerKiller : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Kills on use.");
        }

        public override void SetDefaults()
        {
            Item.damage = 420;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = 10000;
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
            player.Hurt(PlayerDeathReason.ByPlayer(0), 9999, 0);
            return true;
        }

    }
}
