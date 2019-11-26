using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppXamarinCrud
{
	public interface IRestService
	{
		Task<List<Bicycle>> RefreshDataAsync ();

		Task SaveBicycleAsync(Bicycle item, bool isNewItem);

		Task DeleteBicycleAsync(int id);
	}
}
