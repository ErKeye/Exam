using System;

namespace Question1
{
    public class Program
    {
        private static char[] transcode = new char[index_mask+1];  // 64= 2^index_bits_size
        private const int char_bit_size = 8;
        private const int index_bit_size = 6;
        private const int index_mask = 63;

        public static void InitTranscodeArray()
        {
            int i;
            char c;

            for (i = 0, c = 'A'; c <= 'Z'; i++, c++) transcode[i] = c;
            for (c = 'a'; c <= 'z'; i++, c++) transcode[i] = c;
            for (c = '0'; c <= '9'; i++, c++) transcode[i] = c;
            transcode[i++] = '+';
            transcode[i++] = '/';
        }

        static void Main(string[] args)
        {
            InitTranscodeArray();

            string test_string = "This is a test string";

            if (test_string == Decode(Encode(test_string)))            
                Console.WriteLine("Test succeeded");
            else
                Console.WriteLine("Test failed");
        }


        public static string Encode(string input)
        {
            int output_lenght = (input.Length / 3 ) * 4 + input.Length % 3 + 1;
            char[] output = new char[output_lenght];                        
            int char_bits_tail = 0;
            int tail_size = 0;

            for (int output_index = 0, input_index = 0; output_index < output_lenght; output_index++)
            {
                int transcode_index;
                
                if (tail_size < index_bit_size)                                        
                {
                    tail_size += char_bit_size;                    
                    char_bits_tail <<= char_bit_size;                                           
                    int scrolled_mask = index_mask << tail_size - index_bit_size;
                    if (input_index < input.Length)
                        char_bits_tail += input[input_index++];                                      
                    transcode_index = (char_bits_tail & scrolled_mask) >> tail_size - index_bit_size;
                }
                else                                                        
                    transcode_index = char_bits_tail & index_mask;
                tail_size -= index_bit_size;
                output[output_index] = transcode[transcode_index];
           }
            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }


        public static string Decode(string input)
        {
            int output_lenght = (input.Length / 4 ) * 3 + input.Length % 4-1;
            char[] output = new char[output_lenght];
            int c = 0;
            int tail_size = 0;
            int char_bits_tail = 0;

            for (int j = 0; j < input.Length; j++)
            {
                tail_size += index_bit_size;
                char_bits_tail <<= index_bit_size;
                char_bits_tail += GetTranscodeIndex(input[j]);

                if (tail_size >= char_bit_size)
                {
                    int mask = 0x000000ff << (tail_size - char_bit_size);
                    output[c++] =(char)( (char_bits_tail & mask) >> (tail_size - char_bit_size));
                    tail_size -= char_bit_size;
                }
            }
            Console.WriteLine("{0} --> {1}\n", input, new string(output));
            return new string(output);
        }


        private static int GetTranscodeIndex(char ch)
        {
            int index;
            for (index = 0; index < transcode.Length && ch != transcode[index]; index++);
            return index;
        }
    }
}
