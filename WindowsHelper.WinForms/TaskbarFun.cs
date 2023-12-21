using System.Diagnostics;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;
using Windows.Win32.UI.WindowsAndMessaging;

namespace WindowsHelper.WinForms;

public partial class TaskbarFun : Form
{
    private const string ButtonCatBitmap_FileName = @"data\NyanCatButton.bmp";
    private const string ButtonToolTip_Progress = "Progress";
    private const string ButtonToolTip_RemoveOverlayIcon = "Remove Overlay Icon";
    private const string ButtonToolTip_SetOverlayIcon = "Set Overlay Icon";
    private const string ButtonToolTip_State_Error = "Error";
    private const string ButtonToolTip_State_Indeterminate = "Indeterminate";
    private const string ButtonToolTip_State_Paused = "Paused";
    private const string ButtonToolTip_Tooltip_Meow = "Tooltip Meow!";
    private const string OverLayIcon_Description = "Meow";
    private const string OverLayIcon_FileName = @"data\NyanCatOverlayIcon.ico";
    private const string TaskbarButtonCreatedMessage = "TaskbarButtonCreated";
    private const string ToolTip_Meow = "Meow!";

    private readonly uint _taskbarButtonCreatedMessage;

    public TaskbarFun()
    {
        InitializeComponent();

        unsafe
        {
            _taskbarButtonCreatedMessage = PInvoke.RegisterWindowMessage(TaskbarButtonCreatedMessage);
            PInvoke.ChangeWindowMessageFilterEx((HWND)Handle, _taskbarButtonCreatedMessage, WINDOW_MESSAGE_FILTER_ACTION.MSGFLT_ALLOW);
            PInvoke.ChangeWindowMessageFilterEx((HWND)Handle, PInvoke.WM_COMMAND, WINDOW_MESSAGE_FILTER_ACTION.MSGFLT_ALLOW);
        }

        ImageList imageList = new();
        imageList.Images.Add(new Bitmap(ButtonCatBitmap_FileName));
        TaskbarListHelper.ThumbBarSetImageList(Handle, imageList.Handle);

        rdoNoProgress.Checked = true;
        tbProgressValue.Value = 0;
        txtThumbnailTooltip.Text = string.Empty;

        rdoNoProgress.CheckedChanged += RdoState_CheckedChanged;
        rdoIndeterminate.CheckedChanged += RdoState_CheckedChanged;
        rdoNormal.CheckedChanged += RdoState_CheckedChanged;
        rdoError.CheckedChanged += RdoState_CheckedChanged;
        rdoPaused.CheckedChanged += RdoState_CheckedChanged;
        tbProgressValue.ValueChanged += TbProgressValue_ValueChanged;
    }

    protected override void WndProc(ref Message m)
    {
        Trace.WriteLine(m.ToString());

        switch (m.Msg)
        {
            case (int)PInvoke.WM_COMMAND:

                if (m.WParam >> 16 == PInvoke.THBN_CLICKED)
                {
                    int buttonId = (m.WParam.ToInt32() << 16) >> 16;

                    switch (buttonId)
                    {
                        case 0:

                            rdoNormal.Checked = true;

                            for (int i = 1; i <= 100; i++)
                            {
                                tbProgressValue.Value = i;
                                Thread.Sleep(1);
                            }

                            break;

                        case 1:

                            rdoIndeterminate.Checked = true;
                            break;

                        case 2:

                            rdoPaused.Checked = true;
                            break;

                        case 3:

                            rdoError.Checked = true;
                            break;

                        case 4:

                            TaskbarListHelper.SetOverlayIcon(Handle, new Icon(OverLayIcon_FileName), OverLayIcon_Description);
                            break;

                        case 5:

                            TaskbarListHelper.SetOverlayIcon(Handle, null, string.Empty);
                            break;

                        case 6:
                            TaskbarListHelper.SetThumbnailTooltip(Handle, ToolTip_Meow);
                            break;

                        default:
                            break;
                    }
                }

                break;
        }

        base.WndProc(ref m);
    }

    private void BtnAddButton_Click(object sender, EventArgs e)
    {

        TaskbarListHelper.ThumbBarAddButtons(Handle,
            [
                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_ENABLED,
                    dwMask = THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_TOOLTIP | THUMBBUTTONMASK.THB_FLAGS,
                    hIcon = new HICON(new Bitmap(ButtonCatBitmap_FileName).GetHicon()),
                    iId = 0,
                    szTip = ButtonToolTip_Progress
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_ENABLED,
                    dwMask = THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_TOOLTIP | THUMBBUTTONMASK.THB_FLAGS,
                    hIcon = new HICON(new Bitmap(ButtonCatBitmap_FileName).GetHicon()),
                    iId = 1,
                    szTip = ButtonToolTip_State_Indeterminate
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_ENABLED,
                    dwMask = THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_TOOLTIP | THUMBBUTTONMASK.THB_FLAGS,
                    hIcon = new HICON(new Bitmap(ButtonCatBitmap_FileName).GetHicon()),
                    iId = 2,
                    szTip = ButtonToolTip_State_Paused
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_ENABLED,
                    dwMask = THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_TOOLTIP | THUMBBUTTONMASK.THB_FLAGS,
                    hIcon = new HICON(new Bitmap(ButtonCatBitmap_FileName).GetHicon()),
                    iId = 3,
                    szTip = ButtonToolTip_State_Error
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_ENABLED,
                    dwMask = THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_TOOLTIP | THUMBBUTTONMASK.THB_FLAGS,
                    hIcon = new HICON(new Bitmap(ButtonCatBitmap_FileName).GetHicon()),
                    iId = 4,
                    szTip = ButtonToolTip_SetOverlayIcon
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_ENABLED,
                    dwMask = THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_TOOLTIP | THUMBBUTTONMASK.THB_FLAGS,
                    hIcon = new HICON(new Bitmap(ButtonCatBitmap_FileName).GetHicon()),
                    iId = 5,
                    szTip = ButtonToolTip_RemoveOverlayIcon
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_ENABLED,
                    dwMask = THUMBBUTTONMASK.THB_ICON | THUMBBUTTONMASK.THB_TOOLTIP | THUMBBUTTONMASK.THB_FLAGS,
                    hIcon = new HICON(new Bitmap(ButtonCatBitmap_FileName).GetHicon()),
                    iId = 6,
                    szTip = ButtonToolTip_Tooltip_Meow
                },
            ]);
    }

    private void BtnRemoveButton_Click(object sender, EventArgs e)
    {
        TaskbarListHelper.ThumbBarUpdateButtons(Handle,
            [
                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN,
                    dwMask = THUMBBUTTONMASK.THB_FLAGS,
                    iId = 0,
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN,
                    dwMask = THUMBBUTTONMASK.THB_FLAGS,
                    iId = 1,
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN,
                    dwMask = THUMBBUTTONMASK.THB_FLAGS,
                    iId = 2,
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN,
                    dwMask = THUMBBUTTONMASK.THB_FLAGS,
                    iId = 3,
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN,
                    dwMask = THUMBBUTTONMASK.THB_FLAGS,
                    iId = 4,
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN,
                    dwMask = THUMBBUTTONMASK.THB_FLAGS,
                    iId = 5,
                },

                new THUMBBUTTON()
                {
                    dwFlags = THUMBBUTTONFLAGS.THBF_HIDDEN,
                    dwMask = THUMBBUTTONMASK.THB_FLAGS,
                    iId = 6,
                }
            ]);
    }

    private void BtnRemoveOverlayIcon_Click(object sender, EventArgs e)
    {
        TaskbarListHelper.SetOverlayIcon(Handle, null, string.Empty);
    }

    private void BtnSetOverlayIcon_Click(object sender, EventArgs e)
    {
        TaskbarListHelper.SetOverlayIcon(Handle, new Icon(OverLayIcon_FileName), OverLayIcon_Description);
    }

    private void BtnSetThumbnailTooltip_Click(object sender, EventArgs e)
    {
        TaskbarListHelper.SetThumbnailTooltip(Handle, txtThumbnailTooltip.Text);
    }

    private void RdoState_CheckedChanged(object? sender, EventArgs e)
    {
        if (rdoNoProgress.Checked)
        {
            TaskbarListHelper.SetProgressState(Handle, TaskbarProgressState.NoProgress);
            TaskbarListHelper.SetProgressValue(Handle, tbProgressValue.Value, 100);
        }
        else if (rdoIndeterminate.Checked)
        {
            TaskbarListHelper.SetProgressState(Handle, TaskbarProgressState.Indeterminate);
        }
        else if (rdoNormal.Checked)
        {
            TaskbarListHelper.SetProgressState(Handle, TaskbarProgressState.Normal);
            TaskbarListHelper.SetProgressValue(Handle, tbProgressValue.Value, 100);
        }
        else if (rdoError.Checked)
        {
            TaskbarListHelper.SetProgressState(Handle, TaskbarProgressState.Error);
            TaskbarListHelper.SetProgressValue(Handle, tbProgressValue.Value, 100);
        }
        else if (rdoPaused.Checked)
        {
            TaskbarListHelper.SetProgressState(Handle, TaskbarProgressState.Paused);
            TaskbarListHelper.SetProgressValue(Handle, tbProgressValue.Value, 100);
        }
    }

    private void TbProgressValue_ValueChanged(object? sender, EventArgs e)
    {
        if (sender is TrackBar trackBar)
        {
            TaskbarListHelper.SetProgressValue(Handle, trackBar.Value, 100);
        }
    }
}
