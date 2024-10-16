using Tensorflow.NumPy;
using System;
using System.Collections.Generic;
using System.Text;
using static Tensorflow.Binding;

namespace Tensorflow.Text.Tokenizers
{
    public class CharacterTokenizer : ITokenizer
    {
        /// <summary>
        /// Tokenizes a tensor of UTF-8 strings into characters.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Tensor tokenize(Tensor input)
        {
            return tf.strings.unicode_split(input, "UTF-8");
        }
    }
}
