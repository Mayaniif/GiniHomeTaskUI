
using System.Threading.Tasks;

namespace GiniHomeTaskUI.Services
{
    public static class SearchService
    { 
        public  static async Task<string> GetRepositoryInfo(string guery)
        {
           await HttpService.GetRequest($"api/repo/{guery}");
            return "null";
            
        }
    }
}
