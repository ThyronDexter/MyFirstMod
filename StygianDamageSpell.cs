using Trainworks.Builders;
using Trainworks.Constants;
using System.Collections.Generic;

namespace MyFirstMod
{
    class StygianDamageSpell
    {
        public static void Create()
        {
            new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Common,
                CardType = CardType.Spell,
                CardID = "Stygian_BitterCold",
                Name = "Bitter Cold",
                Description = "Deal <b>{[effect0.power]}</b> damage to the front enemy unit.",
                AssetPath = "bittercold.png",
                ClanID = VanillaClanIDs.Stygian,

                CardPoolIDs = new List<string> { VanillaCardPoolIDs.MegaPool },

                TargetsRoom = true,
                Targetless = false,
                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectDamage),
                        TargetMode = TargetMode.FrontInRoom,
                        TargetTeamType = Team.Type.Heroes,
                        ParamInt = 3,
                    }
                },
                TraitBuilders = new List<CardTraitDataBuilder>
                {
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitIgnoreArmor)
                    },
                    new CardTraitDataBuilder
                    {
                        TraitStateType = typeof(CardTraitIntrinsicState)
                    }
                }
            }.BuildAndRegister();
        }
    }
}
