using Lib_K_Relay.GameData;
using Lib_K_Relay.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GhostRealm.Data.Models
{
    public class InternalPlayerSettings
    {
        #region Skin Properties
        public int RogueSkin { get; set; }
        public int ArcherSkin { get; set; }
        public int WizardSkin { get; set; }
        public int PriestSkin { get; set; }
        public int WarriorSkin { get; set; }
        public int KnightSkin { get; set; }
        public int PaladinSkin { get; set; }
        public int AssassinSkin { get; set; }
        public int NecromancerSkin { get; set; }
        public int HuntressSkin { get; set; }
        public int MysticSkin { get; set; }
        public int TricksterSkin { get; set; }
        public int SorcererSkin { get; set; }
        public int NinjaSkin { get; set; }
        #endregion

        private XDocument doc;

        #region Cloth & Dye Properties
        public int RogueMainTexture { get; set; }
        public int RogueAccessoryTexture { get; set; }

        public int ArcherMainTexture { get; set; }
        public int ArcherAccessoryTexture { get; set; }

        public int WizardMainTexture { get; set; }
        public int WizardAccessoryTexture { get; set; }

        public int PriestMainTexture { get; set; }
        public int PriestAccessoryTexture { get; set; }

        public int WarriorMainTexture { get; set; }
        public int WarriorAccessoryTexture { get; set; }

        public int KnightMainTexture { get; set; }
        public int KnightAccessoryTexture { get; set; }

        public int PaladinMainTexture { get; set; }
        public int PaladinAccessoryTexture { get; set; }

        public int AssassinMainTexture { get; set; }
        public int AssassinAccessoryTexture { get; set; }

        public int NecromancerMainTexture { get; set; }
        public int NecromancerAccessoryTexture { get; set; }

        public int HuntressMainTexture { get; set; }
        public int HuntressAccessoryTexture { get; set; }

        public int MysticMainTexture { get; set; }
        public int MysticAccessoryTexture { get; set; }

        public int TricksterMainTexture { get; set; }
        public int TricksterAccessoryTexture { get; set; }

        public int SorcererMainTexture { get; set; }
        public int SorcererAccessoryTexture { get; set; }

        public int NinjaMainTexture { get; set; }
        public int NinjaAccessoryTexture { get; set; }
        #endregion

        public InternalPlayerSettings(PlayerSettings playerSettings)
        {
            var rawObj = GameData.RawObjectsXML;
            doc = XDocument.Parse(rawObj);

            #region Skins
            try
            {
                RogueSkin = GetValueForName(playerSettings.RogueSkin);
            }
            catch
            {
                if (playerSettings.RogueSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.RogueSkin);
                RogueSkin = 0;
            }
            try
            {
                ArcherSkin = GetValueForName(playerSettings.ArcherSkin);
            }
            catch
            {
                if (playerSettings.ArcherSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.ArcherSkin);
                ArcherSkin = 0;
            }
            try
            {
                WizardSkin = GetValueForName(playerSettings.WizardSkin);
            }
            catch
            {
                if (playerSettings.WizardSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.WizardSkin);
                WizardSkin = 0;
            }
            try
            {
                PriestSkin = GetValueForName(playerSettings.PriestSkin);
            }
            catch
            {
                if (playerSettings.PriestSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.PriestSkin);
                PriestSkin = 0;
            }
            try
            {
                WarriorSkin = GetValueForName(playerSettings.WarriorSkin);
            }
            catch
            {
                if (playerSettings.WarriorSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.WarriorSkin);
                WarriorSkin = 0;
            }
            try
            {
                KnightSkin = GetValueForName(playerSettings.KnightSkin);
            }
            catch
            {
                if (playerSettings.KnightSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.KnightSkin);
                KnightSkin = 0;
            }
            try
            {
                PaladinSkin = GetValueForName(playerSettings.PaladinSkin);
            }
            catch
            {
                if (playerSettings.PaladinSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.PaladinSkin);
                PaladinSkin = 0;
            }
            try
            {
                AssassinSkin = GetValueForName(playerSettings.AssassinSkin);
            }
            catch
            {
                if (playerSettings.AssassinSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.AssassinSkin);
                AssassinSkin = 0;
            }
            try
            {
                NecromancerSkin = GetValueForName(playerSettings.NecromancerSkin);
            }
            catch
            {
                if (playerSettings.NecromancerSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.NecromancerSkin);
                NecromancerSkin = 0;
            }
            try
            {
                HuntressSkin = GetValueForName(playerSettings.HuntressSkin);
            }
            catch
            {
                if (playerSettings.HuntressSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.HuntressSkin);
                HuntressSkin = 0;
            }
            try
            {
                MysticSkin = GetValueForName(playerSettings.MysticSkin);
            }
            catch
            {
                if (playerSettings.MysticSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.MysticSkin);
                MysticSkin = 0;
            }
            try
            {
                TricksterSkin = GetValueForName(playerSettings.TricksterSkin);
            }
            catch
            {
                if (playerSettings.TricksterSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.TricksterSkin);
                TricksterSkin = 0;
            }
            try
            {
                SorcererSkin = GetValueForName(playerSettings.SorcererSkin);
            }
            catch
            {
                if (playerSettings.SorcererSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.SorcererSkin);
                SorcererSkin = 0;
            }
            try
            {
                NinjaSkin = GetValueForName(playerSettings.NinjaSkin);
            }
            catch
            {
                if (playerSettings.NinjaSkin.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Skin '{0}' is not valid.", playerSettings.NinjaSkin);
                NinjaSkin = 0;
            }
            #endregion

            #region Main Texture
            try
            {
                RogueMainTexture = GetValueForName(playerSettings.RogueMainTexture);
            }
            catch
            {
                if (playerSettings.RogueMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.RogueMainTexture);
                RogueMainTexture = 0;
            }
            try
            {
                ArcherMainTexture = GetValueForName(playerSettings.ArcherMainTexture);
            }
            catch
            {
                if (playerSettings.ArcherMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.ArcherMainTexture);
                ArcherMainTexture = 0;
            }
            try
            {
                WizardMainTexture = GetValueForName(playerSettings.WizardMainTexture);
            }
            catch
            {
                if (playerSettings.WizardMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.WizardMainTexture);
                WizardMainTexture = 0;
            }
            try
            {
                PriestMainTexture = GetValueForName(playerSettings.PriestMainTexture);
            }
            catch
            {
                if (playerSettings.PriestMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.PriestMainTexture);
                PriestMainTexture = 0;
            }
            try
            {
                WarriorMainTexture = GetValueForName(playerSettings.WarriorMainTexture);
            }
            catch
            {
                if (playerSettings.WarriorMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.WarriorMainTexture);
                WarriorMainTexture = 0;
            }
            try
            {
                KnightMainTexture = GetValueForName(playerSettings.KnightMainTexture);
            }
            catch
            {
                if (playerSettings.KnightMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.KnightMainTexture);
                KnightMainTexture = 0;
            }
            try
            {
                PaladinMainTexture = GetValueForName(playerSettings.PaladinMainTexture);
            }
            catch
            {
                if (playerSettings.PaladinMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.PaladinMainTexture);
                PaladinMainTexture = 0;
            }
            try
            {
                AssassinMainTexture = GetValueForName(playerSettings.AssassinMainTexture);
            }
            catch
            {
                if (playerSettings.AssassinMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.AssassinMainTexture);
                AssassinMainTexture = 0;
            }
            try
            {
                NecromancerMainTexture = GetValueForName(playerSettings.NecromancerMainTexture);
            }
            catch
            {
                if (playerSettings.NecromancerMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.NecromancerMainTexture);
                NecromancerMainTexture = 0;
            }
            try
            {
                HuntressMainTexture = GetValueForName(playerSettings.HuntressMainTexture);
            }
            catch
            {
                if (playerSettings.HuntressMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.HuntressMainTexture);
                HuntressMainTexture = 0;
            }
            try
            {
                MysticMainTexture = GetValueForName(playerSettings.MysticMainTexture);
            }
            catch
            {
                if (playerSettings.MysticMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.MysticMainTexture);
                MysticMainTexture = 0;
            }
            try
            {
                TricksterMainTexture = GetValueForName(playerSettings.TricksterMainTexture);
            }
            catch
            {
                if (playerSettings.TricksterMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.TricksterMainTexture);
                TricksterMainTexture = 0;
            }
            try
            {
                SorcererMainTexture = GetValueForName(playerSettings.SorcererMainTexture);
            }
            catch
            {
                if (playerSettings.SorcererMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.SorcererMainTexture);
                SorcererMainTexture = 0;
            }
            try
            {
                NinjaMainTexture = GetValueForName(playerSettings.NinjaMainTexture);
            }
            catch
            {
                if (playerSettings.NinjaMainTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.NinjaMainTexture);
                NinjaMainTexture = 0;
            }
            #endregion

            #region Accessory Texture
            try
            {
                RogueAccessoryTexture = GetValueForName(playerSettings.RogueAccessoryTexture);
            }
            catch
            {
                if (playerSettings.RogueAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.RogueAccessoryTexture);
                RogueAccessoryTexture = 0;
            }
            try
            {
                ArcherAccessoryTexture = GetValueForName(playerSettings.ArcherAccessoryTexture);
            }
            catch
            {
                if (playerSettings.ArcherAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.ArcherAccessoryTexture);
                ArcherAccessoryTexture = 0;
            }
            try
            {
                WizardAccessoryTexture = GetValueForName(playerSettings.WizardAccessoryTexture);
            }
            catch
            {
                if (playerSettings.WizardAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.WizardAccessoryTexture);
                WizardAccessoryTexture = 0;
            }
            try
            {
                PriestAccessoryTexture = GetValueForName(playerSettings.PriestAccessoryTexture);
            }
            catch
            {
                if (playerSettings.PriestAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.PriestAccessoryTexture);
                PriestAccessoryTexture = 0;
            }
            try
            {
                WarriorAccessoryTexture = GetValueForName(playerSettings.WarriorAccessoryTexture);
            }
            catch
            {
                if (playerSettings.WarriorAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.WarriorAccessoryTexture);
                WarriorAccessoryTexture = 0;
            }
            try
            {
                KnightAccessoryTexture = GetValueForName(playerSettings.KnightAccessoryTexture);
            }
            catch
            {
                if (playerSettings.KnightAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.KnightAccessoryTexture);
                KnightAccessoryTexture = 0;
            }
            try
            {
                PaladinAccessoryTexture = GetValueForName(playerSettings.PaladinAccessoryTexture);
            }
            catch
            {
                if (playerSettings.PaladinAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.PaladinAccessoryTexture);
                PaladinAccessoryTexture = 0;
            }
            try
            {
                AssassinAccessoryTexture = GetValueForName(playerSettings.AssassinAccessoryTexture);
            }
            catch
            {
                if (playerSettings.AssassinAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.AssassinAccessoryTexture);
                AssassinAccessoryTexture = 0;
            }
            try
            {
                NecromancerAccessoryTexture = GetValueForName(playerSettings.NecromancerAccessoryTexture);
            }
            catch
            {
                if (playerSettings.NecromancerAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.NecromancerAccessoryTexture);
                NecromancerAccessoryTexture = 0;
            }
            try
            {
                HuntressAccessoryTexture = GetValueForName(playerSettings.HuntressAccessoryTexture);
            }
            catch
            {
                if (playerSettings.HuntressAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.HuntressAccessoryTexture);
                HuntressAccessoryTexture = 0;
            }
            try
            {
                MysticAccessoryTexture = GetValueForName(playerSettings.MysticAccessoryTexture);
            }
            catch
            {
                if (playerSettings.MysticAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.MysticAccessoryTexture);
                MysticAccessoryTexture = 0;
            }
            try
            {
                TricksterAccessoryTexture = GetValueForName(playerSettings.TricksterAccessoryTexture);
            }
            catch
            {
                if (playerSettings.TricksterAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.TricksterAccessoryTexture);
                TricksterAccessoryTexture = 0;
            }
            try
            {
                SorcererAccessoryTexture = GetValueForName(playerSettings.SorcererAccessoryTexture);
            }
            catch
            {
                if (playerSettings.SorcererAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.SorcererAccessoryTexture);
                SorcererAccessoryTexture = 0;
            }
            try
            {
                NinjaAccessoryTexture = GetValueForName(playerSettings.NinjaAccessoryTexture);
            }
            catch
            {
                if (playerSettings.NinjaAccessoryTexture.ToLower() != "class-default")
                    Console.WriteLine("[GhostRealm] Config Error: Cloth / Dye '{0}' is not valid.", playerSettings.NinjaAccessoryTexture);
                NinjaAccessoryTexture = 0;
            }
            #endregion
        }

        public int GetSkinForClass(Classes @class)
        {
            switch(@class)
            {
                case Classes.Archer:
                    return ArcherSkin;
                case Classes.Assassin:
                    return AssassinSkin;
                case Classes.Huntress:
                    return HuntressSkin;
                case Classes.Knight:
                    return KnightSkin;
                case Classes.Mystic:
                    return MysticSkin;
                case Classes.Necromancer:
                    return NecromancerSkin;
                case Classes.Ninja:
                    return NinjaSkin;
                case Classes.Paladin:
                    return PaladinSkin;
                case Classes.Priest:
                    return PriestSkin;
                case Classes.Rogue:
                    return RogueSkin;
                case Classes.Sorcerer:
                    return SorcererSkin;
                case Classes.Trickster:
                    return TricksterSkin;
                case Classes.Warrior:
                    return WarriorSkin;
                case Classes.Wizard:
                    return WizardSkin;
                default:
                    throw new ArgumentException("Unrecognized class", nameof(@class));
            }
        }

        public int GetMainTextureForClass(Classes @class)
        {
            switch (@class)
            {
                case Classes.Archer:
                    return ArcherMainTexture;
                case Classes.Assassin:
                    return AssassinMainTexture;
                case Classes.Huntress:
                    return HuntressMainTexture;
                case Classes.Knight:
                    return KnightMainTexture;
                case Classes.Mystic:
                    return MysticMainTexture;
                case Classes.Necromancer:
                    return NecromancerMainTexture;
                case Classes.Ninja:
                    return NinjaMainTexture;
                case Classes.Paladin:
                    return PaladinMainTexture;
                case Classes.Priest:
                    return PriestMainTexture;
                case Classes.Rogue:
                    return RogueMainTexture;
                case Classes.Sorcerer:
                    return SorcererMainTexture;
                case Classes.Trickster:
                    return TricksterMainTexture;
                case Classes.Warrior:
                    return WarriorMainTexture;
                case Classes.Wizard:
                    return WizardMainTexture;
                default:
                    throw new ArgumentException("Unrecognized class", nameof(@class));
            }
        }

        public int GetAccessoryTextureForClass(Classes @class)
        {
            switch (@class)
            {
                case Classes.Archer:
                    return ArcherAccessoryTexture;
                case Classes.Assassin:
                    return AssassinAccessoryTexture;
                case Classes.Huntress:
                    return HuntressAccessoryTexture;
                case Classes.Knight:
                    return KnightAccessoryTexture;
                case Classes.Mystic:
                    return MysticAccessoryTexture;
                case Classes.Necromancer:
                    return NecromancerAccessoryTexture;
                case Classes.Ninja:
                    return NinjaAccessoryTexture;
                case Classes.Paladin:
                    return PaladinAccessoryTexture;
                case Classes.Priest:
                    return PriestAccessoryTexture;
                case Classes.Rogue:
                    return RogueAccessoryTexture;
                case Classes.Sorcerer:
                    return SorcererAccessoryTexture;
                case Classes.Trickster:
                    return TricksterAccessoryTexture;
                case Classes.Warrior:
                    return WarriorAccessoryTexture;
                case Classes.Wizard:
                    return WizardAccessoryTexture;
                default:
                    throw new ArgumentException("Unrecognized class", nameof(@class));
            }
        }

        private int GetValueForName(string name)
        {
            var obj = from elem in doc.Descendants("Object")
                      where elem.Attribute("id").Value == name
                      select elem.Element("Tex1").Value;

            return Convert.ToInt32(obj.ToList()[0], 16);
        }
    }
}
