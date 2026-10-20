using System;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;

var desktopWallpaper = (IDesktopWallpaper)new DesktopWallpaper();
SetWallpaper(desktopWallpaper);

static void SetWallpaper(IDesktopWallpaper desktopWallpaper) {
    desktopWallpaper.SetBackgroundColor((uint)0x010101);
    desktopWallpaper.SetPosition(DESKTOP_WALLPAPER_POSITION.DWPOS_CENTER);
    desktopWallpaper.GetMonitorDevicePathCount(out uint monitorCount);

    for (uint monitorIndex = 0; monitorIndex < monitorCount; ++monitorIndex) {
        desktopWallpaper.GetMonitorDevicePathAt(monitorIndex, out PWSTR monitorIdNative);
        var monitorId = monitorIdNative.ToString();
        desktopWallpaper.GetMonitorRECT(monitorId, out RECT displayRect);
        var wallpaperPath = @$"C:\temp\IdesktopWallpaper\img0{monitorIndex}.jpg";
        desktopWallpaper.SetWallpaper(monitorId, wallpaperPath);
    }
}
