using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using GhostRealm.Data.Models;

namespace GhostRealm.Services
{
    public static class ConfigManager
    {
        public static GhostConfig GetConfiguration()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Plugins", "ghostconfig.xml");

            if (!File.Exists(path))
            {
                GhostConfig cfg = new GhostConfig()
                {
                    Skin = "Skeleton Warrior", // skeleton skin
                    Class = "Warrior", // class needs to match skin,
                    Stars = 70,
                    Names = new string[] { "Skeleton" },
                    MainTexture = "class-default",
                    AccessoryTexture = "class-default",
                    GuildNames = new string[] { "Skeleton Guild" },
                    PetSkin = "Enraged Yack Skin",
                    PlayerSettings = new PlayerSettings()
                    {
                        AccountFame = 1000000,
                        CharacterFame = 1000000,
                        AccountGold = 1000000,

                        RogueSkin = "class-default",
                        ArcherSkin = "class-default",
                        WizardSkin = "class-default",
                        PriestSkin = "class-default",
                        WarriorSkin = "class-default",
                        KnightSkin = "class-default",
                        PaladinSkin = "class-default",
                        AssassinSkin = "class-default",
                        NecromancerSkin = "class-default",
                        HuntressSkin = "class-default",
                        MysticSkin = "class-default",
                        TricksterSkin = "class-default",
                        SorcererSkin = "class-default",
                        NinjaSkin = "class-default",

                        ArcherAccessoryTexture = "class-default",
                        ArcherMainTexture = "class-default",
                        AssassinAccessoryTexture = "class-default",
                        TricksterAccessoryTexture = "class-default",
                        TricksterMainTexture = "class-default",
                        RogueAccessoryTexture = "class-default",
                        RogueMainTexture = "class-default",
                        WarriorAccessoryTexture = "class-default",
                        WarriorMainTexture = "class-default",
                        WizardAccessoryTexture = "class-default",
                        WizardMainTexture = "class-default",
                        AssassinMainTexture = "class-default",
                        HuntressAccessoryTexture = "class-default",
                        KnightAccessoryTexture = "class-default",
                        MysticAccessoryTexture = "class-default",
                        NecromancerAccessoryTexture = "class-default",
                        NinjaAccessoryTexture = "class-default",
                        PaladinAccessoryTexture = "class-default",
                        PriestAccessoryTexture = "class-default",
                        SorcererAccessoryTexture = "class-default",
                        HuntressMainTexture = "class-default",
                        SorcererMainTexture = "class-default",
                        KnightMainTexture = "class-default",
                        MysticMainTexture = "class-default",
                        NecromancerMainTexture = "class-default",
                        NinjaMainTexture = "class-default",
                        PaladinMainTexture = "class-default",
                        PriestMainTexture = "class-default"
                    }
                };
                WriteXML(cfg);
                return cfg;
            }
            else
            {
                return ReadXML();
            }
        }

        public static void WriteXML(GhostConfig cfg)
        {
            XmlSerializer xmlS = new XmlSerializer(typeof(GhostConfig));
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Plugins", "ghostconfig.xml");

            using (FileStream file = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                xmlS.Serialize(file, cfg);
            }
        }

        public static GhostConfig ReadXML()
        {
            XmlSerializer xmlS = new XmlSerializer(typeof(GhostConfig));
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Plugins", "ghostconfig.xml");

            GhostConfig config = new GhostConfig();

            using (FileStream file = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                config = (GhostConfig)xmlS.Deserialize(file);
            }
            return config;
        }
    }
}
