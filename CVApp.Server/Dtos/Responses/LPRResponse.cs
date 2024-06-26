﻿using System.Runtime.InteropServices;

namespace CVApp.Server.Dtos.Responses
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct LICENSE
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string szLicense;
        public float fTrust;
        public Rect rtPlate;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct CARPLATEDATA
    {
        public int nPlateCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public LICENSE[] pPlate;
        public int nProcTime;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RESCARPLATEDATA
    {
        public int nPlateCount;
        public LICENSE[] pPlate;
        public string strProcTime;
        public RESCARPLATEDATA(int nPlateCount, string strProcTime)
        {
            pPlate = new LICENSE[nPlateCount];
            this.nPlateCount = nPlateCount;
            this.strProcTime = strProcTime;
        }
        public RESCARPLATEDATA()
        {
            nPlateCount = 0;
        }
    }
    public class LPRResponse
    {
        public int code { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public RESCARPLATEDATA carPlateData { get; set; }
    }
}
