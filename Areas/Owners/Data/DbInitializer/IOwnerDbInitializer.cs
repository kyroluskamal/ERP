using System.Threading.Tasks;

namespace ERP.Areas.Owners.Data.DbInitializer
{
    public interface IOwnerDbInitializer
    {
        Task Initialize();
    }
}
