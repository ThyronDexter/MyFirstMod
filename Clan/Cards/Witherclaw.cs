using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using System.Collections.Generic;

namespace MyFirstMod.Clan.Cards
{
    class Witherclaw
    {
        public static void Create()
        {
            new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Common,
                CardType = CardType.Monster,
                CardID = "Direclaws_Witherclaw",
                Name = "Witherclaw",
                AssetPath = "Clan Assets/cards/witherclaw_card.png",
                ClanID = ClawsClan.ID,

                CardPoolIDs = new List<string> { VanillaCardPoolIDs.UnitsAllBanner, VanillaCardPoolIDs.MegaPool },

                TargetsRoom = true,
                Targetless = false,
                EffectBuilders = new List<CardEffectDataBuilder>
                {
                    new CardEffectDataBuilder
                    {
                        EffectStateType = VanillaCardEffectTypes.CardEffectSpawnMonster,
                        TargetMode = TargetMode.DropTargetCharacter,
                        ParamCharacterDataBuilder = new CharacterDataBuilder
                        {
                            CharacterID = "Direclaws_Witherclaw_Character",
                            Name = "Witherclaw",
                            Size = 2,
                            Health = 6,
                            AttackDamage = 15,
                            AssetPath = "Clan Assets/cards/witherclaw.png",
                            SubtypeKeys = new List<string> { "DireClan_Subtype_Beast" },
                            TriggerBuilders = new List<CharacterTriggerDataBuilder>
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    Trigger = CharacterTriggerData.Trigger.OnAttacking,
                                    Description = "Apply <b>Melee Weakness<b> [effect0.status0.power].",
                                    EffectBuilders = new List<CardEffectDataBuilder>
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = typeof(CardEffectAddStatusEffect),
                                            TargetMode = TargetMode.LastAttackedCharacter,
                                            TargetTeamType = Team.Type.Heroes,
                                            ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData {statusId=VanillaStatusEffectIDs.AttractDamage, count=1} }
                                        },
                                    }
                                }
                            }
                        }
                    }
                },
            }.BuildAndRegister();
        }
    }
}
