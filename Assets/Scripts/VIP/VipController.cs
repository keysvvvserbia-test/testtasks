using System;
using Core;

namespace VIP
{
    public class VipController : BaseSingleController<VipController>
    {
        public VipToken VipToken { get; }

        public VipController()
        {
            VipToken = new VipToken();
            PlayerData.Instance.RegisterToken<TimeSpan, VipToken>(VipToken);
        }

        public TimeSpan GetDuration()
        {
            return VipToken.Value;
        }

        public void AddTime(TimeSpan time)
        {
            VipToken.Add(time);
        }

        public void AddSeconds(int seconds)
        {
            VipToken.AddSeconds(seconds);
        }

        public void RemoveTime(TimeSpan time)
        {
            VipToken.Remove(time);
        }
        
        public void RemoveSeconds(int seconds)
        {
            VipToken.RemoveSeconds(seconds);
        }
    }
}

