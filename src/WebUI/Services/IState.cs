using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PearlsOfWisdom.WebUI.Services
{
    public interface IState<TModel>
        where TModel : class
    {
        Task Add(TModel model);
        Task<List<TModel>> GetAll();
        event Action OnItemAdded;
        void NotifyStateChanged();
    }
}