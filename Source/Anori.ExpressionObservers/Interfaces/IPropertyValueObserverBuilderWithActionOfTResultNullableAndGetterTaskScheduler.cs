// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result Nullable And Getter Task Scheduler interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="IPropertyObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult> :
        IPropertyObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultNullableAndGetterTaskScheduler<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserver<TResult> Create();

        // ToDo Not FallBack
        ///// <summary>
        ///// Withes the fallback.
        ///// </summary>
        ///// <param name="fallback">The fallback.</param>
        ///// <returns></returns>
        //IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>
        //    WithFallback(TResult fallback);
    }
}