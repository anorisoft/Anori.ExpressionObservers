// -----------------------------------------------------------------------
// <copyright file="TestClass3.cs" company="AnoriSoft">
// Copyright (c) AnoriSoft. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Anori.ExpressionTrees.UnitTests.TestClasses
{
    using System.Collections.Generic;

    public class TestClass3
    {
        public IList<int> List { get; } = new List<int>
                                              {
                                                  1,
                                                  2,
                                                  3,
                                                  4,
                                                  5
                                              };

        public int Property { get; set; }
    }
}