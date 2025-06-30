using BatteryHealth.Properties;

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
            int batteryHealth = (int) getBatteryHealthPercentage(batteryInformation.FullChargeCapacity, batteryInformation.DesignedMaxCapacity);
            string baseText = "Battery Health: " + batteryHealth + "%";

            if (batteryHealth <= 100 && batteryHealth >= 80)
            {
                notifyIcon.Icon = Resources.BatteryOK;
                notifyIcon.Text = baseText + " (Ok)";
            }
            else if (batteryHealth <= 79 && batteryHealth >= 60)
            {
                notifyIcon.Icon = Resources.BatteryCaution;
                notifyIcon.Text = baseText + " (Caution)";
            }
            else
            {
                notifyIcon.Icon = Resources.BatteryDanger;
                notifyIcon.Text = baseText + " (Danger)";
            }
        }

        private double getBatteryHealthPercentage(int currentCapacity, int designedCapacity)
        {
            return Math.Round((double)currentCapacity / designedCapacity * 100, 2);
        }

        private void batteryHealthTimer_Tick(object sender, EventArgs e)
        {
            updateBatteryHealth();
        }
    }
}
