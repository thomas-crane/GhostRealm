using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhostRealm.Data.Models
{
    public class GhostConfig
    {
        public string Skin { get; set; }
        public string Class { get; set; }
        public int Stars { get; set; }
        public string[] Names { get; set; }
        public string MainTexture { get; set; }
        public string AccessoryTexture { get; set; }
        public string[] GuildNames { get; set; }
        public string PetSkin { get; set; }

        public PlayerSettings PlayerSettings { get; set; }

        public GhostConfig()
        {
        }
    }
}
