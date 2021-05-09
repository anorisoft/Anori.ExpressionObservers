// -----------------------------------------------------------------------
// <copyright file="IBuilderWithActionOfNullTAndScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnValueChanged
{
    public interface IBuilderWithActionOfNullTAndScheduler<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullTAndScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        INotifyPropertyObserver<TResult> Build();
    }
}