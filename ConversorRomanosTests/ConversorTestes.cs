using ConversorRomanos;
namespace ConversorRomanosTests
{
    [TestClass]
    public class ConversorTestes
    {
        [TestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(4, "IV")]
        [DataRow(5, "V")]
        [DataRow(6, "VI")]
        [DataRow(9, "IX")]
        [DataRow(11, "XI")]
        [DataRow(23, "XXIII")]
        [DataRow(43, "XLIII")]
        [DataRow(63, "LXIII")]
        [DataRow(83, "LXXXIII")]
        [DataRow(2482, "MMCDLXXXII")]

        public void ConverterParaDecimal(int numeroDecimal, string numeroRomano)
        {
            Conversor conversor = new();

            var valorConvertido = conversor.ConverterRomanoParaDecimal(numeroRomano);

            Assert.AreEqual(numeroDecimal, valorConvertido);
        }


        [TestMethod]
        [DataRow(1, "I")]
        [DataRow(2, "II")]
        [DataRow(4, "IV")]
        [DataRow(5, "V")]
        [DataRow(6, "VI")]
        [DataRow(9, "IX")]
        [DataRow(11, "XI")]
        [DataRow(23, "XXIII")]
        [DataRow(43, "XLIII")]
        [DataRow(63, "LXIII")]
        [DataRow(83, "LXXXIII")]
        [DataRow(2482, "MMCDLXXXII")]
        public void ConverterParaRomano(int numeroDecimal, string numeroRomano)
        {
            Conversor conversor = new();
            var valorInicial = "";

            var valorConvertido = conversor.ConverterDecimalParaRomano(ref numeroDecimal, ref valorInicial);

            Assert.AreEqual(numeroRomano, valorConvertido);
        }

    }
}