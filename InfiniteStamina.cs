using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Core.Eventing;
using OpenMod.API.Plugins;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Events;
using OpenMod.Unturned.Players.Stats.Events;

[assembly: PluginMetadata("RaidCity.InfiniteStamina", DisplayName = "Raid City Infinite Stamina Plugin")]
namespace InfiniteStamina
{
    public class InfiniteStamina : IEventListener<UnturnedPlayerStaminaUpdatedEvent>
    {
        [EventListener(Priority = EventListenerPriority.Lowest)]
        public Task HandleEventAsync(object? sender, UnturnedPlayerStaminaUpdatedEvent @event)
        {
            if (@event.Stamina <= 50) @event.Player.Player.life.serverModifyStamina(100);

            return Task.CompletedTask;
        }
    }
}
