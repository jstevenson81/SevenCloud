using NHapi.Base.Model;
using NHapi.Base.Parser;

namespace SevenCloud.Parser
{
    public class Parser
    {
        public IMessage Parse(string message)
        {
            var pipeParser = new PipeParser();
            var parsedMessage = pipeParser.Parse(message);
            return parsedMessage;
        }
    }
}
