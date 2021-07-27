using System.Collections.Generic;
namespace firstTUT.Contract.V1.VModels
{
    public class VmRegistrationFailure
    {
        public IEnumerable<string> Errors { get; set; }
    }
}