namespace ConversorRomanos
{
    public class Conversor()
    {
        Dictionary<int, string> decimalParaRomano = new()
        {
            {1, "I"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"}
        };
        Dictionary<string, int> romanoParaDecimal = new()
        {
            {"I", 1},
            {"V", 5},
            {"X", 10},
            {"L", 50},
            {"C", 100},
            {"D", 500},
            {"M", 1000}
        };

        public int ConverterRomanoParaDecimal(string entrada)
        {
            List<int> entradaConvertida = [];
            var valorConvertido = 0;

            foreach (var letra in entrada.ToList())
                entradaConvertida.Add(romanoParaDecimal[letra.ToString()]);

            if (entradaConvertida.Count > 1)
            {
                if (entradaConvertida == entradaConvertida.OrderDescending())
                    foreach (var valor in entradaConvertida)
                        valorConvertido += valor;
                else
                {
                    for (int i = 1; i < entradaConvertida.Count; i++)
                    {
                        if (entradaConvertida[i - 1] >= entradaConvertida[i])
                            valorConvertido += entradaConvertida[i - 1];
                        else
                        {
                            valorConvertido += entradaConvertida[i] - entradaConvertida[i - 1];
                            i++;
                        }

                        if (i == entradaConvertida.Count - 1)
                            valorConvertido += entradaConvertida[i];
                    }
                }
            }
            else
                valorConvertido = entradaConvertida[0];

            return valorConvertido;
        }

        public string ConverterDecimalParaRomano(ref int entrada, ref string valorConvertido)
        {
            foreach (var valor in decimalParaRomano.Keys.OrderDescending())
            {
                if (entrada == 0)
                    return valorConvertido;

                if (entrada == valor)
                {
                    entrada = 0;
                    return valorConvertido += decimalParaRomano[valor];
                }

                if (valor > 100)
                    ManipularValor(ref entrada, ref valorConvertido, valor, 100);

                else if (valor > 10)
                    ManipularValor(ref entrada, ref valorConvertido, valor, 10);

                else 
                    ManipularValor(ref entrada, ref valorConvertido, valor, 1);
            }

            return valorConvertido;
        }

        private string ManipularValor(ref int entrada, ref string valorConvertido, int valor, int comparacao)
        {
            var ent = Math.Floor(Convert.ToDecimal(entrada / comparacao));
            var val = Math.Floor(Convert.ToDecimal(valor / comparacao));

            var dif = val - ent;

            if (dif == 1 && ent != 0)
            {
                entrada -= valor - comparacao;
                valorConvertido += decimalParaRomano[comparacao] + decimalParaRomano[valor];

                ConverterDecimalParaRomano(ref entrada, ref valorConvertido);
            }

            if (dif <= 0)
            {
                entrada -= valor;
                valorConvertido += decimalParaRomano[valor];

                ConverterDecimalParaRomano(ref entrada, ref valorConvertido);
            }

            return valorConvertido;
        }
    }
}
