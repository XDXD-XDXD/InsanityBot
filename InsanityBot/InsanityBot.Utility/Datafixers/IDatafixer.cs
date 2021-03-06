﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using InsanityBot.Utility.Datafixers.Reference;
using InsanityBot.Utility.Reference;

namespace InsanityBot.Utility.Datafixers
{
    public interface IDatafixer<Datafixable> : IDatafixer
        where Datafixable : IDatafixable
    {
        public DatafixerUpgradeResult UpgradeData(ref Datafixable data);

        public DatafixerDowngradeResult DowngradeData(ref Datafixable data);

        public Datafixable ExportUpgradedData(Datafixable data);

        public Datafixable ExportDowngradedData(Datafixable data);
    }
}
