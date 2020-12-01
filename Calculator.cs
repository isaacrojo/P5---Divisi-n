// Encender*
// 2 -> Presionar2() / PresionarNumero(2)
// + -> PresionarMas() / Mas()
// 3 -> Presionar3()
// Pantalla: 2+3 -> string GetMensajePantalla()
// =
// Pantalla: 5
using System;
using System.Collections.Generic;

namespace Calculator
{
    class Calculator
    {
        bool on = false;
        List<string> numbers = new List<string>();
        List<string> operators = new List<string>();
        bool continueCurrentNumber = false;
        string screenMessage = "";
        bool nextNumberClearsScreenMessage = false;
        bool operatorWasRecentlyAdded = false;

        // Encender
        public void TurnOn()
        {
            this.on = true;
        }

        // Apagar
        public void TurnOff()
        {
            this.on = false;
            this.screenMessage = "";
        }

        public bool IsOn()
        {
            return this.on;
        }

        public void PressNumber(int num)
        {
            //Si la calculadora está apagada, no hacer nada
            if (!this.on)
            {
                return;
            }

            //Limpiar mensaje en caso de ser necesario
            if (this.nextNumberClearsScreenMessage)
            {
                this.screenMessage = "";
                this.nextNumberClearsScreenMessage = false;
            }

            if (this.continueCurrentNumber)
            {
                //Modificar número actual, agregándole el número introducido
                string currentNumber = numbers[numbers.Count - 1];
                currentNumber = currentNumber + num.ToString();
                numbers[numbers.Count - 1] = currentNumber;
            }
            else
            {
                //Agregar nuevo número
                numbers.Add(num.ToString());
                this.continueCurrentNumber = true;
            }
            this.screenMessage += num.ToString();
            this.operatorWasRecentlyAdded = false;
        }

        private void AddOperator(string op)
        {
            //Si la calculadora está apagada, no hacer nada
            if (!this.on)
            {
                return;
            }
            // Si lo primero que se presiona es un signo, agregar un 0
            // al inicio
            if (this.numbers.Count == 0)
            {
                this.PressNumber(0);
            }

            if (operatorWasRecentlyAdded)
            {
                //Remplazar operador más reciente por el nuevo operador
                operators[operators.Count - 1] = op;
                this.screenMessage = this.screenMessage.Substring(0, this.screenMessage.Length - 1) + op;
            }
            else
            {
                operators.Add(op);
                this.screenMessage += op;
            }

            this.continueCurrentNumber = false;
            this.operatorWasRecentlyAdded = true;
        }

        public void Sum()
        {
            AddOperator("+");
        }

        public void Substract()
        {
            AddOperator("-");
        }

        public void Multiply()
        {
            AddOperator("*");
        }

        public void Divide()
        { 
            AddOperator("/");
        }

        /// <summary>
        /// Calcula el resultado (equivalente a presionar la tecla de =)
        /// </summary>
        public void CalculateResult()
        {
            if (!this.on)
            {
                return;
            }
            //numbers: ["2", "3"]
            //operators: ["+"]
            //resultado: "5"
            // if (numbers.Count == 2 && operators.Count == 1)
            // {
            //     //operator es una palabra reservada
            //     string op = operators[0];
            //     if (op == "+")
            //     {
            //         int num1 = Convert.ToInt64(numbers[0]);   
            //         int num2 = Convert.ToInt64(numbers[1]);
            //         int result = num1 + num2;
            //         this.screenMessage = result.ToString();
            //     }
            // }

            // float -> x2 -> double
            // int -> x2 -> long
            long result = 0;
            if (numbers.Count > 0)
            {
                result = Convert.ToInt64(numbers[0]);
                int nextNumberIndex = 1;
                int nextOperatorIndex = 0;
                //Revisar que haya:
                // - Un número en la posición siguiente
                // - Un operador en la posición siguiente
                while (numbers.Count >= (nextNumberIndex + 1)
                && operators.Count >= (nextOperatorIndex + 1))
                {
                    //Sumar número que sigue
                    // result = result + Convert.ToInt64(numbers[nextNumberIndex]);

                    // Realizar siguiente operación sobre siguiente número
                    string op = this.operators[nextOperatorIndex];
                    switch (op)
                    {
                        case "+":
                            result = result + Convert.ToInt64(numbers[nextNumberIndex]);
                            break;
                        case "-":
                            result = result - Convert.ToInt64(numbers[nextNumberIndex]);
                            break;
                        case "*":
                            result = result * Convert.ToInt64(numbers[nextNumberIndex]);
                            break;
                        case "/":
                            result = result / Convert.ToInt64(numbers[nextNumberIndex]);
                            break;    
                    }


                    nextNumberIndex++;
                    nextOperatorIndex++;
                }
            }

            this.screenMessage = result.ToString();


            this.numbers.Clear();
            this.operators.Clear();
            this.continueCurrentNumber = false;
            this.nextNumberClearsScreenMessage = true;
        }

        public string GetScreenMessage()
        {
            return this.screenMessage;
        }

        // Borrar
        public void Delete()
        { }
        // Exponente -> AgregarExponente
        public void AddExponent()
        { }

        // Raiz -> AgregarRaizCuadrada
        public void AddSquareRoot()
        { }

        // Pi
        public void PressPi()
        { }

        // e
        public void PressE()
        { }
    }
}
