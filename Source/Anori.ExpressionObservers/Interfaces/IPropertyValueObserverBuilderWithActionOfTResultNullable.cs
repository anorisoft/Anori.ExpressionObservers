// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithActionOfTResultNullable.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces
{
    /// <summary>
    /// The I Property Value Observer Builder With Action Of T Result Nullable interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderBase{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}}" />
    /// <seealso cref="Anori.ExpressionObservers.Interfaces.IGetterTaskScheduler{Anori.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithActionOfTResultNullable{TResult}}" />
    public interface IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult> :
        IPropertyValueObserverBuilderBase<IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>>,
        IGetterTaskScheduler<IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IPropertyValueObserver<TResult> Create();

        // ToDo Not FallBck
        ///// <summary>
        ///// Withes the fallback.
        ///// </summary>
        ///// <param name="fallback">The fallback.</param>
        ///// <returns></returns>
        //IPropertyValueObserverBuilderWithActionOfTResultNullable<TResult>
        //    WithFallback(TResult fallback);
    }
}