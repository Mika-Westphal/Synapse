﻿namespace Synapse.Api.Events
{
    public class EventHandler
    {
        internal EventHandler() { }

        public delegate void OnSynapseEvent<TEvent>(TEvent ev) where TEvent : SynapseEventArgs;

        public ServerEvents Server { get; } = new ServerEvents();
        
        public PlayerEvents Player { get; } = new PlayerEvents();
        
        public interface SynapseEventArgs
        {
            void LogInConsole();
        }
    }
}