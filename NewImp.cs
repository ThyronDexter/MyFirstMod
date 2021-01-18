using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using System.Collections.Generic;
using static System.Collections.IEnumerable;

namespace MyFirstMod
{
    class NewImp
    {
        public static void Create()
        {
            new CardDataBuilder
            {
                Cost = 1,
                Rarity = CollectableRarity.Uncommon,
                CardType = CardType.Monster,
                CardID = "Hellhorned_BaneImp",
                Name = "Bane Imp",
                AssetPath = "newimp.png",
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
                            CharacterID = "Hellhorned_BaneImp_Character",
                            Name = "Bane Imp",
                            Size = 1,
                            Health = 1,
                            AttackDamage = 3,
                            AssetPath = "newimp_character.png",
                            SubtypeKeys = new List<string> { "SubtypesData_Imp_0f9b989f-15b5-4b16-8378-5d8ed8691e7c" },
                            TriggerBuilders = new List<CharacterTriggerDataBuilder>
                            {
                                new CharacterTriggerDataBuilder
                                {
                                    Trigger = CharacterTriggerData.Trigger.OnSpawn,
                                    Description = "Give +{[effect0.power]}[attack] to the front friendly unit.",
                                    EffectBuilders = new List<CardEffectDataBuilder>
                                    {
                                        new CardEffectDataBuilder
                                        {
                                            EffectStateType = VanillaCardEffectTypes.CardEffectBuffDamage,
                                            TargetMode = TargetMode.FrontInRoom,
                                            TargetTeamType = Team.Type.Monsters,
                                            ParamInt = 10
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