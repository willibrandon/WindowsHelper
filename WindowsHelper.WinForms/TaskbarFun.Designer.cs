namespace WindowsHelper.WinForms
{
    partial class TaskbarFun
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddButtons = new Button();
            btnRemoveButtons = new Button();
            btnSetOverlayIcon = new Button();
            btnRemoveOverlayIcon = new Button();
            tbProgressValue = new TrackBar();
            gbProgress = new GroupBox();
            gbState = new GroupBox();
            rdoPaused = new RadioButton();
            rdoError = new RadioButton();
            rdoNormal = new RadioButton();
            rdoIndeterminate = new RadioButton();
            rdoNoProgress = new RadioButton();
            gbThumbBarButtons = new GroupBox();
            gbOverlayIcon = new GroupBox();
            gbThumbnailTooltip = new GroupBox();
            txtThumbnailTooltip = new TextBox();
            btnSetThumbnailTooltip = new Button();
            ((System.ComponentModel.ISupportInitialize)tbProgressValue).BeginInit();
            gbProgress.SuspendLayout();
            gbState.SuspendLayout();
            gbThumbBarButtons.SuspendLayout();
            gbOverlayIcon.SuspendLayout();
            gbThumbnailTooltip.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddButtons
            // 
            btnAddButtons.Location = new Point(75, 22);
            btnAddButtons.Name = "btnAddButtons";
            btnAddButtons.Size = new Size(150, 23);
            btnAddButtons.TabIndex = 0;
            btnAddButtons.Text = "Add Buttons";
            btnAddButtons.UseVisualStyleBackColor = true;
            btnAddButtons.Click += BtnAddButton_Click;
            // 
            // btnRemoveButtons
            // 
            btnRemoveButtons.Location = new Point(75, 51);
            btnRemoveButtons.Name = "btnRemoveButtons";
            btnRemoveButtons.Size = new Size(150, 23);
            btnRemoveButtons.TabIndex = 1;
            btnRemoveButtons.Text = "Remove Buttons";
            btnRemoveButtons.UseVisualStyleBackColor = true;
            btnRemoveButtons.Click += BtnRemoveButton_Click;
            // 
            // btnSetOverlayIcon
            // 
            btnSetOverlayIcon.Location = new Point(75, 22);
            btnSetOverlayIcon.Name = "btnSetOverlayIcon";
            btnSetOverlayIcon.Size = new Size(150, 23);
            btnSetOverlayIcon.TabIndex = 2;
            btnSetOverlayIcon.Text = "Set Overlay Icon";
            btnSetOverlayIcon.UseVisualStyleBackColor = true;
            btnSetOverlayIcon.Click += BtnSetOverlayIcon_Click;
            // 
            // btnRemoveOverlayIcon
            // 
            btnRemoveOverlayIcon.Location = new Point(75, 51);
            btnRemoveOverlayIcon.Name = "btnRemoveOverlayIcon";
            btnRemoveOverlayIcon.Size = new Size(150, 23);
            btnRemoveOverlayIcon.TabIndex = 3;
            btnRemoveOverlayIcon.Text = "Remove Overlay Icon";
            btnRemoveOverlayIcon.UseVisualStyleBackColor = true;
            btnRemoveOverlayIcon.Click += BtnRemoveOverlayIcon_Click;
            // 
            // tbProgressValue
            // 
            tbProgressValue.Dock = DockStyle.Fill;
            tbProgressValue.Location = new Point(3, 19);
            tbProgressValue.Maximum = 100;
            tbProgressValue.Name = "tbProgressValue";
            tbProgressValue.Size = new Size(300, 62);
            tbProgressValue.TabIndex = 4;
            tbProgressValue.TickStyle = TickStyle.Both;
            // 
            // gbProgress
            // 
            gbProgress.Controls.Add(tbProgressValue);
            gbProgress.Location = new Point(324, 104);
            gbProgress.Name = "gbProgress";
            gbProgress.Size = new Size(306, 84);
            gbProgress.TabIndex = 6;
            gbProgress.TabStop = false;
            gbProgress.Text = "Progress";
            // 
            // gbState
            // 
            gbState.Controls.Add(rdoPaused);
            gbState.Controls.Add(rdoError);
            gbState.Controls.Add(rdoNormal);
            gbState.Controls.Add(rdoIndeterminate);
            gbState.Controls.Add(rdoNoProgress);
            gbState.Location = new Point(324, 14);
            gbState.Name = "gbState";
            gbState.Size = new Size(303, 83);
            gbState.TabIndex = 7;
            gbState.TabStop = false;
            gbState.Text = "State";
            // 
            // rdoPaused
            // 
            rdoPaused.AutoSize = true;
            rdoPaused.Location = new Point(166, 48);
            rdoPaused.Name = "rdoPaused";
            rdoPaused.Size = new Size(63, 19);
            rdoPaused.TabIndex = 4;
            rdoPaused.TabStop = true;
            rdoPaused.Text = "Paused";
            rdoPaused.UseVisualStyleBackColor = true;
            // 
            // rdoError
            // 
            rdoError.AutoSize = true;
            rdoError.Location = new Point(75, 48);
            rdoError.Name = "rdoError";
            rdoError.Size = new Size(50, 19);
            rdoError.TabIndex = 3;
            rdoError.TabStop = true;
            rdoError.Text = "Error";
            rdoError.UseVisualStyleBackColor = true;
            // 
            // rdoNormal
            // 
            rdoNormal.AutoSize = true;
            rdoNormal.Location = new Point(208, 23);
            rdoNormal.Name = "rdoNormal";
            rdoNormal.Size = new Size(65, 19);
            rdoNormal.TabIndex = 2;
            rdoNormal.TabStop = true;
            rdoNormal.Text = "Normal";
            rdoNormal.UseVisualStyleBackColor = true;
            // 
            // rdoIndeterminate
            // 
            rdoIndeterminate.AutoSize = true;
            rdoIndeterminate.Location = new Point(103, 23);
            rdoIndeterminate.Name = "rdoIndeterminate";
            rdoIndeterminate.Size = new Size(99, 19);
            rdoIndeterminate.TabIndex = 1;
            rdoIndeterminate.TabStop = true;
            rdoIndeterminate.Text = "Indeterminate";
            rdoIndeterminate.UseVisualStyleBackColor = true;
            // 
            // rdoNoProgress
            // 
            rdoNoProgress.AutoSize = true;
            rdoNoProgress.Location = new Point(8, 23);
            rdoNoProgress.Name = "rdoNoProgress";
            rdoNoProgress.Size = new Size(89, 19);
            rdoNoProgress.TabIndex = 0;
            rdoNoProgress.TabStop = true;
            rdoNoProgress.Text = "No Progress";
            rdoNoProgress.UseVisualStyleBackColor = true;
            // 
            // gbThumbBarButtons
            // 
            gbThumbBarButtons.Controls.Add(btnAddButtons);
            gbThumbBarButtons.Controls.Add(btnRemoveButtons);
            gbThumbBarButtons.Location = new Point(12, 12);
            gbThumbBarButtons.Name = "gbThumbBarButtons";
            gbThumbBarButtons.Size = new Size(306, 85);
            gbThumbBarButtons.TabIndex = 8;
            gbThumbBarButtons.TabStop = false;
            gbThumbBarButtons.Text = "Thumbnail Toolbar Buttons";
            // 
            // gbOverlayIcon
            // 
            gbOverlayIcon.Controls.Add(btnSetOverlayIcon);
            gbOverlayIcon.Controls.Add(btnRemoveOverlayIcon);
            gbOverlayIcon.Location = new Point(12, 103);
            gbOverlayIcon.Name = "gbOverlayIcon";
            gbOverlayIcon.Size = new Size(306, 85);
            gbOverlayIcon.TabIndex = 9;
            gbOverlayIcon.TabStop = false;
            gbOverlayIcon.Text = "Overlay Icon";
            // 
            // gbThumbnailTooltip
            // 
            gbThumbnailTooltip.Controls.Add(txtThumbnailTooltip);
            gbThumbnailTooltip.Controls.Add(btnSetThumbnailTooltip);
            gbThumbnailTooltip.Location = new Point(12, 194);
            gbThumbnailTooltip.Name = "gbThumbnailTooltip";
            gbThumbnailTooltip.Size = new Size(306, 83);
            gbThumbnailTooltip.TabIndex = 10;
            gbThumbnailTooltip.TabStop = false;
            gbThumbnailTooltip.Text = "Thumbnail Tooltip";
            // 
            // txtThumbnailTooltip
            // 
            txtThumbnailTooltip.Location = new Point(6, 22);
            txtThumbnailTooltip.Name = "txtThumbnailTooltip";
            txtThumbnailTooltip.Size = new Size(294, 23);
            txtThumbnailTooltip.TabIndex = 4;
            // 
            // btnSetThumbnailTooltip
            // 
            btnSetThumbnailTooltip.Location = new Point(75, 51);
            btnSetThumbnailTooltip.Name = "btnSetThumbnailTooltip";
            btnSetThumbnailTooltip.Size = new Size(150, 23);
            btnSetThumbnailTooltip.TabIndex = 3;
            btnSetThumbnailTooltip.Text = "Set Thumbnail Tooltip";
            btnSetThumbnailTooltip.UseVisualStyleBackColor = true;
            btnSetThumbnailTooltip.Click += BtnSetThumbnailTooltip_Click;
            // 
            // TaskbarFun
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(gbThumbnailTooltip);
            Controls.Add(gbOverlayIcon);
            Controls.Add(gbThumbBarButtons);
            Controls.Add(gbState);
            Controls.Add(gbProgress);
            Name = "TaskbarFun";
            Text = "Taskbar Fun";
            ((System.ComponentModel.ISupportInitialize)tbProgressValue).EndInit();
            gbProgress.ResumeLayout(false);
            gbProgress.PerformLayout();
            gbState.ResumeLayout(false);
            gbState.PerformLayout();
            gbThumbBarButtons.ResumeLayout(false);
            gbOverlayIcon.ResumeLayout(false);
            gbThumbnailTooltip.ResumeLayout(false);
            gbThumbnailTooltip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddButtons;
        private Button btnRemoveButtons;
        private Button btnSetOverlayIcon;
        private Button btnRemoveOverlayIcon;
        private TrackBar tbProgressValue;
        private GroupBox gbProgress;
        private GroupBox gbState;
        private RadioButton rdoNoProgress;
        private RadioButton rdoIndeterminate;
        private RadioButton rdoNormal;
        private RadioButton rdoError;
        private RadioButton rdoPaused;
        private GroupBox gbThumbBarButtons;
        private GroupBox gbOverlayIcon;
        private GroupBox gbThumbnailTooltip;
        private Button btnSetThumbnailTooltip;
        private TextBox txtThumbnailTooltip;
    }
}
