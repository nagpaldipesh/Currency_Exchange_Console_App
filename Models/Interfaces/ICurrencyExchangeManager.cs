using System.Threading.Tasks;
using MyLinkedList;

namespace Models.Interfaces
{
    public interface ICurrencyExchangeManager
    {
        Task<LinkedList> GetCurrencyExchangeData();
    }
}
