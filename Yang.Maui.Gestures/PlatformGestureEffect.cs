using Microsoft.Maui.Controls.Platform;

namespace Yang.Maui.Gestures;

internal partial class PlatformGestureEffect : PlatformEffect
{
    protected override partial void OnAttached();
    protected override partial void OnDetached();

#if !(IOS || ANDROID || MACCATALYST || WINDOWS)
    protected override partial void OnAttached() {}
    protected override partial void OnDetached() {}
#endif
}
