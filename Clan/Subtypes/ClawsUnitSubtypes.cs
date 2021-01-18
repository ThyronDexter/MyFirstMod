using System;
using System.Collections.Generic;
using System.Text;
using Trainworks.Managers;

namespace MyFirstMod.Clan.Subtypes
{
    class ClawsUnitSubtypes
    {
        public static readonly string Key = "DireClan_Subtype_Beast";
        public static readonly string Key1 = "DireClan_Subtype_Direling";
        public static readonly string Key2 = "DireClan_Subtype_Wraith";

        public static void BuildAndRegister()
        {
            CustomCharacterManager.RegisterSubtype(Key, "Beast");
            CustomCharacterManager.RegisterSubtype(Key1, "Direling");
            CustomCharacterManager.RegisterSubtype(Key2, "Wraith");
        }
    }
}
