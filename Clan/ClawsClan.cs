using System;
using System.Collections.Generic;
using System.Text;
using Trainworks;
using Trainworks.Builders;
using Trainworks.Constants;
using Trainworks.Managers;
using UnityEngine;
using HarmonyLib;
using BepInEx.Logging;
using static System.Collections.IEnumerable;

namespace MyFirstMod.Clan
{
    class ClawsClan
    {
        public static string ID = "ClawsClan";

        public static ClassData Create()
        {
            ClassDataBuilder clan = new ClassDataBuilder
            {
                ClassID = ID,
                DraftIconPath = "Clan Assets/Icon_CardBack_Claw.png",
                Name = "Dire Claws",
                Description = "",
                SubclassDescription = "Ally with the bloodthirsty horde of the Dire Claws.",
                CardFrameUnitPath = "Clan Assets/unit-cardframe-claw.png",
                CardFrameSpellPath = "Clan Assets/spell-cardframe-claw.png",
                IconAssetPaths = new List<string>
            {
                "Clan Assets/ClanLogo_92.png",  //It can be - or _ depending the name of the image you downloaded
                "Clan Assets/ClanLogo_92.png",  //It can be - or _ depending the name of the image you downloaded
                "Clan Assets/ClanLogo_92.png",  //It can be - or _ depending the name of the image you downloaded
                "Clan Assets/ClanLogo_Silhouette.png" //It can be - or _ depending the name of the image you downloaded
            },
                UiColor = new Color(0.1f, 0.8f, 0.8f, 1f),
                UiColorDark = new Color(0.05f, 0.5f, 0.5f, 1f),
            };
            return clan.BuildAndRegister();
        }
        public static void RegisterBanner()
        {
            CardPool cardPool = UnityEngine.ScriptableObject.CreateInstance<CardPool>();
            var cardDataList = (Malee.ReorderableArray<CardData>)AccessTools.Field(typeof(CardPool), "cardDataList").GetValue(cardPool);

            cardDataList.Add(CustomCardManager.GetCardDataByID("Direclaws_Devilhound"));
            cardDataList.Add(CustomCardManager.GetCardDataByID("Direclaws_Witherclaw"));

            new RewardNodeDataBuilder()
            {
                RewardNodeID = "Horde_UnitBanner",
                MapNodePoolIDs = new List<string> {
                VanillaMapNodePoolIDs.RandomChosenMainClassUnit,
                VanillaMapNodePoolIDs.RandomChosenSubClassUnit
                },
                Name = "Dire Claws Banner",
                Description = "Recruit a Dire Claws unit.",
                RequiredClass = CustomClassManager.GetClassDataByID(ClawsClan.ID),
                ControllerSelectedOutline = "Clan Assets/selection_outlines.png",
                FrozenSpritePath = "Clan Assets/POI_Map_Clan_CHorde_Frozen.png",
                EnabledSpritePath = "Clan Assets/POI_Map_Clan_CHorde_Enabled.png",
                EnabledVisitedSpritePath = "Clan Assets/POI_Map_Clan_CHorde_Enabled.png",
                DisabledSpritePath = "Clan Assets/POI_Map_Clan_CHorde_Disabled.png",
                DisabledVisitedSpritePath = "Clan Assets/POI_Map_Clan_CHorde_VisitedDisabled.png",
                GlowSpritePath = "Clan Assets/MSK_Map_Clan_CHorde_01.png",
                MapIconPath = "Clan Assets/POI_Map_Clan_CHorde_Enabled.png",
                MinimapIconPath = "Clan Assets/Icon_MiniMap_ClanBanner.png",
                SkipCheckInBattleMode = true,
                OverrideTooltipTitleBody = false,
                NodeSelectedSfxCue = "Node_Banner",
                RewardBuilders = new List<IRewardDataBuilder>
                    {
                        new DraftRewardDataBuilder()
                        {
                            DraftRewardID = "Horde_UnitsDraft",
                            _RewardSpritePath = "Clan Assets/POI_Map_Clan_CHorde_Enabled.png",
                            _RewardTitleKey = "Dire Claws Banner",
                            _RewardDescriptionKey = "Choose a unit!",
                            Costs = new int[] { 100 },
                            _IsServiceMerchantReward = false,
                            DraftPool = cardPool,
                            ClassType = (RunState.ClassType)7,
                            DraftOptionsCount = 2,
                            RarityFloorOverride = CollectableRarity.Common
                        }
                    }
            }.BuildAndRegister();
        }
    }
}
