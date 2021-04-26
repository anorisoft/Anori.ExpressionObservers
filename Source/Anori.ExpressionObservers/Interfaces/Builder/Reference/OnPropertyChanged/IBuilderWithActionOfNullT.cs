// -----------------------------------------------------------------------
// <copyright file="IPropertyReferenceObserverBuilderWithActionOfNullableT.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Reference.OnPropertyChanged
{
    /// <summary>
    ///     The I Property Reference Observer Builder With Action Of T Result interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfT{TResult}}" />
    /// <seealso
    ///     cref="IPropertyObserverScheduler{TTarget}.ExpressionObservers.Interfaces.Builder.IPropertyReferenceObserverBuilderWithActionOfTAndScheduler{TResult}}" />
    public interface IBuilderWithActionOfNullT<TResult> :
        IObserverBuilderBase<IBuilderWithActionOfNullT<TResult>>,
        IPropertyObserverScheduler<
            IBuilderWithActionOfNullTAndScheduler<TResult>>
        where TResult : class
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>
        ///     The Property Observer.
        /// </returns>
        IGetterReferencePropertyObserver<TResult> Build();
    }
}