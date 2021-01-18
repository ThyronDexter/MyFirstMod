using BepInEx;
using HarmonyLib;
using Trainworks;
using TrainworksModdingTools.Utilities;
using Trainworks.Interfaces;
using Trainworks.Managers;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Utilities;
using System.Collections.Generic;
using Clan;
using Clan.Upgrades;
using System;

namespace MyFirstMod
{
    [BepInPlugin("mod.myfirstmod", "Dire Claws Clan Mod", "1.0.0")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency(Trainworks.Trainworks.GUID)]
    public class MyFirstMod : BaseUnityPlugin, IInitializable
    {
        void Awake()
        {
            var harmony = new Harmony("mod.myfirstmod");
            harmony.PatchAll();
        }

        public void Initialize()
        {
            Clan.Subtypes.ClawsUnitSubtypes.BuildAndRegister();
            CreateEnhancers();
            RegisterUpgrades();
            WerewolfBloodlustBasic.Create();
            Clan.ClawsClan.Create();
            Clan.Cards.ClawsStarterCard.Create();
            Clan.Cards.Devilhound.Create();
            Clan.Cards.Witherclaw.Create();
            Clan.Cards.ClawsStarterCard.Create();
            Clan.ClawsChampion.Create();
            Clan.ClawsClan.RegisterBanner();
        }

        static void CreateEnhancers()
        {
            static void AddToSpellPowerEnhancers(string CardEffectID)
            {
                var allGameData = ProviderManager.SaveManager.GetAllGameData();
                Traverse.Create(allGameData.FindEnhancerDataByName("SpellMagicPower").GetEffects()[0].GetParamCardUpgradeData().GetFilters()[0]).Field("requiredCardEffects").GetValue<List<string>>().Add(CardEffectID);
                Traverse.Create(allGameData.FindEnhancerDataByName("SpellMagicPowerBigExtraCost").GetEffects()[0].GetParamCardUpgradeData().GetFilters()[0]).Field("requiredCardEffects").GetValue<List<string>>().Add(CardEffectID);
            }
            AddToSpellPowerEnhancers(typeof(CardEffectDamage).AssemblyQualifiedName);
            AddToSpellPowerEnhancers(typeof(CardEffectDamagePerTargetAttack).AssemblyQualifiedName);
        }

        static void RegisterUpgrades()
        {
            WerewolfBloodlustBasic.Create();
            WerewolfBloodlustPremium.Create();
            WerewolfBloodlustPro.Create();
        }

        [HarmonyPatch(typeof(SaveManager), "SetupRun")]
        class AddCardToStartingDeckPatch
        {
            static void Postfix(ref SaveManager __instance)
            {
                
            }
        }
    }
}
