using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Alura.Estacionamento.Test
{
    public class PatioTest
    {

        [Fact]
        public void ValidaFaturamento() { 

            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "John";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Green";
            veiculo.Modelo = "Mercedes";
            veiculo.Placa = "ABC-1234";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Margot", "KJN-3874", "black", "Clio")]
        [InlineData("Margareth", "FTR-8346", "red", "C3")]
        [InlineData("Mariah", "LOU-0985", "purple", "Ford Ka")]
        [InlineData("Mercedes", "GTR-7652", "yellow", "S60")]

        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);

        }

        [Theory]
        [InlineData("Maisa", "HGT-7638", "pink", "Ferrari")]
        public void LocalizaVeiculoPatio(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange 
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act 
            var consultado = estacionamento.PesquisaVeiculo(placa);

            //Assert
            Assert.Equal(placa, consultado.Placa);
        }
     
        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            Patio estacionamento = new Patio();
            var veiculo = new Veiculo();
            veiculo.Proprietario = "Aoife";
            veiculo.Placa = "SWO-8453";
            veiculo.Cor = "blue"; //Alterado
            veiculo.Modelo = "Rolls-Royce Boat Tail";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Aoife";
            veiculoAlterado.Placa = "SWO-8453";
            veiculoAlterado.Cor = "magenta"; //Alterado
            veiculoAlterado.Modelo = "Rolls-Royce Boat Tail";

            //Act 
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }
        
    }
}
