using System;
using System.Collections.Generic;
using System.Text;

namespace Anori.ExpressionObservers.Nodes
{
    using System.Diagnostics;
    using System.Runtime.CompilerServices;

    using Anori.Common;

    public class ClassDebugger
    {
        private readonly string className;

        public ClassDebugger(string className)
        {
            this.className = className;
        }

        public ClassDebugger(Type type)
        {
            this.className = type.Name;
        }

        public Debugger DebugMethod([CallerMemberName] string? name = null)
        {
            return new Debugger($"{className}.{name}");
        }
    }


    public class Debugger : IDisposable
    {
        private readonly string? name;

        public Debugger(string? name)
        {
            this.name = name;
            Debug.WriteLine($"-> {name}");
        }
        
        public void Dispose()
        {
            Debug.WriteLine($"<- {name}");
        }

        [Conditional("DEBUG")]
        public void WriteLine(string message)
        {
            Debug.WriteLine($" - {name} - {message}");
        }

        public static implicit operator Debugger(ClassDebugger v)
        {
            throw new NotImplementedException();
        }
    }
}
