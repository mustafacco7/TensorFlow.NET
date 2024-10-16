using System;
using System.Collections.Generic;
using System.Text;
using static Tensorflow.Binding;

namespace Tensorflow.Text
{
    public partial class TextOps
    {
        public static Tensor wordshape(Tensor input, WordShape pattern, string name = null)
        {
            return tf_with(ops.name_scope(name, "Wordshape", new { input }), scope =>
            {
                input = ops.convert_to_tensor(input, name: "input");

                string regex_pattern = pattern switch
                {
                    WordShape.HAS_TITLE_CASE => @"\b[A-Z][a-z]*\b",
                    WordShape.IS_UPPERCASE => @"\b[A-Z]+\b",
                    WordShape.HAS_SOME_PUNCT_OR_SYMBOL => @"[^\w\s]",
                    WordShape.IS_NUMERIC_VALUE => @"\b\d+\b",
                    _ => throw new ArgumentOutOfRangeException(nameof(pattern), pattern, null)
                };

                var wordshape = tf.strings.regex_full_match(input, regex_pattern);

                return wordshape;
            });
        }
    }
}
