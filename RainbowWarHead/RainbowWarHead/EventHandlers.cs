using System;
using System.Collections.Generic;
using Qurre.API.Events;
using Qurre.API.Controllers;
using UnityEngine;
using MEC;
using Qurre.API;

namespace RainbowWarHead
{ 

    public class EventHandlers
    { 
        private readonly Plugin plugin; 
        public EventHandlers(Plugin plugin) => this.plugin = plugin; 
        public void RainbowMethod()
        {
            Timing.RunCoroutine(RainbowCoroutine(), "CorName"); 
        }
        public void Warheadstart(AlphaStartEvent ev)
        {
            Timing.RunCoroutine(RainbowCoroutine(), "CorName");
        } 
        public IEnumerator<float> RainbowCoroutine()
        {
            for(; ; )
            {
                Qurre.API.Controllers.Lights.ChangeColor(Color.blue);
                yield return Timing.WaitForSeconds(3f);
                Qurre.API.Controllers.Lights.ChangeColor(Color.green);
                yield return Timing.WaitForSeconds(3f);
                Qurre.API.Controllers.Lights.ChangeColor(Color.yellow);
                yield return Timing.WaitForSeconds(3f); 
                Qurre.API.Controllers.Lights.ChangeColor(Color.magenta);
                yield return Timing.WaitForSeconds(3f);
                Qurre.API.Controllers.Lights.ChangeColor(Color.cyan);
            }
        } 
        public void OnRoundEnd(RoundEndEvent ev)
        {
            Timing.KillCoroutines("CorName");
        }
        public void OnRoundWaiting()
        {
            Timing.KillCoroutines("CorName");
        }
        public void OnWarHeadCancel(AlphaStopEvent ev)
        { 
            Timing.KillCoroutines("CorName");
            foreach (var room in Map.Rooms)
            {
                room.LightOverride = false;

            }   
        }      
    }
}
