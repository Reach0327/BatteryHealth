using System.Collections.Specialized;
using System.Runtime.Versioning;

namespace BatteryHealth
{
    public partial class Control : Form
    {
        NotifyIcon notifyIcon;
        BatteryInformation batteryInformation;

        public Control()
        {
            InitializeComponent();
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.BatteryPlus;
            notifyIcon.Visible = true;
            batteryInformation = BatteryInfo.GetBatteryInformation();
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
            int batteryHealth = getBatteryHealthPercentage(batteryInformation.FullChargeCapacity, batteryInformation.DesignedMaxCapacity);
            notifyIcon.Text = "Battery Health: " + batteryHealth + "%";
        }

        private int getBatteryHealthPercentage(int currentCapacity, int designedCapacity)
        {
            return (currentCapacity / designedCapacity) * 100;
        }

        private void batteryHealthTimer_Tick(object sender, EventArgs e)
        {
            updateBatteryHealth();
        }
    }
}
