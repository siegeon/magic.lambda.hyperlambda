/*
 * Magic Cloud, copyright Aista, Ltd. See the attached LICENSE file for details.
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
    [Slot(Name = "hyper2lambda")]
    public class Hyper2Lambda : ISlot
    {
        /// <summary>
        /// Implementation of your slot.
        /// </summary>
        /// <param name="signaler">Signaler that raised the signal.</param>
        /// <param name="input">Arguments to your slot.</param>
        public void Signal(ISignaler signaler, Node input)
        {
            var comments = input.Children.FirstOrDefault(x => x.Name == "comments");
            var parser = HyperlambdaParser.Parse(input.GetEx<string>(), comments?.GetEx<bool>() ?? false);
            comments?.UnTie();
            input.AddRange(parser.Children.ToList());
            input.Value = null;
        }
    }
}
