using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using System.Collections.Generic;

namespace MyFirstMod.Clan.Cards
{
    class Devilhound
    {
        public static void Create()
        {
            new CardDataBuilder
            {
                Cost = 2,
                Rarity = CollectableRarity.Common,
                CardType = CardType.Monster,
                CardID = "Direclaws_Devilhound",
                Name = "Devilhound",
                AssetPath = "Clan Assets/cards/devilhound_card.png",
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
                            CharacterID = "Direclaws_Devilhound_Character",
                            Name = "Devilhound",
                            Size = 2,
                            Health = 10,
                            AttackDamage = 10,
                            AssetPath = "Clan Assets/cards/devilhound.png",
                            SubtypeKeys = new List<string> { "DireClan_Subtype_Beast" },
                            TriggerBuilders = new List<CharacterTriggerDataBuilder>
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    Trigger = CharacterTriggerData.Trigger.OnHit,
                                    Description = "Gain +{[effect0.power]}[attack] and +{[effect1.power]}[health].",
                                    EffectBuilders = new List<CardEffectDataBuilder>
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = VanillaCardEffectTypes.CardEffectBuffDamage,
                                            TargetMode = TargetMode.Self,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 2
                                        },
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = VanillaCardEffectTypes.CardEffectBuffMaxHealth,
                                            TargetMode = TargetMode.Self,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 2
                                        }
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
