using BepInEx.Logging;
using Trainworks;
using Trainworks.Builders;
using Trainworks.Managers;
using System.Collections.Generic;
using Clan;
using Clan.Upgrades;
using static Trainworks.Constants.VanillaCardPoolIDs;

namespace MyFirstMod.Clan
{
    class ClawsChampion
    {
        public static string IDName = "Werewolf";
        public static string imgName = "Werewolf";
        public static void Create()
        {
            // Basic Card Stats 
            ChampionCardDataBuilder railyard = new ChampionCardDataBuilder
            {
                Cost = 0,
                Champion = BuildUnit(),
                ChampionIconPath = "Clan Assets/Icon_ClassSelect_Werewolf.png",
                ChampionSelectedCue = "",
                StarterCardData = CustomCardManager.GetCardDataByID("Claws_StarterCard"),

                CardID = IDName,
                Name = "Shengar the Vicious",
                //OverrideDescriptionKey = IDName + "_Desc",
                LinkedClass = CustomClassManager.GetClassDataByID(ClawsClan.ID),
                ClanID = ClawsClan.ID,

                CardPoolIDs = new List<string> { },
                CardType = CardType.Monster,
                TargetsRoom = true,

                AssetPath = "Clan Assets/hero/werewolfchampion_card.png",
            };

            // Do this to complete
            railyard.BuildAndRegister();
        }

        // Builds the unit
        public static CharacterDataBuilder BuildUnit()
        {
            // Monster card, so we build an attached unit
            CharacterDataBuilder characterDataBuilder = new CharacterDataBuilder
            {
                CharacterID = IDName,
                Name = "Shengar the Vicious",

                Size = 2,
                Health = 10,
                AttackDamage = 5,
                AssetPath = "Clan Assets/hero/werewolfchampion_active.png",
            };

            return characterDataBuilder;
        }
    }
}