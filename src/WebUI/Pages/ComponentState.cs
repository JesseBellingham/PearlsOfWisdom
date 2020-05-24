using System;
using System.Threading.Tasks;

namespace PearlsOfWisdom.WebUI.Pages
{
    public abstract class ComponentState
    {
        public event Func<Task> OnStateChanged;

        public void NotifyStateChanged() => OnStateChanged?.Invoke();
    }

    public class PearlsListStateContainer : ComponentState { }
    
    public class KeyPointsListStateContainer : ComponentState { }
}