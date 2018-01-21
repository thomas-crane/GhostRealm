using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_K_Relay;
using Lib_K_Relay.Interface;
using Lib_K_Relay.Networking.Packets;
using Lib_K_Relay.Networking;
using Lib_K_Relay.Networking.Packets.Server;
using Lib_K_Relay.Networking.Packets.DataObjects;
using Lib_K_Relay.Utilities;
using Lib_K_Relay.GameData;
using Newtonsoft.Json;
using System.IO;
using GhostRealm.Data.Models;
using GhostRealm.Services;
using System.Xml.Linq;

namespace GhostRealm.Core
{
    public class GhostRealmPlugin : IPlugin
    {
        private bool enabled = true;

        private List<int> playerObjectIds;
        private List<int> petObjectIds;

        private GhostConfig config;

        private int skinInt;
        private int classInt;
        private int mainTexInt;
        private int accessoryTexInt;
        private int petSkinInt;

        private InternalPlayerSettings clientSettings;

        private Random rand = new Random();

        public string GetAuthor()
        {
            return "tcrane";
        }

        public string[] GetCommands()
        {
            return new string[] { "/gr enable", "/gr disable" };
        }

        public string GetDescription()
        {
            return "Hides player names, dyes/cloths and optionally chat.";
        }

        public string GetName()
        {
            return "Ghost Realms";
        }

        public void Initialize(Proxy proxy)
        {
            playerObjectIds = new List<int>();
            petObjectIds = new List<int>();

            try
            {
                config = ConfigManager.GetConfiguration();
            } catch
            {
                PluginUtils.Log("GhostRealm", "Error getting config");
            }

            clientSettings = new InternalPlayerSettings(config.PlayerSettings);

            try
            {
                SetConfigVars(config);
            } catch
            {
                PluginUtils.Log("GhostRealm", "Error setting config vars");
            }

            proxy.HookPacket(PacketType.UPDATE, OnUpdate);
            proxy.HookPacket(PacketType.TEXT, OnText);
            proxy.HookPacket(PacketType.NEWTICK, OnNewTick);
            proxy.HookPacket(PacketType.TRADEREQUESTED, OnTradeRequested);
            proxy.HookPacket(PacketType.CHOOSENAME, (client, packet) =>
            {
                NameResultPacket nameResultPacket = (NameResultPacket)Packet.Create(PacketType.NAMERESULT);
                nameResultPacket.Success = true;
                nameResultPacket.ErrorText = "";
                nameResultPacket.Send = true;
                client.SendToClient(nameResultPacket);
            });

            proxy.HookCommand("gr", (client, cmd, args) =>
            {
                if (args.Length != 1)
                    return;
                if(args[0].ToLower() == "enable")
                {
                    if (enabled)
                    {
                        client.SendToClient(PluginUtils.CreateNotification(client.ObjectId, "Skeletons already enabled"));
                    }
                    else
                    {
                        enabled = true;
                        client.SendToClient(PluginUtils.CreateNotification(client.ObjectId, "Skeletons enabled"));
                    }
                }
                if(args[0].ToLower() == "disable")
                {
                    if (!enabled)
                    {
                        client.SendToClient(PluginUtils.CreateNotification(client.ObjectId, "Skeletons already disabled"));
                    }
                    else
                    {
                        enabled = false;
                        client.SendToClient(PluginUtils.CreateNotification(client.ObjectId, "Skeletons disabled"));
                    }
                }
            });
        }

        private void OnText(Client client, Packet packet)
        {
            if (!enabled)
                return;

            TextPacket textPacket = packet as TextPacket;

            if (textPacket.NumStars > 0)
                textPacket.Text = "...";
            int index = (int)Math.Floor(rand.NextDouble() * config.Names.Length);
            textPacket.Name = config.Names[index];
            textPacket.NumStars = config.Stars;
            if(!string.IsNullOrEmpty(textPacket.Recipient))
            {
                textPacket.Recipient = "Hidden";
            }

            if (textPacket.Text.ToLower().Contains("oryx_closed_realm"))
            {
                textPacket.Text = "...The realm is closed...";
            }
        }

        private void OnTradeRequested(Client client, Packet packet)
        {

        }

        private void OnUpdate(Client client, Packet packet)
        {
            if (!enabled)
                return;

            UpdatePacket updatePacket = packet as UpdatePacket;

            foreach (Entity obj in updatePacket.NewObjs)
            {
                // Pet
                if(obj.Status.Data.Any(s => s.Id == 81))
                {
                    if (!petObjectIds.Contains(obj.Status.ObjectId))
                        petObjectIds.Add(obj.Status.ObjectId);
                    AdjustPetData(obj.Status.Data);
                }


                // Player info.
                if (Enum.IsDefined(typeof(Classes), (short)obj.ObjectType))
                {
                    if(obj.Status.ObjectId == client.ObjectId)
                    {

                        AdjustClientData(obj.Status.Data, (Classes)Enum.Parse(typeof(Classes), ((short)obj.ObjectType).ToString()));
                        continue;
                    }

                    if (!playerObjectIds.Contains(obj.Status.ObjectId))
                        playerObjectIds.Add(obj.Status.ObjectId);

                    if(obj.ObjectType != classInt)
                    {
                        obj.ObjectType = (ushort)classInt;
                    }
                    AdjustPlayerData(obj.Status.Data);
                }
            }

            foreach(int objId in updatePacket.Drops)
            {
                if (playerObjectIds.Contains(objId))
                    playerObjectIds.Remove(objId);

                if (petObjectIds.Contains(objId))
                    petObjectIds.Remove(objId);
            }
        }

        private void OnNewTick(Client client, Packet packet)
        {
            if (!enabled)
                return;

            NewTickPacket newTickPacket = packet as NewTickPacket;

            foreach (Status status in newTickPacket.Statuses)
            {
                if (playerObjectIds.Contains(status.ObjectId))
                {
                    AdjustPlayerData(status.Data);
                }
                if(petObjectIds.Contains(status.ObjectId))
                {
                    AdjustPetData(status.Data);
                }
            }
        }

        private void AdjustPlayerData(StatData[] statData)
        {
            for (int i = 0; i < statData.Length; i++)
            {
                if (statData[i].Id == 80)
                {
                    statData[i].IntValue = skinInt;
                }
                if (statData[i].Id == 30)
                {
                    statData[i].IntValue = config.Stars; // stars
                }
                if (statData[i].Id == 31)
                {
                    int index = (int)Math.Floor(rand.NextDouble() * config.Names.Length);
                    statData[i].StringValue = config.Names[index]; // name
                }
                if (statData[i].Id == 32)
                {
                    statData[i].IntValue = mainTexInt; // texture 1 (cloth)
                }
                if (statData[i].Id == 33)
                {
                    statData[i].IntValue = accessoryTexInt; // texture 2 (cloth)
                }
                if (statData[i].Id == 62)
                {
                    int index = (int)Math.Floor(rand.NextDouble() * config.GuildNames.Length);
                    statData[i].StringValue = config.GuildNames[index]; // guild name
                }
                if (statData[i].Id == 63)
                {
                    statData[i].IntValue = 10; // guild rank
                }
            }
        }

        private void AdjustClientData(StatData[] statData, Classes @class)
        {
            for (int i = 0; i < statData.Length; i++)
            {
                if (statData[i].Id == 80)
                {
                    statData[i].IntValue = clientSettings.GetSkinForClass(@class);
                }
                if (statData[i].Id == 30)
                {
                    statData[i].IntValue = config.Stars; // stars
                }
                if (statData[i].Id == 31)
                {
                    statData[i].StringValue = "ChangeMe"; // name
                }
                if (statData[i].Id == 32)
                {
                    statData[i].IntValue = clientSettings.GetMainTextureForClass(@class); // texture 1 (cloth)
                }
                if (statData[i].Id == 33)
                {
                    statData[i].IntValue = clientSettings.GetAccessoryTextureForClass(@class); // texture 2 (cloth)
                }
                if(statData[i].Id == 35)
                {
                    statData[i].IntValue = config.PlayerSettings.AccountGold; // account gold
                }
                if(statData[i].Id == 39)
                {
                    statData[i].IntValue = config.PlayerSettings.AccountFame; // account fame
                }
                if(statData[i].Id == 57)
                {
                    statData[i].IntValue = config.PlayerSettings.CharacterFame; // character fame
                }
                if(statData[i].Id == 58)
                {
                    statData[i].IntValue = -1;
                }
                if (statData[i].Id == 62)
                {
                    int index = (int)Math.Floor(rand.NextDouble() * config.GuildNames.Length);
                    statData[i].StringValue = config.GuildNames[index]; // guild name
                }
                if (statData[i].Id == 63)
                {
                    statData[i].IntValue = 10; // guild rank
                }
            }
        }

        private void SetConfigVars(GhostConfig gc)
        {
            // Class
            if(!Enum.GetNames(typeof(Classes)).ToList().Exists(n => n == gc.Class))
            {
                PluginUtils.Log("GhostRealm", "Config Error: Class '{0}' is not valid.", gc.Class);
            } else
            {
                classInt = (int)((Classes)Enum.Parse(typeof(Classes), gc.Class));
            }

            // Skin
            if (gc.Skin.ToLower() == "class-default")
            {
                skinInt = 0;
            } else
            {
                try
                {
                    skinInt = GameData.Objects.ByName(gc.Skin).ID;
                }
                catch
                {
                    PluginUtils.Log("GhostRealm", "Config Error: Skin '{0}' is not valid.", gc.Skin);
                    skinInt = 0;
                }
            }

            // Names & Guild Names
            if(gc.Names is null || gc.Names.Length < 1)
            {
                gc.Names = new string[] { "Skeleton" };
            }
            if(gc.GuildNames is null || gc.GuildNames.Length < 1)
            {
                gc.GuildNames = new string[] { "Skeleton Guild" };
            }

            // Cloths & Dyes
            var rawObj = GameData.RawObjectsXML;
            XDocument doc = XDocument.Parse(rawObj);
            if (gc.MainTexture == "class-default")
            {
                mainTexInt = 0;
            }
            else
            {
                try
                {
                    var obj = from elem in doc.Descendants("Object")
                              where elem.Attribute("id").Value == gc.MainTexture
                              select elem.Element("Tex1").Value;

                    mainTexInt = Convert.ToInt32(obj.ToList()[0], 16);
                }
                catch
                {
                    PluginUtils.Log("GhostRealm", "Config Error: Cloth/Dye '{0}' is not valid.", gc.MainTexture);
                    mainTexInt = 0;
                }
            }
            if (gc.AccessoryTexture == "class-default")
            {
                accessoryTexInt = 0;
            }
            else
            {
                try
                {
                    var obj = from elem in doc.Descendants("Object")
                              where elem.Attribute("id").Value == gc.AccessoryTexture
                              select elem.Element("Tex2").Value;

                    accessoryTexInt = Convert.ToInt32(obj.ToList()[0], 16);
                }
                catch
                {
                    PluginUtils.Log("GhostRealm", "Config Error: Cloth/Dye '{0}' is not valid.", gc.AccessoryTexture);
                    accessoryTexInt = 0;
                }
            }

            // Pet
            try
            {
                petSkinInt = GameData.Objects.ByName(gc.PetSkin).ID;
            } catch
            {
                PluginUtils.Log("GhostRealm", "Config Error: Pet Skin '{0}' is not valid.", gc.PetSkin);
                petSkinInt = 32876; // default enraged yak
            }
        }

        private void AdjustPetData(StatData[] statData)
        {
            for (int i = 0; i < statData.Length; i++)
            {
                var data = statData[i];
                if (data.Id == 80)
                {
                    statData[i].IntValue = petSkinInt;
                }
            }
        }
    }
}
