using System;
using System.Collections.Generic;
using System.Text;
using static Tensorflow.Binding;

namespace Tensorflow.Text
{
    public partial class TextOps
    {
        public static Tensor ngrams(Tensor input, int width, 
            int axis = -1, 
            Reduction reduction_type = Reduction.None,
            string string_separator = " ",
            string name = null)
        {
            return tf_with(ops.name_scope(name, "Ngrams", new { input }), scope =>
            {
                name = scope;
                var ngrams = tf.strings.ngrams(input, width, axis: axis, reduction_type: reduction_type.ToString(), string_separator: string_separator, name: name);
                return ngrams;
            });
        }
    }
}
