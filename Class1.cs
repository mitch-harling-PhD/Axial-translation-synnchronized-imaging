using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Axial_Scan
{
    public class CKCubeDCServo
    {
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern short TLI_BuildDeviceList();
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern short TLI_GetDeviceListSize();
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern short TLI_GetDeviceList([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] managedStringArray);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern short TLI_GetDeviceListByType([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] managedStringArray, int typeID);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern short TLI_GetDeviceListByTypes([MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] managedStringArray, int[] typeID, int length);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
        public static extern short TLI_GetDeviceInfo(string serialNo, IntPtr pStruct);

        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern short CC_Open([MarshalAs(UnmanagedType.LPStr)] string serialNo);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern short CC_Close([MarshalAs(UnmanagedType.LPStr)] string serialNo);

        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CC_StartPolling([MarshalAs(UnmanagedType.LPStr)] string serialNo, int milliseconds);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool CC_StopPolling([MarshalAs(UnmanagedType.LPStr)] string serialNo);

        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern short CC_Home([MarshalAs(UnmanagedType.LPStr)] string serialNo);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern short CC_MoveToPosition([MarshalAs(UnmanagedType.LPStr)] string serialNo, int index);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern int CC_GetPosition([MarshalAs(UnmanagedType.LPStr)] string serialNo);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern short CC_GetVelParams([MarshalAs(UnmanagedType.LPStr)] string serialNo, ref int iAccn, ref int maxVelocity);
        [DllImport("Thorlabs.MotionControl.KCube.DCServo.DLL", SetLastError = true, BestFitMapping = false, ExactSpelling = false, CallingConvention = CallingConvention.Cdecl)]
        public static extern short CC_SetVelParams([MarshalAs(UnmanagedType.LPStr)] string serialNo, int iAccn, int maxVelocity);
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TestStruct
    {
        public UInt32 typeID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 65)]
        public char[] description;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public char[] serialNo;
        public UInt32 PID;

        [MarshalAs(UnmanagedType.I1)]
        public bool isKnownType;
        public int motorType;
        [MarshalAs(UnmanagedType.I1)]
        public bool isPiezo;
        [MarshalAs(UnmanagedType.I1)]
        public bool isLaser;
        [MarshalAs(UnmanagedType.I1)]
        public bool isCustomType;
        [MarshalAs(UnmanagedType.I1)]
        public bool isRack;
        public short maxChannels;
    }
}