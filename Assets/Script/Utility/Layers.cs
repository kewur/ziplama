using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script.Utility
{
    public static class Layers
    {
        public const int PlayerLayer = 8;
        public const int FloorLayer = 9;
        public const int InputLayer = 10;

        public const int PlayerMask = 1 << PlayerLayer;
        public const int FloorLayerMask = 1 << FloorLayer;
        public const int InputLayerMask = 1 << InputLayer;


    }
}
