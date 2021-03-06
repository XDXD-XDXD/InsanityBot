﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using InsanityBot.Utility.Datafixers.Reference;

namespace InsanityBot.Utility.Reference
{
    public interface IDatafixer
    {
        public DatafixerLoadingResult Load()
        {
            return DatafixerLoadingResult.Success;
        }

        public String NewDataVersion { get; }
        public String OldDataVersion { get; }
        public UInt32 DatafixerId { get; }
        public Boolean BreakingChange { get; }
    }
}
