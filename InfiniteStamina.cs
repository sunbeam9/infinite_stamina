using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Events;
using OpenMod.Unturned.Players.Stats.Events;
// For more, visit https://openmod.github.io/openmod-docs/devdoc/guides/getting-started.html

[assembly: PluginMetadata("RaidCity.InfiniteStamina", DisplayName = "Raid City Infinite Stamina Plugin")]
namespace InfiniteStamina
{
    public class InfiniteStamina : IEventListener<UnturnedPlayerStaminaUpdatedEvent>
    {
        [EventListener(Priority = EventListenerPriority.Lowest)]
        public async Task HandleEventAsync(object sender, UnturnedPlayerStaminaUpdatedEvent @event)
        {
            if (@event.Stamina <= 50) @event.Player.Player.life.serverModifyStamina(100);
        }
    }
}
