/*
 * Magic, Copyright(c) Thomas Hansen 2019 - thomas@gaiasoul.com
 * Licensed as Affero GPL unless an explicitly proprietary license has been obtained.
 */

using System.Linq;
using magic.node;
using magic.node.extensions;
using magic.signals.contracts;
using magic.node.extensions.hyperlambda;

namespace magic.lambda.hyperlambda
{
    /// <summary>
    /// [lambda] slot, allowing you to transform a piece of Hyperlambda to a lambda hierarchy.
    /// </summary>
    [Slot(Name = "lambda")]
    public class Lambda : ISlot
    {
        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler that raised the signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var parser = new Parser(input.Get<string>());
            input.AddRange(parser.Lambda().Children.ToList());
            input.Value = null;
        }
    }
}
