using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs.InputModel
{
    public class InputModelPrevisaoDeGastos
    {
        private decimal _valorCombustivel;
        private decimal _kmQueSeraPercorridoCidade;
        private decimal _kmQueSeraPercorridosRodovia;

        public InputModelPrevisaoDeGastos()
        {

        }

        public InputModelPrevisaoDeGastos(decimal valorCombustivel, decimal kmQueSeraPercorridoCidade, decimal kmQueSeraPercorridosRodovia)
        {
            this.ValorCombustivel = valorCombustivel;
            this.KmQueSeraPercorridoCidade = kmQueSeraPercorridoCidade;
            this.KmQueSeraPercorridosRodovia = kmQueSeraPercorridosRodovia;
        }
        [Required]
        public decimal ValorCombustivel
        {
            get => _valorCombustivel;
            set
            {
                if (value < 0)
                {
                    this._valorCombustivel = 0;
                }
                else
                {
                    this._valorCombustivel = value;
                }
            }
        }
        [Required]
        public decimal KmQueSeraPercorridoCidade
        {
            get => _kmQueSeraPercorridoCidade;
            set
            {
                if (value < 0)
                {
                    this._kmQueSeraPercorridoCidade = 0;
                }
                else
                {
                    this._kmQueSeraPercorridoCidade = value;
                }
            }
        }
        [Required]
        public decimal KmQueSeraPercorridosRodovia
        {
            get => _kmQueSeraPercorridosRodovia;
            set
            {
                if (value < 0)
                {
                    this._kmQueSeraPercorridosRodovia = 0;
                }
                else
                {
                    this._kmQueSeraPercorridosRodovia = value;
                }
            }
        }

    }


}
