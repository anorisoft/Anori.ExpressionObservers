// -----------------------------------------------------------------------
// <copyright file="ObserverTree.ObserverTreeFactory.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.ExpressionNodeSplitter
{
    using System.Collections.Generic;
    using System.Linq;

    using Anori.ExpressionTrees.Interfaces;

    public partial class ObserverTree
    {
        public class ObserverTreeFactory
        {
            private readonly List<IObservableFinder> finders = new();

            public ObserverTreeFactory(params IObservableFinder[] finders)
            {
                this.finders.AddRange(finders);
            }

            public ObserverTree New<TParameter1, TResult>(IExpressionTree expressionTree)
            {
                var expressionHead = expressionTree.Head;
                var head = new NotifyPropertyChangedObserverTreeHead(expressionHead);
                var tree = new ObserverTree(head, typeof(TResult));
                this.AddIfIsObservable(expressionHead, head);
                return tree;
            }

            private void AddIfIsObservable(IExpressionNode expressionNode, IObserverTreeNode node)
            {
                foreach (var parameter in expressionNode.ParameterNotes)
                {
                    this.AddItemIfIsObservable(node, parameter);
                }
            }
            
            private void AddItemIfIsObservable(IObserverTreeNode node, IExpressionNode parameter)
            {
                foreach (var child in this.finders
                    .Where(finder => finder.IsObservable(parameter))
                    .Select(finder => finder.CreateObserverTreeNode(parameter)))
                {
                    node.AddChild(child);
                    this.AddIfIsObservable(parameter, child);
                    return;
                }

                this.AddIfIsObservable(parameter, node);
            }
        }
    }
}