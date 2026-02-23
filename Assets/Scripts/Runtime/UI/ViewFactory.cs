using UnityEngine;
using ZooWorld.Foundation;

namespace ZooWorld.UI
{
    public class ViewFactory : BasePoolFactory<BaseView>
    {
        public ViewFactory(Transform root) : base(root)
        {}
    }
}