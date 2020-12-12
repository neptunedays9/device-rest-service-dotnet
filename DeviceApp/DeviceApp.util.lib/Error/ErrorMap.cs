using System.Collections.Generic;
using System.Net;

namespace DeviceApp.util.lib.Error 
{
    public class ErrorMap {
        
        private List<AppError> errorList;

        ErrorMap() {
            errorList = new List<AppError>();

            InitializeErrorMap();
        }

        void AddError(string appErrorCode, HttpStatusCode apiStatusCode, string appErrorMessage) {
            errorList.Add(new AppError {
                        appErrorCode = appErrorCode,
                        apiStatusCode = apiStatusCode,
                        appErrorMessage = appErrorMessage
                    });
        }

        public void InitializeErrorMap() {
            AddError(ErrorSet.DuplicateItemFoundErrorId, HttpStatusCode.Forbidden, ErrorSet.DuplicateItemFoundErrorMessage);
            AddError(ErrorSet.ItemProcessingErrorId, HttpStatusCode.Forbidden, ErrorSet.ItemProcessingErrorMessage);
            AddError(ErrorSet.InvalidInputErrorId, HttpStatusCode.Forbidden, ErrorSet.InvalidInputErrorMessage);
            AddError(ErrorSet.InvalidPurchaseItemErrorId, HttpStatusCode.Forbidden, ErrorSet.InvalidPurchaseItemErrorMessage);
        }
    }
}