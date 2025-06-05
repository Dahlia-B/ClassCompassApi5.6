using System.Collections.Generic;
using System.Threading.Tasks;
using ClassCompass.Shared.Models;

namespace ClassCompassApi.Interfaces
{
    public interface IBehaviorService
    {
        Task RecordBehavior(string studentId, BehaviorRemark remark);
        Task<IEnumerable<BehaviorRemark>> GetBehaviorRecords(string studentId);
    }
}
