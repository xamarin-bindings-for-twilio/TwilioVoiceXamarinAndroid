# Twilio Voice Xamarin Android

Twilio Voice Android SDK binding for Xamarin

[![NuGet][nuget-img]][nuget-link]

[nuget-img]: https://img.shields.io/badge/nuget-4.0.0-blue.svg
[nuget-link]: https://www.nuget.org/packages/Twilio.Voice.Android.XamarinBinding

## How to Build

### Twilio.Voice Android 4.0.0 (June 28th, 2019)
```
The aar is already included into this repostiory. So just build the project.    
```    
or    

Download aar/jar version you needed from https://bintray.com/twilio/releases/voice-android and copy it to source\Twilio.Voice.Android\Jars    


##### Proguard settings

-keep class com.twilio.** { *; }
-keep class tvo.webrtc.** { *; }
-dontwarn tvo.webrtc.**
-keep class com.twilio.voice.** { *; }
-keepattributes InnerClasses

-dontwarn okio.**
-dontwarn retrofit.**
-keep class retrofit.** { *; }
-keepclassmembers,allowobfuscation interface * {
@retrofit.http.** <methods>;
}

-dontwarn com.squareup.okhttp.**

## Sample

####  I don't have C# version of twilio quickstart application, so I highly recommend you to read about using native library bindings for xamarin and check official Twilio quickstart guides.

[delegate sample](sample)

[voice-quickstart-swift](https://github.com/twilio/voice-quickstart-android)

## Contributions

Members of the community have contributed to improving and update bindings:

- Rob Harwood

If you have a bugfix or an update you'd like to add, please open an issue. 
All pull requests should be opened against the `master` branch.
