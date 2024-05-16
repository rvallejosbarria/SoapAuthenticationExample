using System.ServiceModel;

namespace SoapWebService.ServiceContracts;

[ServiceContract]
public interface ISoapService
{
  [OperationContract]
  string SayHello();
}