using Newtonsoft.Json.Linq;

namespace CSharpSelFramework.Utilities
{
    public class jsonReader
    {
        public jsonReader()
        {

        }

        public string extractData(string tokenName)
        {
            var myJsonString = File.ReadAllText("C:\\Users\\Temo\\source\\repos\\CSharpSelFramework\\CSharpSelFramework\\Utilities\\testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            return jsonObject.SelectToken(tokenName).Value<String>();
        }

        public string [] extractDataArray(string tokenName)
        {
            var myJsonString = File.ReadAllText("C:\\Users\\Temo\\source\\repos\\CSharpSelFramework\\CSharpSelFramework\\Utilities\\testData.json");
            var jsonObject = JToken.Parse(myJsonString);
            List<string> productsList =  jsonObject.SelectTokens(tokenName).Values<String>().ToList();
            return productsList.ToArray();
        }
    }
}
