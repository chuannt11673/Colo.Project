using System.Threading.Tasks;

namespace Application.Utilities
{
    public static class TaskExtensions
    {
        public static void RunBg(this Task task)
        {
            try
            {
                task.Wait(1);
            }
            catch
            {
                throw;
            }
        }
    }
}
