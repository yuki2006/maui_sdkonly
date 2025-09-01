# SdkOnly Linking Causes UI Freeze on Physical iOS Devices in .NET 9 MAUI

## Summary
When using SdkOnly linking mode with .NET 9 MAUI iOS applications, the app freezes at the splash screen and fails to render UI on physical iOS devices. The same application works correctly on iOS Simulator with both None and SdkOnly linking modes.

## Steps to Reproduce
1. Create a minimal .NET 9 MAUI iOS project
2. Set `<MtouchLink>SdkOnly</MtouchLink>` in the project file
3. Build and deploy to a physical iOS device
4. Launch the application

**Expected Result:** App displays UI correctly
**Actual Result:** App shows black screen and becomes unresponsive

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
- **Physical Device + SdkOnly**: ❌ Freezes (black screen, unresponsive)
- **Physical Device + None**: ✅ Works correctly
- **iOS Simulator + SdkOnly**: ✅ Works correctly  
- **iOS Simulator + None**: ✅ Works correctly

## Screenshots

### iOS Simulator - Both linking modes work correctly
![iOS Simulator - Working with SdkOnly](https://github.com/yuki2006/maui_sdkonly/raw/main/screenshots/none_linking_simulator.png)

### Physical Device - Clear difference in behavior

**None Linking (Working correctly)**
![iPad with None linking - Working](https://github.com/yuki2006/maui_sdkonly/raw/main/screenshots/device_none_working.png)

**SdkOnly Linking (Frozen state)**
![iPad with SdkOnly linking - Frozen](https://github.com/yuki2006/maui_sdkonly/raw/main/screenshots/device_sdkonly_freeze.png)

As shown in the screenshots above, the issue is clearly reproducible - SdkOnly linking causes a black screen freeze on physical devices while working correctly on simulators.

## Additional Information
- The application process launches successfully but becomes unresponsive
- No crash logs are generated (app hangs rather than crashes)
- No obvious error messages appear in system logs
- The issue appears to be specific to SdkOnly linking on physical devices

## Impact
This issue prevents deployment of optimized MAUI iOS applications to physical devices, significantly impacting app performance and size optimization capabilities.

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