using System;
using System.Drawing;
using System.Runtime.InteropServices;
using Windows.Win32.UI.Controls;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;
using Windows.Win32.UI.WindowsAndMessaging;

namespace WindowsHelper;

public static class TaskbarListHelper
{
    [ComImport]
    [Guid("56FDF344-FD6D-11d0-958A-006097C9A090")]
    [ClassInterface(ClassInterfaceType.None)]
    private class TaskbarList { }

    private static readonly ITaskbarList4 _taskbarList;

    static TaskbarListHelper()
    {
        _taskbarList = (ITaskbarList4)new TaskbarList();
        _taskbarList.HrInit();
    }

    public static void ActivateTab(nint handle)
        => _taskbarList.ActivateTab((HWND)handle);

    public static void AddTab(nint handle)
        => _taskbarList.AddTab((HWND)handle);

    public static void DeleteTab(nint handle)
        => _taskbarList.DeleteTab((HWND)handle);

    public static void MarkFullscreenWindow(nint handle, bool fullScreen)
        => _taskbarList.MarkFullscreenWindow((HWND)handle, fullScreen);

    public static void RegisterTab(nint handle, nint handleTab)
        => _taskbarList.RegisterTab((HWND)handle, (HWND)handleTab);

    public static void SetActiveAlt(nint handle)
        => _taskbarList.SetActiveAlt((HWND)handle);

    public static void SetOverlayIcon(nint handle, Icon icon, string accessibilityText)
    {
        unsafe
        {
            fixed (char* pAccessibilityText = accessibilityText)
            {
                _taskbarList.SetOverlayIcon(
                    (HWND)handle,
                    new HICON(icon.Handle),
                    new PCWSTR(pAccessibilityText));
            }
        }
    }

    public static void SetProgressState(nint handle, TaskbarProgressState state)
        => _taskbarList.SetProgressState((HWND)handle, (TBPFLAG)state);

    public static void SetProgressValue(nint handle, int currentValue, int maximumValue)
        => _taskbarList.SetProgressValue((HWND)handle, (ulong)currentValue, (ulong)maximumValue);

    public static void SetTabActive(nint handleTab, nint handleMDI)
        => _taskbarList.SetTabActive((HWND)handleTab, (HWND)handleMDI, 0);

    public static void SetTabOrder(nint handleTab, nint handleInsertBefore)
        => _taskbarList.SetTabOrder((HWND)handleTab, (HWND)handleInsertBefore);

    public static void SetThumbnailClip(nint handle, Rectangle rectangle)
    {
        unsafe
        {
            _taskbarList.SetThumbnailClip((HWND)handle, (RECT*)&rectangle);
        }
    }

    public static void SetThumbnailTooltip(nint handle, string tooltip)
    {
        unsafe
        {
            fixed (char* pTooltip = tooltip)
            {
                _taskbarList.SetThumbnailTooltip((HWND)handle, new PCWSTR(pTooltip));
            }
        }
    }

    public static void ThumbBarSetImageList(nint handle, IntPtr imageList)
        => _taskbarList.ThumbBarSetImageList((HWND)handle, (HIMAGELIST)imageList);

    public static void UnregisterTab(nint handleTab)
        => _taskbarList.UnregisterTab((HWND)handleTab);
}
