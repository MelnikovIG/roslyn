﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Immutable;
using System.Composition;
using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.CodeAnalysis.Options;
using Microsoft.CodeAnalysis.Options.Providers;

namespace Microsoft.CodeAnalysis.GenerateOverrides
{
    internal class GenerateOverridesOptions
    {
        public static readonly Option2<bool> SelectAll = new(
            nameof(GenerateOverridesOptions), nameof(SelectAll), defaultValue: true,
            storageLocation: new RoamingProfileStorageLocation($"TextEditor.Specific.{nameof(GenerateOverridesOptions)}.{nameof(SelectAll)}"));

        [ExportSolutionOptionProvider, Shared]
        internal class GenerateOverridesOptionsProvider : IOptionProvider
        {
            [ImportingConstructor]
            [Obsolete(MefConstruction.ImportingConstructorMessage, error: true)]
            public GenerateOverridesOptionsProvider()
            {
            }

            public ImmutableArray<IOption> Options { get; } = ImmutableArray.Create<IOption>(
                GenerateOverridesOptions.SelectAll);
        }
    }
}
