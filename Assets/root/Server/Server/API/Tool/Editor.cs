#if !UNITY_5_3_OR_NEWER
using ModelContextProtocol.Protocol;
using ModelContextProtocol.Server;
using System.ComponentModel;
using System.Threading.Tasks;

namespace com.IvanMurzak.Unity.MCP.Server.API
{
    [McpServerToolType]
    public partial class Tool_Editor
    {
    }
}
#endif