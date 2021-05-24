using FoodTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace FoodTracker.ftTrackService
{
    public interface IFtTrack
    {
        Task<ObservableCollection<Item>> GetItems();
        Task<bool> AddItem(Item item);
    }
}
