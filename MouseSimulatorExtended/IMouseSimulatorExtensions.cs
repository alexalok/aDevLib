using WindowsInput;

namespace MouseSimulatorExtended
{
    public static class MouseSimulatorExtensions
    {
        public static void MoveToByResolution(this IMouseSimulator mouse, int x, int y)
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double calcX = 65535 / screenWidth * x;
            double calcY = 65535 / screenHeight * y;
            mouse.MoveMouseTo(calcX, calcY);
        }
    }
}