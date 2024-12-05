using BHF.MS.test15.Models;

namespace BHF.MS.test15.Services
{
    public interface IExampleService
    {
        Task<HttpResponseMessage> PostSomething(ExampleModel model);
        Task<HttpResponseMessage> GetSomething();
    }
}

