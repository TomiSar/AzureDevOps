using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests
{
    public class ScreenshotManager
    {
        static int sequenceCounter = 0;
        static public void TakeScreenshot(IWebDriver driver, TestContext ctx)
        {
            var snapshotFile = System.IO.Path.Combine(ctx.ResultsDirectory, sequenceCounter.ToString()+ "-" + Guid.NewGuid().ToString() + ".png"); ;
            ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(snapshotFile, ScreenshotImageFormat.Png); ;
            ctx.AddResultFile(snapshotFile);
            sequenceCounter++;
        }

        static public void DrawSelectionArea(IWebDriver driver, IWebElement element)
        {

            var windowHandle = GetWindowHandleBasedOnTile(driver.Title);
            if (windowHandle != IntPtr.Zero)
            {
                Graphics graphics = Graphics.FromHwnd(windowHandle);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Pen pen = new Pen(Color.Red, 4f);
                graphics.PageUnit = GraphicsUnit.Pixel;
                graphics.DrawRectangle(pen, element.Location.X, element.Location.Y, element.Size.Width, element.Size.Height);
            }
        }

        private static IntPtr GetWindowHandleBasedOnTile(string title)
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle.Contains(title))
                {
                    return proc.MainWindowHandle;
                }
            }
            return IntPtr.Zero;
        }
    }
}
