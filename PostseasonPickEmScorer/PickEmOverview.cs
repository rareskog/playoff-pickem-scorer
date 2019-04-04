using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace PostseasonPickEmScorer
{
    public class PickEmOverview
    {
        public PickEmOverview()
        {
            Picks = new List<Results>();
        }

        public Results Results;
        public List<Results> Picks;

        public static PickEmOverview Load()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "PostseasonPickEmScorer.Overview.json";

            string overviewAsText;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    overviewAsText = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<PickEmOverview>(overviewAsText);
        }
    }
}