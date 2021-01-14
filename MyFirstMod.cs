using BepInEx;
using HarmonyLib;
using Trainworks;
using Trainworks.Interfaces;
using Trainworks.Managers;
using System;

namespace MyFirstMod
{
    [BepInPlugin("mod.myfirstmod", "My First Mod", "1.0.0")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    public class MyFirstMod : BaseUnityPlugin, IInitializable
    {
        public void Initialize()
        {
            StygianDamageSpell.Create();
        }
        void Awake()
        {
            var harmony = new Harmony("mod.myfirstmod");
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(SaveManager), "SetupRun")]
        class AddCardToStartingDeckPatch
        {
            static void Postfix(ref SaveManager __instance)
            {
                __instance.AddCardToDeck(CustomCardManager.GetCardDataByID("Stygian_BitterCold"));
            }
        }
    }
}
