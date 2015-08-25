﻿namespace Santase.Logic.Logger
{
    using System.Text;

    public class MemoryLogger : ILogger
    {
        private readonly StringBuilder logs = new StringBuilder();

        public void Log(string message)
        {
            this.logs.Append(message);
        }

        public void LogLine(string message)
        {
            this.logs.AppendLine(message);
        }

        public override string ToString()
        {
            return this.logs.ToString();
        }
    }
}
