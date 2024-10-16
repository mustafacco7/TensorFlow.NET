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
                name = scope;
                var wordshape = tf.strings.regex_full_match(input, pattern.ToString(), name: name);
                return wordshape;
            });
        }
    }
}
