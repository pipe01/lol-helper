using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoL_Helper.ChampBuilds
{
    class ChampBuild
    {
        public string Name;
        public string ChampionName;
        public BuildPhase[] Phases;

        public static ChampBuild FromJSON(string json)
        {
            ChampBuild ret = new ChampBuild();

            ret = JObject.Parse(json).ToObject<ChampBuild>();

            return ret;
        }

        public static string ToJSON(ChampBuild build)
        {
            return JObject.FromObject(build).ToString();
        }
    }
}
