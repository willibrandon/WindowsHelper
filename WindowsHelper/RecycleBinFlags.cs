using System;
using Windows.Win32;

namespace WindowsHelper;

[Flags]
public enum RecycleBinFlags : uint
{
    None = 0,
    NoConfirmation = PInvoke.SHERB_NOCONFIRMATION,
    NoProgressUI = PInvoke.SHERB_NOPROGRESSUI,
    NoSound = PInvoke.SHERB_NOSOUND
}
