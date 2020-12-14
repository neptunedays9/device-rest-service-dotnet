using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace DeviceApp.util.lib.Error 
{
    public static class ErrorMap {
        
        private static List<AppError> errorList = new List<AppError>{};

        public static void InitializeErrorMap() {
            AddError(ErrorSet.DuplicateItemFoundErrorId, HttpStatusCode.Forbidden, ErrorSet.DuplicateItemFoundErrorMessage);
            AddError(ErrorSet.ItemProcessingErrorId, HttpStatusCode.Forbidden, ErrorSet.ItemProcessingErrorMessage);
            AddError(ErrorSet.InvalidInputErrorId, HttpStatusCode.Forbidden, ErrorSet.InvalidInputErrorMessage);
            AddError(ErrorSet.InvalidPurchaseItemErrorId, HttpStatusCode.Forbidden, ErrorSet.InvalidPurchaseItemErrorMessage);
        }

        public static void AddError(string appErrorCode, HttpStatusCode apiStatusCode, string appErrorMessage) {
            errorList.Add(new AppError {
                        appErrorCode = appErrorCode,
                        apiStatusCode = apiStatusCode,
                        appErrorMessage = appErrorMessage
                    });
        }

        public static AppError GetErrorDetails(string appErrorCode) {
            if(errorList.Count == 0) {
                InitializeErrorMap();
            }
            return errorList.FirstOrDefault(e => e.appErrorCode == appErrorCode);
        }
    }
}