using System;
using NUnit.Framework;

namespace Calculator
{
    // Agregar atributo para indicar que es una clase con pruebas
    [TestFixture]
    class UnitTests
    {
        // Estado inicial de la calculadora
        // CalculadoraEstadoInicialTest
        //
        //Description -> Debe decir qué funcionalidad/restricción 
        //debe cumplir la Calculadora
        [Test]
        [TestCase(TestName = "Calculator should not work until turned on")]
        public void CalculatorInitialStateTest()
        {
            Calculator calculator = new Calculator();

            // Debe estar apagada
            //1- El valor actual
            //2- El valor que debería de ser
            // "Probar que el valor de estar encendida sea false"
            Assert.That(calculator.IsOn(), Is.EqualTo(false));

            // No muestra nada en pantalla
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));

            // Presionar botones no hace nada, excepto el de encender
            
        }

        // Encendido / Apagado
        // CalculadoraEncendidoApagadoTest
        [Test]
        [TestCase(TestName = "Calculator should turn on and off correctly")]
        public void CalculatorOnOffTest()
        {
            Calculator calculator = new Calculator();
            
            // Apagado no debe servir
            Assert.That(calculator.IsOn(), Is.EqualTo(false));
            
            calculator.PressNumber(2);
            calculator.Sum();
            calculator.PressNumber(3);
            calculator.CalculateResult();
            
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));

            // Al presionar el botón de encendido se enciende
            calculator.TurnOn();
            Assert.That(calculator.IsOn(), Is.EqualTo(true));

            // Que sirve encendida
            calculator.PressNumber(2);
            calculator.Sum();
            calculator.PressNumber(3);
            calculator.CalculateResult();
            
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5"));

            // Apagar regresa al estado inicial
            calculator.TurnOff();
            Assert.That(calculator.IsOn(), Is.EqualTo(false));
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));
            
            calculator.PressNumber(2);
            calculator.Sum();
            calculator.PressNumber(3);
            calculator.CalculateResult();
            
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo(""));
        }

        [Test]
        [TestCase(TestName = "Calculator should sum correctly")]
        public void CalculatorSumTest()
        {
            Calculator calculator = new Calculator();

            calculator.TurnOn();

            // 1+1
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+"));
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+1"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            //2+3+4
            //=9
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2"));

            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+"));

            calculator.PressNumber(3);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+3"));

            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+3+"));

            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("2+3+4"));

            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("9"));

            // 12+34
            calculator.PressNumber(1);
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+"));
            calculator.PressNumber(3);
            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("46"));

            // 12+34+56
            calculator.PressNumber(1);
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+"));
            calculator.PressNumber(3);
            calculator.PressNumber(4);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34+"));
            calculator.PressNumber(5);
            calculator.PressNumber(6);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("12+34+56"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("102"));

            //1+22+333
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+"));
            calculator.PressNumber(2);
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+22"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+22+"));
            calculator.PressNumber(3);
            calculator.PressNumber(3);
            calculator.PressNumber(3);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1+22+333"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("356"));

            //0+0+0
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+"));
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+0"));
            calculator.Sum();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+0+"));
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0+0+0"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));
     
        }

        [Test]
        [TestCase(TestName = "Calculator should substract correctly")]
        public void CalculatorSubTest()
        {
            Calculator calculator = new Calculator();

            calculator.TurnOn();

        // --------- Resta ---------
        
        // 1 - 1
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));
            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1-"));
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1-1"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            // 1 - 50
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));
            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1-"));
            calculator.PressNumber(5);
            calculator.PressNumber(0);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1-50"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("-49"));

            // 999 - 998
            calculator.PressNumber(9);
            calculator.PressNumber(9);
            calculator.PressNumber(9);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("999"));
            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("999-"));
            calculator.PressNumber(9);
            calculator.PressNumber(9);
            calculator.PressNumber(8);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("999-998"));
            calculator.CalculateResult();  // =
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1")); 


            // 10 - 5 -5
            calculator.PressNumber(10);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10"));
            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10-"));
            calculator.PressNumber(5);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10-5"));
            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10-5-"));
            calculator.PressNumber(5);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10-5-5"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            // -2-9
            // = 0-2-9=-11
            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0-"));
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0-2"));
            calculator.Substract();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0-2-"));
            calculator.PressNumber(9);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0-2-9"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("-11"));

            
        }

        [Test]
        [TestCase(TestName = "Calculator should divide correctly")]
        public void CalculatorDivTest()
        {
            Calculator calculator = new Calculator();

            calculator.TurnOn();

            // 1 / 1
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));
            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1/"));
            calculator.PressNumber(1);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1/1"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("1"));

            // 5 / 0
            calculator.PressNumber(5);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5"));
            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5/"));
            calculator.PressNumber(0);          
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5/0"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("0"));

            // 1 / 1
            calculator.PressNumber(10);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10"));
            calculator.Divide();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10/"));
            calculator.PressNumber(2);
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("10/2"));
            calculator.CalculateResult();
            Assert.That(calculator.GetScreenMessage(), Is.EqualTo("5"));

     
        }

        

        


        //TC9 - (solo la prueba)

        // Multipliación
        // División
        // Borrar
        // Exponente
        // Raiz
        // Pi
        // E
    }
}