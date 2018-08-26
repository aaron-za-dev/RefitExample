using System.Threading.Tasks;
using Refit;
using RefitExample;

namespace RefritExample
{

    interface PokemonService    {
        [Get("/api/v2/pokemon")]
        Task<MyResponse> getMyResponse();
    }
}