using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppXamarinCrud
{
	public class BicycleManager
	{
		IRestService restService;

		public BicycleManager (IRestService service)
		{
			restService = service;
		}

		public Task<List<Bicycle>> GetTasksAsync ()
		{
			return restService.RefreshDataAsync ();	
		}

		public Task SaveTaskAsync (Bicycle item, bool isNewItem = false)
		{
			return restService.SaveBicycleAsync (item, isNewItem);
		}

		public Task DeleteTaskAsync (Bicycle item)
		{
			return restService.DeleteBicycleAsync (item.ID);
		}
	}
}
