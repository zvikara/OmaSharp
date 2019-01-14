using System;
using System.Collections.Generic;
using System.Linq;

namespace OmaSharp.WapProvisioning
{
    public class CpSmsConcatenator
    {
        public int SegmentCount { get; private set; }

        public List<byte[]> UserDataHeaders { get; private set; } = new List<byte[]>();

        public List<byte[]> UserData { get; private set; } = new List<byte[]>();

        public CpSmsConcatenator(byte[] wslBytes, int maxSegmentLength = 58)
        {
            var wslLength = Convert.ToDecimal(wslBytes.Length);
            SegmentCount = Convert.ToByte(Math.Ceiling(wslLength / maxSegmentLength));

            var refId = new Random().Next(255);
            for (int segment = 0; segment < SegmentCount; segment++)
            {
                var udh = new byte[] { 11, 5, 4, 11, 0x84, 0, 0, 0, 3, 0, 0, 0 };
                udh[9] = Convert.ToByte(refId);
                udh[10] = Convert.ToByte(SegmentCount);
                udh[11] = Convert.ToByte(segment + 1);
                UserDataHeaders.Add(udh);
            }
            while (wslBytes.Length > maxSegmentLength)
            {
                var ud = wslBytes.Take(maxSegmentLength).ToArray();
                UserData.Add(ud);
                wslBytes = wslBytes.Skip(maxSegmentLength).ToArray();
            }
            UserData.Add(wslBytes);
        }
    }
}
