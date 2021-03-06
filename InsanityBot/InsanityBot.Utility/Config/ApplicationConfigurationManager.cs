﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

using Newtonsoft.Json;

namespace InsanityBot.Utility.Config
{
    public class ApplicationConfigurationManager : IConfigSerializer<ApplicationConfiguration, Object>, 
        IConfigBuilder<ApplicationConfiguration, ApplicationConfigurationManager, Object>
    {
        public ApplicationConfiguration Config { get; set; }

        public ApplicationConfigurationManager AddConfigEntry(String Identifier, Object DefaultValue)
        {
            Config.Configuration.Add(Identifier, DefaultValue);
            return this;
        }

        public ApplicationConfigurationManager RemoveConfigEntry(String Identifier)
        {
            Config.Configuration.Remove(Identifier);
            return this;
        }

        public ApplicationConfiguration Deserialize(String Filename)
        {
            using StreamReader reader = new StreamReader(File.OpenRead(Filename));
            return JsonConvert.DeserializeObject<ApplicationConfiguration>(reader.ReadToEnd());
        }

        public void Serialize(ApplicationConfiguration Config, String Filename)
        {
            using StreamWriter writer = new StreamWriter(File.OpenWrite(Filename));
            writer.BaseStream.SetLength(0);
            writer.Flush();
            writer.Write(JsonConvert.SerializeObject(Config, Formatting.Indented));
        }
    }
}
