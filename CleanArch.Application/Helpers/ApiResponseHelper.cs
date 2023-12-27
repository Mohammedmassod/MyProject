//using CleanArch.Logging;
namespace MyProject.Application.Helpers
{
    public class ApiResponseHelper
    {
        public static ApiResponse<T> HandleError<T>(Exception ex)
        {
            var apiResponse = new ApiResponse<T>
            {
                Success = false,
                Message = ex.Message
               // Logger.Instance.Error("Exception:", ex);
        };
            // يمكنك إضافة المزيد من المعالجة هنا
            return apiResponse;
        }
    }
}
