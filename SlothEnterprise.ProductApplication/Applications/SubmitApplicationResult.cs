using System;
using SlothEnterprise.External;

namespace SlothEnterprise.ProductApplication.Applications
{
    /// <summary>
    /// Interface for application submition result
    /// </summary>
    public interface ISubmitApplicationResult
    {
        int? ApplicationId { get; set; }
        
        bool Success { get; set; }
        
        string Message { get; set; }
    }
    
    public class SubmitApplicationResult : ISubmitApplicationResult
    {
        public int? ApplicationId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }

        public SubmitApplicationResult(IApplicationResult applicationResult)
        {
            ApplicationId = applicationResult.ApplicationId;
            Success = applicationResult.Success;
            Message = string.Join(";", applicationResult.Errors);
        }

        public SubmitApplicationResult(int applicationId)
        {
            ApplicationId = applicationId;
            Success = true;
        }
    }
}