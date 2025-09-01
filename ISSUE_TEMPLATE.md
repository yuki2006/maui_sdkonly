# SdkOnly Linking Causes App to Freeze at Splash Screen on Physical iOS Devices in .NET 9 MAUI

## Summary
When using SdkOnly linking mode with .NET 9 MAUI iOS applications, the app freezes at the splash screen and fails to render UI on physical iOS devices. The same application works correctly on iOS Simulator with both None and SdkOnly linking modes.

## Steps to Reproduce
1. Create a minimal .NET 9 MAUI iOS project
2. Set `<MtouchLink>SdkOnly</MtouchLink>` in the project file
3. Build and deploy to a physical iOS device
4. Launch the application

**Expected Result:** App proceeds past splash screen and displays main UI
**Actual Result:** App gets stuck at splash screen with black screen and becomes unresponsive

## Environment Details
- **.NET SDK**: 9.0.304 (commit: f12f5f689e)
- **MAUI Workload**: 9.0.82/9.0.100
- **iOS Workload**: 18.5.9215/9.0.100
- **Xcode**: 16.4 (Build version 16F6)
- **iOS SDK**: 18.5
- **macOS**: 15.6 (Darwin 24.6.0)
- **Test Device**: iPad (6th generation) Model A1893, iOS 18.5

## Reproduction Repository
Complete minimal reproduction project available at:
**https://github.com/yuki2006/maui_sdkonly**

## Key Findings
- **Physical Device + SdkOnly**: ❌ Stuck at splash screen (black screen, unresponsive)
- **Physical Device + None**: ✅ Proceeds past splash and displays main UI
- **iOS Simulator + SdkOnly**: ✅ Works correctly, displays main UI
- **iOS Simulator + None**: ✅ Works correctly, displays main UI

## Screenshots

### iOS Simulator - Both linking modes work correctly
![iOS Simulator - Working with SdkOnly](https://github.com/yuki2006/maui_sdkonly/raw/main/screenshots/none_linking_simulator.png)

### Physical Device - Clear difference in behavior

**None Linking (Working correctly)**
![iPad with None linking - Working](https://github.com/yuki2006/maui_sdkonly/raw/main/screenshots/device_none_working.png)

**SdkOnly Linking (Stuck at splash screen)**
![iPad with SdkOnly linking - Stuck at splash](https://github.com/yuki2006/maui_sdkonly/raw/main/screenshots/device_sdkonly_freeze.png)

As shown in the screenshots above, the issue is clearly reproducible - SdkOnly linking causes the app to get stuck at the splash screen (black screen) on physical devices while working correctly on simulators.

## Additional Information
- The application process launches successfully but never progresses past the splash screen
- No crash logs are generated (app hangs rather than crashes)
- No obvious error messages appear in system logs
- The issue appears to be specific to SdkOnly linking on physical devices
- App remains stuck at splash indefinitely until force-closed

## Impact
This issue prevents deployment of size-optimized MAUI iOS applications to physical devices, as apps get stuck at the splash screen and never reach the main UI, significantly impacting the ability to ship optimized apps to end users.

## Minimal Project Structure
```
App.cs                    # Single Label display
MauiProgram.cs           # Basic MAUI initialization  
Platforms/iOS/AppDelegate.cs
Platforms/iOS/Main.cs
Platforms/iOS/Info.plist
UltraMinimalCrash.csproj # SdkOnly linking configuration
```

The reproduction project contains absolutely minimal code to isolate the issue to SdkOnly linking behavior specifically.