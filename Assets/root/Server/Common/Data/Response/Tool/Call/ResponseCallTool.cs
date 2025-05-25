#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
using System.Collections.Generic;

namespace com.IvanMurzak.Unity.MCP.Common.Data
{
    public class ResponseCallTool : IResponseCallTool
    {
        public bool IsError { get; set; }
        public List<ResponseCallToolContent> Content { get; set; } = new();

        public ResponseCallTool() { }
        public ResponseCallTool(bool isError, List<ResponseCallToolContent> content)
        {
            IsError = isError;
            Content = content;
        }

        public static ResponseCallTool Error(string? message)
            => new ResponseCallTool(isError: true, new List<ResponseCallToolContent> { new ResponseCallToolContent()
            {
                Type = "text",
                Text = message,
                MimeType = Consts.MimeType.TextPlain
            } });

        public static ResponseCallTool Success(string? message)
            => new ResponseCallTool(isError: false, new List<ResponseCallToolContent> { new ResponseCallToolContent()
            {
                Type = "text",
                Text = message,
                MimeType = Consts.MimeType.TextPlain
            } });
    }
}