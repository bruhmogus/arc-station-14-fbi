using Robust.Shared.GameStates;

namespace Content.Shared._Arc;

[RegisterComponent, NetworkedComponent]
public sealed partial class CaramelldansenComponent : Component
{
    [DataField("timeScale")]
    public float TimeScale = 0.5f;

    [DataField("rainbowStrength")]
    public float RainbowStrength = 0.7f;
}
