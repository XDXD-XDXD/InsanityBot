﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using InsanityBot.Utility.Datafixers.Reference;
using InsanityBot.Utility.Reference;

namespace InsanityBot.Utility.Datafixers
{
    public static class DataFixerLower //code style: capital F intended
    {
        private static DatafixerRegistry Registry;

        public static void Initialize(Byte registryMode)
        {
            Registry = new DatafixerRegistry(registryMode);
        }

        public static void SortRegistry()
        {
            Registry.SortDatafixers();
        }

        public static void AddDatafixer(IDatafixer datafixer, Type target)
        {
            Registry.AddDatafixer(new DatafixerRegistryEntry
            {
                Datafixer = datafixer,
                BreakingChange = datafixer.BreakingChange,
                DatafixerGuid = Guid.NewGuid(),
                DatafixerId = datafixer.DatafixerId,
                DatafixerTarget = target
            });
        }

        public static void LoadAllDatafixers()
        {
            var datafixers = Registry.GetAllDatafixers();
            foreach(var v in datafixers)
            {
                foreach(var v1 in v.Value)
                {
                    v1.GetType().InvokeMember("Load", BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod, null, null, null);
                }
            }
        }

        public static IDatafixable UpgradeData<Datafixable>(Datafixable data)
            where Datafixable : IDatafixable
        {
            Datafixable dataReference = data;
            List<DatafixerRegistryEntry> datafixers = Registry.GetDatafixers(data.GetType()).ToList();

            foreach(var v in datafixers)
            {
                ((IDatafixer<Datafixable>)v.Datafixer).UpgradeData(ref dataReference);
            }

            return dataReference;
        }

        public static IDatafixable DowngradeData<Datafixable>(Datafixable data)
            where Datafixable : IDatafixable
        {
            Datafixable dataReference = data;
            List<DatafixerRegistryEntry> datafixers = Registry.GetDatafixers(data.GetType()).ToList();

            foreach (var v in datafixers)
            {
                ((IDatafixer<Datafixable>)v.Datafixer).DowngradeData(ref dataReference);
            }

            return dataReference;
        }

        public static IDatafixable ExportUpgradedData<Datafixable>(Datafixable data)
            where Datafixable : IDatafixable
        {
            Datafixable dataReference = data;
            List<DatafixerRegistryEntry> datafixers = Registry.GetDatafixers(data.GetType()).ToList();

            foreach (var v in datafixers)
            {
                dataReference = ((IDatafixer<Datafixable>)v.Datafixer).ExportUpgradedData(dataReference);
            }

            return dataReference;
        }

        public static IDatafixable ExportDowngradedData<Datafixable>(Datafixable data)
            where Datafixable : IDatafixable
        {
            Datafixable dataReference = data;
            List<DatafixerRegistryEntry> datafixers = Registry.GetDatafixers(data.GetType()).ToList();

            foreach (var v in datafixers)
            {
                dataReference = ((IDatafixer<Datafixable>)v.Datafixer).ExportDowngradedData(dataReference);
            }

            return dataReference;
        }
    }
}
