using Robust.Shared.GameObjects;
using Robust.Shared.IoC;
using Robust.Shared.Log;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.ViewVariables;
using Robust.Shared.Audio;
using Robust.Shared.Audio.Systems;

namespace Content.Shared._Arc.Admemery
{
    public sealed class ObjectGildedSystem : EntitySystem
    {

        [Dependency] private readonly SharedAppearanceSystem _appearanceSystem = default!;

        [Dependency] private readonly ILogManager _logManager = default!;
        private ISawmill _sawmill = default!;

        [Dependency] private readonly SharedAudioSystem _audioSystem = default!;

        public override void Initialize()
        {
            base.Initialize();

            _sawmill = _logManager.GetSawmill("gilded");

            SubscribeLocalEvent<ObjectGildedComponent, ComponentStartup>(OnComponentStartup);
            SubscribeLocalEvent<ObjectGildedComponent, ComponentRemove>(OnComponentShutdown);


        }
        private void OnComponentStartup(EntityUid uid, ObjectGildedComponent component, ComponentStartup args)
        {

            _sawmill.Info("Component starting");

            AddGoldenShader(uid, component);

            // Play the sound effect on the component
            _audioSystem.PlayPvs(component.GildedSound, uid, AudioParams.Default);
        }

        private void AddGoldenShader(EntityUid uid, ObjectGildedComponent component)
        {
            EnsureComp<AppearanceComponent>(uid);
            EnsureComp<ObjectGildedComponent>(uid);

            _appearanceSystem.SetData(uid, GildedVisuals.Gilded, true);
        }

        private void OnComponentShutdown(EntityUid uid, ObjectGildedComponent component, ComponentRemove args)
        {

            _sawmill.Info("Component shutting down");

            if (!Terminating(uid))
                _appearanceSystem.SetData(uid, GildedVisuals.Gilded, false);
        }
    }
}
