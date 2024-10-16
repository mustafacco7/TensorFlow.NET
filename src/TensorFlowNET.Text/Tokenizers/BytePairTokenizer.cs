using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow.NumPy;
using static Tensorflow.Binding;

namespace Tensorflow.Text.Tokenizers
{
    public class BytePairTokenizer : ITokenizer
    {
        private Dictionary<string, int> bpe_vocab;

        public BytePairTokenizer(Dictionary<string, int> vocab)
        {
            bpe_vocab = vocab;
        }

        public Tensor tokenize(Tensor input)
        {
            var tokens = new List<int>();
            var input_str = input.ToString();

            for (int i = 0; i < input_str.Length; i++)
            {
                for (int j = i + 1; j <= input_str.Length; j++)
                {
                    var subword = input_str.Substring(i, j - i);
                    if (bpe_vocab.ContainsKey(subword))
                    {
                        tokens.Add(bpe_vocab[subword]);
                        i = j - 1;
                        break;
                    }
                }
            }

            return tf.convert_to_tensor(tokens.ToArray(), dtype: dtypes.int32);
        }
    }
}
