using Content.Shared.Wires;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;

namespace Content.Client.Wires.UI
{
    public sealed class WiresBoundUserInterface : BoundUserInterface
    {
        private WiresMenu? _menu;

        public WiresBoundUserInterface(ClientUserInterfaceComponent owner, object uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();

            _menu = new WiresMenu(this);
            _menu.OnClose += Close;
            _menu.OpenCenteredLeft();
        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);
            _menu?.Populate((WiresBoundUserInterfaceState) state);
        }

        public void PerformAction(int id, WiresAction action)
        {
            SendMessage(new WiresActionMessage(id, action));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing)
                return;

            _menu?.Dispose();
        }
    }
}
