using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace Fortune;

public class Plugin : Plugin<Config>
{
    public override string Name => "Fortune Flip";
    public override string Author => "ALEXWARELLC & Zachuttak0";
    public override string Prefix => "fortuneflip";
    public override bool IgnoreRequiredVersionCheck => true;

    public override void OnEnabled()
    {
        Log.Info($"Registering {Name} events...");

        Exiled.Events.Handlers.Player.FlippingCoin += OnUsingCoin;
    }

    public override void OnDisabled()
    {
        Log.Info($"Unregistering {Name} events...");

        Exiled.Events.Handlers.Player.FlippingCoin -= OnUsingCoin;
    }

    public void OnUsingCoin(FlippingCoinEventArgs ev)
    {
        if (!Config.IsEnabled)
            return;

        if (new Random().Next(0, Config.ActivationMax) <= Config.ActivationChance)
        {
            if (ev.IsTails)
            {
                EffectType effect = ev.Player.ApplyRandomEffect(Exiled.API.Enums.EffectCategory.Harmful, 20, true);
                ev.Player.Broadcast(5, $"You received the {effect} effect.");
            }
            else
            {
                EffectType effect = ev.Player.ApplyRandomEffect(Exiled.API.Enums.EffectCategory.Positive, 20, true);
                ev.Player.Broadcast(5, $"You received the {effect} effect.");
            }
        }
        else
        {
            ev.Player.Broadcast(5, "You didn't receive an effect.");
        }
    }
}
