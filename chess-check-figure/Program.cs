using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_check_figure
{
    public class Board
    {
        //переменные первой фигуры
        public char figure1;
        public char letter1;
        public int letternum1;
        public int number1;

        //переменные второй фигуры
        public char letter2;
        public int letternum2;
        public int number2;

        // фразы для проверки
        public string checkFigure = "KQRBNp";
        public string checkLetter = "abcdefgh";

        public void VarToArray()
        {
            number1--;
            number2--;
            for 
        }

        public void Check()
        {

        }

        public void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("0 - для выхода из программы\n" +
                    "Введите информацию о первой фигуре:\n" +
                    "1. K - король, Q - ферзь, R - ладья, B - слон, N - конь, p - пешка\n" +
                    "2. Буква поля от a до h\n" +
                    "3. Цифра поля от 1 до 8\n" +
                    "Например, Qe4 - Ферзь на e4");

                string temp;
                try
                {
                    temp = Console.ReadLine();
                    if (temp == "0") break; // выход из программы
                    if (temp.Length != 3) //проверка длины введенной строки
                    {
                        throw new Exception(); // если неравно 3 -> запустить исключение (отправляем в catch)
                    }

                    figure1 = temp[0];
                    bool cF = false;
                    for (int i = 0; i < checkFigure.Length; i++)
                        if (figure1 == checkFigure[i])
                            cF = true;
                    if (!cF) throw new Exception();

                    letter1 = temp[1];
                    bool cL = false;
                    for (int i = 0; i < checkLetter.Length; i++)
                        if (letter1 == checkLetter[i])
                            cL = true;
                    if (!cL) throw new Exception();

                    number1 = int.Parse(Convert.ToString(temp[2]));
                    if (number1 < 1 || number1 > 8) throw new Exception();
                    break;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.\n" +
                        "Нажмите any key для продолжения.");
                    Console.ReadKey();
                    continue;
                }
            }
            while (true)
            {
                Console.WriteLine("Введите местоположение второй фигуры:\n" +
                                  "Например, e4");
                string temp;
                try
                {
                    temp = Console.ReadLine();
                    if (temp == "0") break; // выход из программы
                    if (temp.Length != 2) //проверка длины введенной строки
                    {
                        throw new Exception(); // если неравно 2 -> запустить исключение (отправляем в catch)
                    }

                    letter2 = temp[0];
                    bool cL = false;
                    for (int i = 0; i < checkLetter.Length; i++)
                        if (letter2 == checkLetter[i])
                            cL = true;
                    if (!cL) throw new Exception();

                    number2 = int.Parse(Convert.ToString(temp[1]));
                    if (number2 < 1 || number2 > 8) throw new Exception();

                    if (letter1 == letter2 && number1 == number2)
                    {
                        Console.WriteLine("Данная клетка поля занята. Попробуйте снова.");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Неверный ввод. Попробуйте снова.\n" +
                                      "Нажмите any key для продолжения.");
                    Console.ReadKey();
                    continue;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Board brd = new Board();
            brd.Menu();
            brd.Check();
        }
    }
}
