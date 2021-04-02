using Android.Widget;
using AndroidX.AppCompat.App;
using AndroidX.Core.App;
using Java.Lang;

namespace Zendesk.Messaging.UI
{
    interface IUpdatable<T>
    {
        void update(T paramT);
    }
    
}
