﻿using System;
using System.Collections.Generic;
using System.Text;
using NiceHashMiner.Configs;
using NiceHashMiner.Devices;
using NiceHashMiner.Enums;
using NiceHashMiner.Miners;

namespace NiceHashMiner
{
    class ccminer_tpruvot : ccminer
    {
        public ccminer_tpruvot() :
            base()
        {
            MinerDeviceName = "NVIDIA3.x";
            Path = MinerPaths.ccminer_tpruvot;
            APIPort = 4049;

            SupportedAlgorithms = GroupAlgorithms.CreateDefaultsForGroup(DeviceGroupType.NVIDIA_3_x);

            if (!Config.ConfigData.DisableDetectionNVidia3X)
                QueryCDevs();
        }

        protected override string GetOptimizedMinerPath(AlgorithmType algorithmType) {
            if (AlgorithmType.Decred == algorithmType) {
                return MinerPaths.ccminer_decred;
            }
            return MinerPaths.ccminer_tpruvot;
        }

        protected override bool IsPotentialDevSM(string name) {
            // add only SM 3.x
            return name.Contains("SM 3.");
        }
    }
}