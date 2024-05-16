namespace SoapWebService.ServiceContracts;

public class SoapService : ISoapService
{
  public string SayHello()
  {
    return "Hello World!";
  }
}