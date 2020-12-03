### TouchTracking

Forked from https://github.com/OndrejKunc/SkiaScene .

Supported platforms are .NET Standard 1.3, Xamarin.iOS, Xamarin.Android.

```
Install-Package CC.TouchTracking
```
Implemented as .NET Standard 1.3 and platform-specific libraries.

TouchTracking provides unified API for multi-touch gestures on Android, iOS and UWP. It can be used without Xamarin.Forms. 
Basic principles are described in Xamarin Documentation https://developer.xamarin.com/guides/xamarin-forms/application-fundamentals/effects/touch-tracking/

Usage is similar on each platform. 

Android example:

```csharp
//Initialization
canvasView = FindViewById<SKCanvasView>(Resource.Id.canvasView); //Get SKCanvasView
touchHandler = new TouchHandler() { UseTouchSlop = true };
touchHandler.RegisterEvents(canvasView); //Pass View to the touch handler
touchHandler.TouchAction += OnTouch; //Listen to the touch gestures

void OnTouch(object sender, TouchActionEventArgs args) {
    var point = args.Location; //Point location
    var type = args.Type; //Entered, Pressed, Moved ... etc.
    //... do something
}
```

### TouchTracking.Forms
```
Install-Package CC.TouchTracking.Forms
```
Implemented as .NET Standard 1.3 and platform-specific libraries.

Same functionality as TouchTracking library but can be consumed in Xamarin.Forms as an Effect called TouchEffect.

```
xmlns:tt="clr-namespace:TouchTracking.Forms;assembly=TouchTracking.Forms"

<Grid>
    <views:SKCanvasView x:Name="canvasView" />
    <Grid.Effects>
        <tt:TouchEffect Capture="True" TouchAction="OnTouch" />
    </Grid.Effects>
</Grid>
```



**Important:** Right now, there is an issue on iOS in Xamarin.Forms, where routing effect resolution fails silently. To fix it, you must include this line in your AppDelegate FinishedLaunching:

```csharp
var _ = new TouchTracking.Forms.iOS.TouchEffect();
```
