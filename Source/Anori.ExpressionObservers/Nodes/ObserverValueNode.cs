// -----------------------------------------------------------------------
// <copyright file="ObserverValueNode.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    using Anori.ExpressionTrees.Interfaces;

    using JetBrains.Annotations;

    internal class ObserverNode<TResult> : ObserverNodeBase
    {
        private static ClassDebugger DebugExtensions { get; } = new (typeof(ObserverNode<TResult>));

        public TResult Value { get; set; }
        public Func<TResult?> Getter { get; set; }

        public ObserverNode([NotNull] Action action)
            : base(action)
        {
            using var debug = DebugExtensions.DebugMethod();
        }
    }

    internal class ObserverNode : ObserverNodeBase
    {
        private static ClassDebugger DebugExtensions { get; } = new (typeof(ObserverNode));
        public ObserverNode([NotNull] Action action)
            : base(action)
        {
            using var debug = DebugExtensions.DebugMethod();

        }
    }

    internal class SubObserverNode : ObserverNodeBase
    {
        private static ClassDebugger DebugExtensions { get; } = new (typeof(SubObserverNode));
        public SubObserverNode(ObserverNodeBase observerNode, IExpressionNode node)
            : base(observerNode.Action)
        {
            using var debug = DebugExtensions.DebugMethod();
        }

        public object Value { get; internal set; }
        internal Func<object?> Getter { get; set; }
    
    }

  
    internal abstract class ObserverNodeBase

    {
        private static ClassDebugger DebugExtensions { get; } = new(typeof(SubObserverNode));

        public IReadOnlyList<ParameterExpression> Parameters { get; set; }

        public ObserverNodeBase(Action action)
        {
            using var debug = DebugExtensions.DebugMethod();
            this.Action = action;
        }

        public Action Action { get; }

        public ObserverNodeBase? Parent { get; private set; }

        public IReadOnlyList<ObserverNodeBase> Children => this.children;

        private readonly List<ObserverNodeBase> children = new();

        public ObserverNodeBase AddChild(ObserverNodeBase child)
        {
            using var debug = DebugExtensions.DebugMethod();
            this.children.Add(child);
            child.Parent = this;
            return this;
        }
    }
}