using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Unturned.Plugins;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Events
// For more, visit https://openmod.github.io/openmod-docs/devdoc/guides/getting-started.html

[assembly: PluginMetadata("RaidCity.InfiniteStamina", DisplayName = "Raid City Infinite Stamina Plugin")]
namespace InfiniteStamina
{
    public class InfiniteStamina : IEventListener<UnturnedPlayerStaminaUpdatedEvent>
    {
        [EventListener(Priority = EventListenerPriority.Lowest)]
        public async Task HandleEventAsync(object sender, UnturnedPlayerEvent @event)
        {
            if (@event.Player.PlayerLife.stamina <= 50) @event.Player.PlayerLife.serverModifyStamina(100.0);
        }
    }
}
