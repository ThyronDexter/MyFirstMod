using Trainworks;
using Trainworks.Builders;
using Trainworks.Constants;
using System.Collections.Generic;

namespace Clan.Upgrades
{
    class WerewolfBloodlustBasic
    {
        public static string IDName = "BloodlustUpgradeBasic";
        public static int buffAmount = 2;

        public static CardUpgradeDataBuilder Builder()
        {
            CardUpgradeDataBuilder railtie = new CardUpgradeDataBuilder
            {
                UpgradeTitleKey = "Bloodlust I",
                UpgradeDescriptionKey = IDName + "_Desc",
                //upgradeIcon = CustomAssetManager.LoadSpriteFromPath("Clan Assets/clan_32.png"),
                //HideUpgradeIconOnCard = false,
                UseUpgradeHighlightTextTags = true,
                BonusDamage = 5,
                BonusHP = 0,
                
                //costReduction = 0,
                //xCostReduction = 0,
                //bonusHeal = 0,
                //BonusSize = 0,
                StatusEffectUpgrades = new List<StatusEffectStackData> {
                    new StatusEffectStackData { statusId= "Lifesteal", count=buffAmount }
                },

                //traitDataUpgradeBuilders = new List<CardTraitDataBuilder> { },
                TriggerUpgradeBuilders = new List<CharacterTriggerDataBuilder>
                {
                    // Shifter
                    //new CharacterTriggerDataBuilder
                    //{
                    //    Trigger = CharacterTriggerData.Trigger.PostCombat,
                    //    EffectBuilders = new List<CardEffectDataBuilder>
                    //    {
                    //        new CardEffectDataBuilder
                    //        {
                    //            EffectStateName = typeof(ShinyShoe.CardEffectTeleport).AssemblyQualifiedName,
                    //            TargetMode = TargetMode.Self,
                    //            TargetTeamType = Team.Type.Heroes,
                    //        }
                    //    }
                    //},
                    new CharacterTriggerDataBuilder
                    {
                        Trigger = CharacterTriggerData.Trigger.OnAttacking,
                        Description = "Apply <b>Melee Weakness<b> {[effect0.status0.power]}.",
                        EffectBuilders = new List<CardEffectDataBuilder>
                        {
                            new CardEffectDataBuilder
                            {
                                EffectStateType = VanillaCardEffectTypes.CardEffectAddStatusEffect,
                                ParamInt = 0,
                                ParamStatusEffects = new StatusEffectStackData[] { new StatusEffectStackData { statusId= "MeleeWeakness", count=1} },
                                TargetMode = TargetMode.LastAttackedCharacter,
                                TargetTeamType = Team.Type.Monsters,
                                ShouldTest = true,
                            }
                        }
                    },
                },
                //cardTriggerUpgradeBuilders = new List<CardTriggerEffectDataBuilder> { },
                //RoomModifierUpgradeBuilders = new List<RoomModifierDataBuilder> { },
                //filtersBuilders = new List<CardUpgradeMaskDataBuilder> { },
                //upgradesToRemoveBuilders = new List<CardUpgradeDataBuilder> { },
                //StatusEffectUpgrades = new List<StatusEffectStackData> { },
            };

            return railtie;
        }
        public static CardUpgradeData Create() { return Builder().Build(); }
    }
}