/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
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
    [Slot(Name = "hyper")]
    public class Hyper : ISlot
    {
        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler that raised the signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            if (input.Value != null && input.Children.Any())
                throw new ApplicationException("Provide either children or expression value to [hyper], not both");

            if (input.Children.Any())
                input.Value = Generator.GetHyper(input.Children);
            else
                input.Value = Generator.GetHyper(input.Evaluate());
        }
    }
}
