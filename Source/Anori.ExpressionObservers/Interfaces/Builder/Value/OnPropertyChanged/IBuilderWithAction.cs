// -----------------------------------------------------------------------
// <copyright file="IPropertyValueObserverBuilderWithAction{TResult}.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionObservers.Interfaces.Builder.Value.OnPropertyChanged
{
    /// <summary>
    ///     The I Value Property Observer Builder With Action interface.
    /// </summary>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso
    ///     cref="IObserverBuilderBase{TSelf}.ExpressionObservers.Interfaces.IPropertyValueObserverBuilderWithAction{TResult}}" />
    public interface
        IBuilderWithAction<TResult> : IObserverBuilderBase<
            IBuilderWithAction<TResult>>
        where TResult : struct
    {
        /// <summary>
        ///     Creates this instance.
        /// </summary>
        /// <returns>The Property Observer.</returns>
        IPropertyObserver<TResult> Build();

        /// <summary>
        ///     Withes the getter.
        /// </summary>
        /// <returns>The Property Observer Builder.</returns>
        IBuilderWithActionAndGetter<TResult> WithGetter();
    }
}