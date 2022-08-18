using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using terraria_death_penalty.Penalties;
using Terraria.ID;
using Terraria;

namespace terraria_death_penalty
{
    internal class PenaltyManager
    {
        private List<PenaltyConfig> penalties;
        private PenaltyManager()
        {
            penalties = new List<PenaltyConfig>(new PenaltyConfig[]
            {
                new PenaltyConfig(new LiquidBombPenalty(LiquidID.Lava, 20, fillEmpty:true, fillSolid:true, message:"Looks like you left behind some lava when you died."), .3, .2, true ),
                new PenaltyConfig(new RainLiquidPenalty(LiquidID.Honey, height:2, "It might get a little sticky up on the surface..."), .1, .3, true),
                new PenaltyConfig(new TileBombPenalty(TileID.Meteorite, 20, fillEmpty:true, fillSolid:true, fillPercentage:.8, message:"That wasn't what it looked like. You were actually hit by a meteor right before that other thing."), .3, .15, true),
                new PenaltyConfig(new ReplaceTilePenalty(new ushort[] { TileID.Trees, TileID.PalmTree, TileID.PineTree }, TileID.TreeDiamond, "I hope you had already stocked up on wood."), .1, .25, false),
                new PenaltyConfig(new ComboPenalty(new Penalty[]
                    {
                        new ReplaceTilePenalty(new ushort[] { TileID.Dirt }, 1001),
                        new ReplaceTilePenalty(new ushort[] { TileID.Cobweb }, TileID.Dirt),
                        new ReplaceTilePenalty(new ushort[] { 1001 }, TileID.Cobweb),
                        new ReplaceTilePenalty(new ushort[] { TileID.Grass }, TileID.Cobweb)
                    }, "My spidey-senses are tingling."), .2, .5, true),
                new PenaltyConfig(new ComboPenalty(new Penalty[]
                    {
                        new ReplaceTilePenalty(new ushort[] { TileID.Stone }, 1001),
                        new ReplaceTilePenalty(new ushort[] { TileID.Iron }, TileID.Stone),
                        new ReplaceTilePenalty(new ushort[] { TileID.Lead }, TileID.Stone),
                        new ReplaceTilePenalty(new ushort[] { 1001 }, TileID.Iron),
                    }, "Isn't it ironic?"), .2, .5, true),
                new PenaltyConfig(new SpawnChangePenalty("You wake up in a strange new place..."), 0, .3, true),
                //new PenaltyConfig(new ReverseGravityPenalty("Up is Down"), 0, .3, true)
            });
        }

        public PenaltyConfig GetRandomPenalty(Cause cause, Terraria.Player player)
        {
            var valid_penalties = penalties.Where(p => p.Penalty.IsValid(cause, player));
            var penalty = valid_penalties.ToList()[new Random().Next(valid_penalties.ToList().Count)];
            if (!penalty.IsRepeatable)
            {
                penalties.Remove(penalty);
            }
            return penalty;
        }

        /**
         * Factor in how evil / good the penalties have been to the selection
         */
        public PenaltyConfig GetRandomPenaltyWithWeight()
        {
            throw new NotImplementedException();
        }



        private static PenaltyManager instance;
        public static PenaltyManager GetInstance()
        {
            if (instance == null)
            {
                instance = new PenaltyManager();
            }
            return instance;
        }
    }

    enum Cause
    {
        Death, Boss, Manual
    }

    class PenaltyConfig
    {
        public double EvilScore; // How evil is this
        public double ChaosScore; // How chaotic is this
        public bool IsRepeatable; // Can the be applied multiple times

        public Penalty Penalty; // The penalty to apply

        public PenaltyConfig(Penalty Penalty, double EvilScore = 0, double ChaosScore = 0, bool IsRepeatable = false)
        {
            this.Penalty = Penalty;
            this.EvilScore = EvilScore;
            this.ChaosScore = ChaosScore;
            this.IsRepeatable = IsRepeatable;
        }
    }
}
