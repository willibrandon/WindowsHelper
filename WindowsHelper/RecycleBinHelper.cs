using System;
using System.Runtime.InteropServices;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;

namespace WindowsHelper;

public static class RecycleBinHelper
{
    /// <summary>
    ///  Sends a file or directory to the Recycle Bin.
    /// </summary>
    public static bool Recycle(string path)
    {
        if (path.Length >= PInvoke.MAX_PATH)
        {
            throw new ArgumentOutOfRangeException(nameof(path));
        }

        // The string must be double-null terminated.
        path = path.TrimEnd('\0') + '\0' + '\0';
        unsafe
        {
            fixed (char* pPath = path)
            {
                SHFILEOPSTRUCTW fileOps = new()
                {
                    wFunc = PInvoke.FO_DELETE,
                    pFrom = new PCZZWSTR(pPath),
                    fFlags = (ushort)FILEOPERATION_FLAGS.FOF_ALLOWUNDO
                };

                return 0 == PInvoke.SHFileOperation(ref fileOps);
            }
        }
    }

    /// <summary>
    ///  Returns the total number of items in the specified Recycle Bin.
    /// </summary>
    public static long GetItemCount(string rootPath)
    {
        if (QueryRecycleBin(rootPath, out SHQUERYRBINFO info))
        {
            return info.i64NumItems;
        }

        return 0;
    }

    /// <summary>
    ///  Returns the total size of all the objects in the specified Recycle Bin, in bytes.
    /// </summary>
    public static long GetSize(string rootPath)
    {
        if (QueryRecycleBin(rootPath, out SHQUERYRBINFO info))
        {
            return info.i64Size;
        }

        return 0;
    }

    /// <summary>
    ///  Empties the Recycle Bin on the specified drive.
    /// </summary>
    /// <param name="rootPath"></param>
    /// <param name="flags"></param>
    /// <returns></returns>
    public static bool EmptyRecycleBin(string rootPath, RecycleBinFlags flags)
        => PInvoke.SHEmptyRecycleBin(HWND.Null, rootPath, (uint)flags).Succeeded;

    private static bool QueryRecycleBin(string rootPath, out SHQUERYRBINFO info)
    {
        info = new()
        {
            cbSize = (uint)Marshal.SizeOf<SHQUERYRBINFO>()
        };

        return PInvoke.SHQueryRecycleBin(rootPath, ref info).Succeeded;
    }
}
