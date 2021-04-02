// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionAndGetterAndFallback.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    using Anori.ExpressionObservers.Builder;

    /// <summary>
    ///     The Property Value Observer Builder With Action And Getter And Fallback interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    public interface IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>Property Observer With Getter And Fallback.</returns>
        IPropertyObserverWithAndFallback<TResult> Create();
    }


    //public interface IPropertyValueObserverBuilderWithActionAndFallback<TResult> :
    //    IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>>,
    //    IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionAndGetterAndFallback<TResult>>
    //    where TResult : struct
    //{
    //    /// <summary>
    //    ///     Creates this instance.
    //    /// </summary>
    //    /// <returns>Property Observer With Getter And Fallback.</returns>
    //    IPropertyObserverWithFallback<TResult> Create();
    //}
}