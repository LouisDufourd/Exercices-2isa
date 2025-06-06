using Exercice_bonus;
using System.Text.RegularExpressions;

namespace Exercice_Test
{
    [TestClass]
    public sealed class Test1
    {
        private static readonly Regex sWhitespace = new Regex(@"\s+");

        [DataTestMethod]
        [DataRow('+', 1)]
        [DataRow('-', 1)]
        [DataRow('*', 2)]
        [DataRow('/', 2)]
        [DataRow('%', 2)]
        [DataRow('^', 3)]
        [DataRow('(', 0)]
        [DataRow(')', 0)]

        // Invalid chars
        [DataRow('&', -1)]
        [DataRow('|', -1)]
        [DataRow('=', -1)]
        [DataRow('<', -1)]
        [DataRow('>', -1)]
        [DataRow('!', -1)]
        [DataRow('a', -1)]
        [DataRow('Z', -1)]
        [DataRow('1', -1)]
        [DataRow(' ', -1)]
        [DataRow('\0', -1)]
        [DataRow('[', -1)]
        [DataRow(']', -1)]
        [DataRow('{', -1)]
        [DataRow('}', -1)]
        [DataRow(';', -1)]
        [DataRow(':', -1)]
        [DataRow('"', -1)]
        [DataRow('\u0027', -1)] // single quote
        [DataRow('\\', -1)]
        [DataRow('~', -1)]
        [DataRow('?', -1)]
        [DataRow('.', -1)]
        [DataRow(',', -1)]
        [DataRow('#', -1)]
        [DataRow('$', -1)]
        [DataRow('€', -1)]
        [DataRow('©', -1)]
        [DataRow('☺', -1)]
        [DataRow('\n', -1)]
        [DataRow('\t', -1)]
        [DataRow((char)127, -1)]
        public void PEMDASTest(char op, int expected)
        {
            int result = ReversePolishNotationConverter.PIMDAS(op);
            Assert.AreEqual(expected, result);
        }

        /*[DataTestMethod]
        
        [DataRow("3 + 4", "3 4 +")]
        [DataRow("3 + 4 * 2", "3 4 2 * +")]
        [DataRow("3 * 4 + 2", "3 4 * 2 +")]
        [DataRow("( 3 + 4 ) * 2", "3 4 + 2 *")]
        [DataRow("3 + ( 4 * 2 )", "3 4 2 * +")]
        [DataRow("3 + 4 * 2 / ( 1 - 5 ) ^ 2 ^ 3", "3 4 2 * 1 5 - 2 3 ^ ^ / +")]
        [DataRow("10 + 3 * 5 / ( 16 - 4 )", "10 3 5 * 16 4 - / +")]
        [DataRow("5 + ((1 + 2) * 4) - 3", "5 1 2 + 4 * + 3 -")]
        [DataRow("1 + 2 + 3", "1 2 + 3 +")]
        [DataRow("1 + 2 * 3 + 4", "1 2 3 * + 4 +")]
        [DataRow("1 + 2 + 3 + 4", "1 2 + 3 + 4 +")]
        [DataRow("( 1 + 2 + 3 + 4 )", "1 2 + 3 + 4 +")]
        [DataRow("7 - 2 - 1", "7 2 - 1 -")]
        [DataRow("3 * ( 4 + 5 )", "3 4 5 + *")]
        [DataRow("3 * 4 + 5", "3 4 * 5 +")]
        [DataRow("3 + 4 * 5", "3 4 5 * +")]
        [DataRow("3 * 4 * 5", "3 4 * 5 *")]
        [DataRow("10 + ( 2 * 3 )", "10 2 3 * +")]
        [DataRow("10 + 2 * 3", "10 2 3 * +")]
        [DataRow("( 10 + 2 ) * 3", "10 2 + 3 *")]
        [DataRow("4 + 8 * 6 - 5 / 3 - 2 ^ 2", "4 8 6 * + 5 3 / - 2 2 ^ -")]
        [DataRow("2 ^ 3 ^ 2", "2 3 2 ^ ^")]
        [DataRow("( 2 ^ 3 ) ^ 2", "2 3 ^ 2 ^")]
        [DataRow("1 + 2 - 3 + 4", "1 2 + 3 - 4 +")]
        [DataRow("1 + ( 2 - ( 3 + 4 ) )", "1 2 3 4 + - +")]
        [DataRow("2 * ( 3 + ( 4 * 5 ) )", "2 3 4 5 * + *")]
        [DataRow("3 + 4 + 5 + 6", "3 4 + 5 + 6 +")]
        [DataRow("1 + 2 * 3 ^ 4 - 5", "1 2 3 4 ^ * + 5 -")]
        [DataRow("5 % 2", "5 2 %")]
        [DataRow("5 + 2 % 3", "5 2 3 % +")]
        [DataRow("2 % 3 + 5", "2 3 % 5 +")]
        [DataRow("2 + 3 * 4 % 5", "2 3 4 * 5 % +")]
        [DataRow("3 + 4 * 2 / ( 1 - 5 )", "3 4 2 * 1 5 - / +")]
        [DataRow("5 * ( 6 + 2 ) - 12 / 4", "5 6 2 + * 12 4 / -")]
        [DataRow("4 + 18 / ( 9 - 3 )", "4 18 9 3 - / +")]
        [DataRow("4 * ( 2 + 3 )", "4 2 3 + *")]
        [DataRow("3 * ( 4 + 2 )", "3 4 2 + *")]
        [DataRow("1 + 2 * 3 + 4", "1 2 3 * + 4 +")]
        [DataRow("1 + 2 + 3 + 4 + 5", "1 2 + 3 + 4 + 5 +")]
        [DataRow("( 1 + 2 ) * ( 3 + 4 )", "1 2 + 3 4 + *")]
        [DataRow("( 1 + ( 2 + ( 3 + ( 4 + 5 ) ) ) )", "1 2 3 4 5 + + + +")]
        [DataRow("1 + 2 * 3 - 4 / 2", "1 2 3 * + 4 2 / -")]
        [DataRow("1 + 2 * 3 ^ 2", "1 2 3 2 ^ * +")]
        [DataRow("2 ^ ( 3 + 4 )", "2 3 4 + ^")]
        [DataRow("2 * 3 + 4 * 5", "2 3 * 4 5 * +")]
        [DataRow("2 * ( 3 + 4 ) * 5", "2 3 4 + * 5 *")]
        [DataRow("3 + 4 * ( 2 - 1 )", "3 4 2 1 - * +")]*/
        public void ReversePolishNotationTest(string infix, string expected)
        {
            string rpn = ReversePolishNotationConverter.ReversePolishNotation(infix);
            Assert.AreEqual(sWhitespace.Replace(expected, ""), sWhitespace.Replace(rpn, ""));
            Console.WriteLine();
        }
    }
}
