using System.Threading.Tasks;
using ClassCompass.Shared.Models;

namespace ClassCompassApi.Interfaces
{
    public interface IHomeworkService
    {
        Task AssignHomework(Assignment assignment);
        Task GradeHomework(Grade grade);
    }
}
