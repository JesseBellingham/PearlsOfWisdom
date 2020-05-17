using System;
using System.Threading.Tasks;

namespace PearlsOfWisdom.WebUI.Pages
{
    public class ComponentState
    {
        public event Func<Task> OnStateChanged;

        public void NotifyStateChanged() => OnStateChanged?.Invoke();
    }
}