using System.Threading;
using CTRE.Phoenix.MotorControl;
using CTRE.Phoenix.MotorControl.CAN;
using Microsoft.SPOT.Hardware;
using Watchdog = CTRE.Phoenix.Watchdog;

namespace Penny_Board
{
    public static class Program
    {
        private const int TimeoutMs = 150, UpdatePeriodMs = 20;
        private static readonly VictorSPX Victor = new VictorSPX(0);
        // private static readonly PWM Controller = new PWM(Cpu.PWMChannel.PWM_0, 0, 0, PWM.ScaleFactor.Microseconds, false);
        private static readonly PWM Radio = new PWM(Cpu.PWMChannel.PWM_0, 10000, 1500, PWM.ScaleFactor.Microseconds, false);

        public static void Main()
        {
            var configuration = new VictorSPXConfiguration();
            Victor.ConfigAllSettings(configuration, TimeoutMs);
            Victor.SetControlFramePeriod(ControlFrame.Control_3_General, UpdatePeriodMs);
            Radio.Start();
            while (true)
            {
                Thread.Sleep(UpdatePeriodMs);
                Watchdog.Feed();
            }
        }
    }
}
