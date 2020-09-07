// Elastic
using Nest;

namespace BagherMusic.Services
{
	public interface IElasticClientService
	{
		IElasticClient GetInstance();
	}
}
