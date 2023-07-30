using Xunit;
using Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Alura.Estacionamento.Modelos;

namespace Alura.Estacionamento.Test
{
    public class VeiculoTest
    {
        [Fact(DisplayName = "Test001")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            var velocidade = 100;
            var veiculo = new Veiculo();
            veiculo.Acelerar(10);
            Assert.Equal(velocidade, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Test002")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            var freio = -150;
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(freio, veiculo.VelocidadeAtual);
        }

        [Fact(Skip = "Not imlemented")]
        public void ValidaNomeProprietario()
        {

        }

        [Fact]
        public void DadosVeiculo()
        {
            //Arrange
            var carro = new Veiculo();
            carro.Proprietario = "Jane";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "BGF-9654";
            carro.Cor = "nude";
            carro.Modelo = "Mustang";

            //Act
            string dados = carro.ToString();

            //Assert
            Assert.Contains("Ficha do veiculo", dados);
        }
    }
}