// -----------------------------------------------------------------------
// <copyright file="IBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The I Value property observer builder With Action interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IBuilderWithAction<TResult> : IObserverBuilderBase<IBuilderWithAction<TResult>>,
                                                   ICacheBase<IBuilderWithAction<TResult>>,
                                                   IDeferrerBase<IBuilderWithActionAndDeferrer<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The property observer.</returns>
        IPropertyObserver<TResult> Build();

        /// <summary>
        ///     Builder with getter.
        /// </summary>
        /// <returns>The property observer builder.</returns>
        IBuilderWithActionAndGetter<TResult> WithGetter();
    }
}