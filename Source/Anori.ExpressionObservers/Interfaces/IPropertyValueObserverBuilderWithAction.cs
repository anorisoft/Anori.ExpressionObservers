// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithAction.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    ///     The I Value Property Observer Builder With Action interface.
    /// </summary>
    /// <typeparam name="TParameter1">The type of the parameter1.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverBuilderWithAction<TResult> : IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithAction<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyObserver<TResult> Create();

        /// <summary>
        /// Withes the getter.
        /// </summary>
        /// <returns></returns>
        IPropertyValueObserverBuilderWithActionAndGetter<TResult> WithGetter();
//        IPropertyValueObserverBuilderWithActionAndFallback<TResult> WithFallback(TResult fallback);
    }
}