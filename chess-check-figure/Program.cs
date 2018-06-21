using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_check_figure
{
    public class Figure(string temp)
    {
            
    }
    public class Board
    {

        public char figure1;
        public char letter1;
        public int number1;

        public char figure2;
        public char letter2;
        public int number2;

        public string checkFigure = "KQRBNp";
        public string checkLetter = "abcdefgh";

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - для выхода из программы" +
                    "Введите информацию о первой фигуре:\n" +
                    "1. K - король, Q - ферзь, R - ладья, B - слон, N - конь, p - пешка\n" +
                    "2. Буква поля от a до h\n" +
                    "3. Цифра поля от 1 до 8\n" +
                    "Например, Qe4 - Ферзь на e4");
                string temp;
                
               /* try
                {
                    temp = Console.ReadLine();
                    if (temp == "0") break;
                    if (temp.Length >= 4 || temp.Length <= 2)
                    {
                        throw new Exception();
                    }
                    figure1 = temp[0];
                    bool cF = false;
                    for (int i = 0; i < checkFigure.Length; i++)
                        if (figure1 == checkFigure[i])
                            cF = true;
                    if (cF == false) throw new Exception();
                    letter1 = temp[1];
                    bool cL = false;
                    for (int i = 0; i < checkLetter.Length; i++)
                        if (letter1 == checkLetter[i])
                            cL = true;
                    if (cL == false) throw new Exception();
                    number1 = int.Parse(Convert.ToString(temp[2]));
                    if (number1 < 1 || number1 > 8) throw new Exception();
                }
                catch
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.\n" +
                        "Нажмите any key для продолжения.");
                    Console.ReadKey();
                    continue;
                }
                */
            //    if ()
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Board brd = new Board();
            brd.Menu();
        }
    }
}
