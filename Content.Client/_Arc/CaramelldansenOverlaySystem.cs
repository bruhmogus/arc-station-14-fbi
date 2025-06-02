using Robust.Client.Graphics;
using Robust.Client.Player;
using Robust.Shared.Player;
using Robust.Shared.GameStates;
using Content.Client._Arc.Overlays;
using Content.Shared._Arc;

namespace Content.Client._Arc;

public sealed class CaramelldansenOverlaySystem : EntitySystem
{
    [Dependency] private readonly IPlayerManager _player = default!;
    [Dependency] private readonly IOverlayManager _overlayMan = default!;

    private CaramelldansenOverlay _overlay = default!;

    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<CaramelldansenComponent, ComponentInit>(OnInit);
        SubscribeLocalEvent<CaramelldansenComponent, ComponentShutdown>(OnShutdown);

        SubscribeLocalEvent<CaramelldansenComponent, LocalPlayerAttachedEvent>(OnPlayerAttached);
        SubscribeLocalEvent<CaramelldansenComponent, LocalPlayerDetachedEvent>(OnPlayerDetached);

        _overlay = new();
    }

    private void UpdateOverlayFromComponent(EntityUid uid)
    {
        if (_player.LocalEntity != uid)
            return;
        if (!EntityManager.TryGetComponent(uid, out CaramelldansenComponent? comp))
            return;
        if (_overlay.TimeScale != comp.TimeScale || _overlay.RainbowStrength != comp.RainbowStrength)
            _overlay.UpdateFromComponent(comp);
    }

    private void OnPlayerAttached(EntityUid uid, CaramelldansenComponent component, LocalPlayerAttachedEvent args)
    {
        _overlayMan.AddOverlay(_overlay);
        UpdateOverlayFromComponent(uid);
    }

    private void OnPlayerDetached(EntityUid uid, CaramelldansenComponent component, LocalPlayerDetachedEvent args)
    {
        if (_overlay != null)
            _overlayMan.RemoveOverlay(_overlay);
    }

    private void OnInit(EntityUid uid, CaramelldansenComponent component, ComponentInit args)
    {
        if (_player.LocalEntity == uid)
        {
            _overlayMan.AddOverlay(_overlay);
            UpdateOverlayFromComponent(uid);
        }
    }

    private void OnShutdown(EntityUid uid, CaramelldansenComponent component, ComponentShutdown args)
    {
        if (_player.LocalEntity == uid && _overlay != null)
            _overlayMan.RemoveOverlay(_overlay);
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);
        if (_player.LocalEntity != null && EntityManager.TryGetComponent(_player.LocalEntity, out CaramelldansenComponent? comp))
            UpdateOverlayFromComponent(_player.LocalEntity);
    }
}
