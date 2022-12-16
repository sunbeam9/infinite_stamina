using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Cysharp.Threading.Tasks;
using OpenMod.Core.Eventing;
using OpenMod.API.Plugins;
using OpenMod.API.Eventing;
using OpenMod.Unturned.Plugins;
using OpenMod.Unturned.Events;
using OpenMod.Unturned.Players.Stats.Events;

[assembly: PluginMetadata("RaidCity.InfiniteStamina", DisplayName = "Raid City Infinite Stamina Plugin")]
namespace InfiniteStamina
{
    public class InfiniteStaminaPlugin: OpenModUnturnedPlugin
      {
          public InfiniteStaminaPlugin
          (
              IServiceProvider serviceProvider
          ) : base(serviceProvider)
          {
          }

          protected override UniTask OnLoadAsync()
          {
            return UniTask.CompletedTask;
          }

          protected override UniTask OnUnloadAsync()
          {
            return UniTask.CompletedTask;
          }
      }

    public class StaminaUpdatedEventListener : IEventListener<UnturnedPlayerStaminaUpdatedEvent>
    {
        [EventListener(Priority = EventListenerPriority.Lowest)]
        public Task HandleEventAsync(object? sender, UnturnedPlayerStaminaUpdatedEvent @event)
        {
            if (@event.Stamina <= 95) @event.Player.Player.life.serverModifyStamina(100);

            return Task.CompletedTask;
        }
    }

    public class FoodUpdatedEventListener : IEventListener<UnturnedPlayerFoodUpdatedEvent>
    {
        [EventListener(Priority = EventListenerPriority.Lowest)]
        public Task HandleEventAsync(object? sender, UnturnedPlayerFoodUpdatedEvent @event)
        {
            if (@event.Food <= 5) @event.Player.Player.life.serverModifyFood(50);

            return Task.CompletedTask;
        }
    }

    public class WaterUpdatedEventListener : IEventListener<UnturnedPlayerWaterUpdatedEvent>
    {
        [EventListener(Priority = EventListenerPriority.Lowest)]
        public Task HandleEventAsync(object? sender, UnturnedPlayerWaterUpdatedEvent @event)
        {
            if (@event.Water <= 5) @event.Player.Player.life.serverModifyWater(50);

            return Task.CompletedTask;
        }
    }

}
