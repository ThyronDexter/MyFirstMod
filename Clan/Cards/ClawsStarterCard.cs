using Trainworks.Builders;
using Trainworks.Constants;
using System.Collections.Generic;

namespace MyFirstMod.Clan.Cards
{
    class ClawsStarterCard
    {
        public static void Create()
        {
            new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Starter,
                CardType = CardType.Spell,
                CardID = "Claws_StarterCard",
                Name = "One of Us",
                Description = "Deal {[effect0.power]} damage to a unit and give it +{[effect1.power]}[attack].",
                AssetPath = "Clan Assets/cards/oneofus.png",
                ClanID = Clan.ClawsClan.ID,

                CardPoolIDs = new List<string> { VanillaCardPoolIDs.MegaPool },

                TargetsRoom = true,
                Targetless = false,
                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectDamage),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters | Team.Type.Heroes,
                        ParamInt = 1,
                    },
                    new CardEffectDataBuilder
                    {
                        EffectStateType = typeof(CardEffectBuffDamage),
                        TargetMode = TargetMode.DropTargetCharacter,
                        TargetTeamType = Team.Type.Monsters | Team.Type.Heroes,
                        ParamInt = 3,
                    }
                },
            }.BuildAndRegister();
        }
    }
}
