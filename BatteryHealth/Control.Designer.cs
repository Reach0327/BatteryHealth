namespace BatteryHealth
{
    partial class Control
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
            components = new System.ComponentModel.Container();
            batteryHealthTimer = new System.Windows.Forms.Timer(components);
            notifyIcon = new NotifyIcon(components);
            contextMenuStrip = new ContextMenuStrip(components);
            SuspendLayout();
            // 
            // batteryHealthTimer
            // 
            batteryHealthTimer.Interval = 60000;
            batteryHealthTimer.Tick += batteryHealthTimer_Tick;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.Text = "Initializing..";
            notifyIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.ImageScalingSize = new Size(20, 20);
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new Size(61, 4);
            // 
            // Control
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(11, 13);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Control";
            Text = "Control";
            Shown += Control_Shown;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer batteryHealthTimer;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenuStrip;
    }
}
