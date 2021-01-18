using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using System.Collections.Generic;
using static System.Collections.IEnumerable;

namespace MyFirstMod
{
    class DemonUnit
    {
        public static void Create()
        {
            new CardDataBuilder
            {
                Cost = 3,
                Rarity = CollectableRarity.Rare,
                CardType = CardType.Monster,
                CardID = "Hellhorned_Shadowcaster",
                Name = "Shadowcaster",
                AssetPath = "demonboy_card.png",
                ClanID = VanillaClanIDs.Hellhorned,

                CardPoolIDs = new List<string> { VanillaCardPoolIDs.HellhornedBanner, VanillaCardPoolIDs.UnitsAllBanner },

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
                            CharacterID = "Hellhorned_Shadowcaster_Character",
                            Name = "Shadowcaster",
                            Size = 2,
                            Health = 10,
                            AttackDamage = 6,
                            AssetPath = "demonboy.png",
                            SubtypeKeys = new List<string> { "SubtypesData_Imp_0f9b989f-15b5-4b16-8378-5d8ed8691e7c" },
                            TriggerBuilders = new List<CharacterTriggerDataBuilder>
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    Trigger = CharacterTriggerData.Trigger.PostCombat,
                                    Description = "Give +{[effect0.power]}[attack] and +{[effect1.power]}[health] to all friendly units.",
                                    EffectBuilders = new List<CardEffectDataBuilder>
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = VanillaCardEffectTypes.CardEffectBuffDamage,
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 3
                                        },
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = VanillaCardEffectTypes.CardEffectBuffMaxHealth,
                                            TargetMode = TargetMode.Room,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 3
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