using System;
using Core;

namespace VIP.View
{
    public class VipCounterView : BaseTokenCounterView<TimeSpan, VipToken>
    {
        private void Start()
        {
            SetToken(VipController.Instance.VipToken);
        }
    }
}