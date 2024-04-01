using System.Runtime.InteropServices;

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
        public int nLetterCount;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string szLicense;
        public float fDist;
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
        public RESCARPLATEDATA(int n)
        {
            pPlate = new LICENSE[n];
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
