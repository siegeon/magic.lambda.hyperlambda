﻿/*
 * Magic, Copyright(c) Thomas Hansen 2019 - 2021, thomas@servergardens.com, all rights reserved.
 * See the enclosed LICENSE file for details.
 */

using System;
using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using magic.node.extensions.hyperlambda;

namespace magic.lambda.hyperlambda
{
    /// <summary>
    /// [hyper] slot for creating Hyperlambda from a lambda hierarchy.
    /// </summary>
    [Slot(Name = "lambda2hyper")]
    public class Lambda2Hyper : ISlot
    {
        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler that raised the signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            // Sanity checking invocation.
            if (input.Value == null && !input.Children.Any())
                throw new ArgumentException("Provide either children nodes or expression value to [lambda2hyper]");

            // Checking type of invocation, and acting accordingly.
            if (input.Value is Expression)
            {
                input.Value = Generator
                    .GetHyper(
                        input.Evaluate(),
                        input
                            .Children
                            .FirstOrDefault(x => x.Name == "comments")?
                            .GetEx<bool>() ?? false);
            }
            else
            {
                input.Value = Generator.GetHyper(input.Children);
            }
        }
    }
}
