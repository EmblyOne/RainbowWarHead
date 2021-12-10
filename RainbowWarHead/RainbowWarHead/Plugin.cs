using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;

namespace RainbowWarHead
{
    public class Plugin : Qurre.Plugin
    {
        #region override 
        public EventHandlers EventHandlers;
        public override int Priority { get; } = -9999999;
        public override string Developer { get; } = "G-Man";
        public override string Name { get; } = "RainbowWarHead";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version NeededQurreVersion { get; } = new Version(1, 10, 0);
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        #endregion
        #region Events
        #region RegEvents 
        private void RegisterEvents()
        {
            EventHandlers = new EventHandlers(this);
            Qurre.Events.Alpha.Starting += EventHandlers.Warheadstart;
            Qurre.Events.Round.End += EventHandlers.OnRoundEnd;
            Qurre.Events.Round.Waiting += EventHandlers.OnRoundWaiting;
            Qurre.Events.Alpha.Stopping += EventHandlers.OnWarHeadCancel; 
        }
        private void UnregisterEvents()
        {
            Qurre.Events.Alpha.Starting -= EventHandlers.Warheadstart;
            Qurre.Events.Round.End -= EventHandlers.OnRoundEnd;
            Qurre.Events.Round.Waiting -= EventHandlers.OnRoundWaiting;
            Qurre.Events.Alpha.Stopping -= EventHandlers.OnWarHeadCancel;
            EventHandlers = null; 
        }
       
    }
    #endregion
}
#endregion