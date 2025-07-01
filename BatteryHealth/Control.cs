using BatteryHealth.Properties;
using System.Text;

namespace BatteryHealth
{
    public partial class Control : Form
    {
        BatteryInformation batteryInformation;
        StringBuilder sb = new StringBuilder(29);

        public Control()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon();
            notifyIcon.Visible = true;
            notifyIcon.ContextMenuStrip = contextMenuStrip;
            notifyIcon.ContextMenuStrip.Items.Add("Toggle Run on Startup", null, handleToggleRunStartup);
            notifyIcon.ContextMenuStrip.Items.Add("Exit", null, handleExit);
            ((ToolStripMenuItem)notifyIcon.ContextMenuStrip.Items[0]).Checked = StartupUtility.IsInStartup();
            updateBatteryHealth(); // Load the icon and text the first time
        }

        private void Control_Shown(object sender, EventArgs e)
        {
            if (batteryInformation == null)
                this.Close();

            batteryHealthTimer.Start();
            this.Hide();
        }

        private void updateBatteryHealth()
        {
            if (notifyIcon == null)
                return;

            batteryInformation = BatteryInfo.GetBatteryInformation();
            int batteryHealth = (int)getBatteryHealthPercentage(batteryInformation.FullChargeCapacity, batteryInformation.DesignedMaxCapacity);
            sb.AppendFormat("Battery Health: {0}%", batteryHealth);

            if (batteryHealth >= 80)
                sb.Append(" (Ok)");
            else if (batteryHealth >= 60)
                sb.Append(" (Caution)");
            else
                sb.Append(" (Danger)");

            notifyIcon.Icon = getBatteryIcon(batteryHealth);
            notifyIcon.Text = sb.ToString();
            sb.Clear();
        }

        private double getBatteryHealthPercentage(int currentCapacity, int designedCapacity)
        {
            return Math.Round((double) currentCapacity / designedCapacity * 100, 2);
        }

        private Icon getBatteryIcon(int health)
        {
            if (health >= 80)
                return Resources.BatteryOK;
            else if (health >= 60)
                return Resources.BatteryCaution;
            else
                return Resources.BatteryDanger;
        }

        private void batteryHealthTimer_Tick(object sender, EventArgs e)
        {
            updateBatteryHealth();
        }

        private void handleToggleRunStartup(object sender, EventArgs e)
        {
            if (StartupUtility.IsInStartup())
            {
                StartupUtility.RemoveFromStartup();
            } else
            {
                StartupUtility.RunOnStartup();
            }

            ((ToolStripMenuItem)notifyIcon.ContextMenuStrip.Items[0]).Checked = StartupUtility.IsInStartup();
        }

        private void handleExit(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}
